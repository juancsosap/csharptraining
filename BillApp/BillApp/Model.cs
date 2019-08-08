using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace BillApp.Models
{
    class CI {
        public static const CultureInfo baseCI = new CultureInfo("es");
    }

    class Bill
    {
        public String code;            // Factura Folio Interno    // FRGSF0000385
        public DateTime date;          // Fecha y Hora de Emisión: // 23/11/2018 16:37:14
        public Double total;           // Total                    // 18,873.33
        public List<BillItem> items = new List<BillItem>();

        public int GetInvoice() => Utils.SimplifiedNumber(this.code);

        public Bill(String path)
        {
            String input = PDFUtil.ReadPdf(path);

            this.code = Utils.GetText(input, "Factura Folio Interno: ", "\n");
            this.date = Utils.ToDate(Utils.GetText(input, "Fecha y Hora de Emisión: ", "T"), "yyyy-MM-dd"); // 2019-01-24
            this.total = Utils.ToDouble(Utils.GetText(input, "\nTotal\n", "\n"), CI.baseCI);
            String codes = Utils.GetText(input, code + "\n", "\n");

            String intemsZone = Utils.GetText(input, "Total\n", "\nAVISO:\n");
            String[] pages = Utils.SplitText(intemsZone, "\nEste documento es una representación impresa de un CFDI");
            String itemsText = pages[0];
            for (int i = 1; i < pages.Length - 1; i++)
            {
                itemsText += Utils.GetText(pages[i], codes);
            }
            String[] lines = Utils.Split(itemsText, "\n");
            foreach (String line in lines)
            {
                if (Utils.Split(line, " ").Length > 8)
                {
                    this.items.Add(new BillItem(line));
                }
            }
        }

        public bool ValidBill()
        {
            Double total = 0;
            this.items.ForEach(i => total += i.quantity * i.unitPrice);
            return this.total == total;
        }

        public int GetQuantity(String pn) {
          int quantity = 0;
          this.items.ForEach(i => {
            if(i.pn.Equals(pn))
              quantity += i.quantity;
          });
          return quantity;
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Code: " + this.code + "\t");
            sb.Append("Date: " + this.date.ToShortDateString() + "\n");
            sb.Append("Total: " + this.total + "\t");
            sb.Append("Valid: " + this.ValidBill() + "\n");
            sb.Append("----------------------------------\n");
            sb.Append("Items: \n");
            this.items.ForEach(i => sb.Append(i));
            return sb.ToString();
        }
    }

    class BillItem
    {
        public int quantity;           // Cant.
        public String pn;              // N. Parts
        public Double unitPrice;       // P. Unitario
        public Double amount;          // Importe                  // unitPrice * quantity
        public Double discount;        // Descuento
        public Double total;           // Total                    // amount - discount

        public BillItem(String line)
        {
            String[] values = Utils.Split(line, " ");
            int size = values.Length;

            this.quantity = Utils.ToInt(values[0]);
            this.pn = values[2];
            this.unitPrice = Utils.ToDouble(values[size - 4], CI.baseCI);
            this.amount = Utils.ToDouble(values[size - 3], CI.baseCI);
            this.discount = Utils.ToDouble(values[size - 2], CI.baseCI);
            this.total = Utils.ToDouble(values[size - 1], CI.baseCI);
        }

        private static Regex exception = new Regex(@"-6");
        public bool ValidPN(String listPN)
        {
            return this.pn.Equals(listPN);
        }

        public String GetSimplifiedPN() => this.pn.Replace(".", "").Replace("-", "");

        public String GetStatus(Bill bill, List<OrderList> orders)
        {
            if (this.pn == "EMBALAJE" || this.pn == "COSTES_FLETE") return "Extra Charges";

            int quantity = 0;
            foreach (OrderList order in orders)
            {
                foreach(OrderListItem item in order.items)
                {
                    if (this.ValidPN(item.pn)) quantity += item.quantity;
                }
            }
            return quantity > bill.GetQuantity(this.pn)  ? "Exceded" :
                   quantity == bill.GetQuantity(this.pn) ? "OK" :
                   quantity == 0                         ? "Not Available" :
                                                           "Incomplete";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("----------------------------------\n");
            sb.Append("Quantity: " + this.quantity + "\t\t");
            sb.Append("Part Number: " + this.pn + "\n");
            sb.Append("Unit Price: " + this.unitPrice + "\t\t");
            sb.Append("Amount: " + this.amount + "\n");
            sb.Append("Discount: " + this.discount + "\t\t");
            sb.Append("Total: " + this.total + "\n");
            return sb.ToString();
        }
    }

    class OrderList
    {
        public String id;                 // Entrega No.:
        public DateTime date;          // Fecha:
        public String order;           // Pedido No.:
        public String code;            // Su no. de pedido:
        public String condition;       // Condición de despacho:
        public String incoterm;        // Incoterm:
        public List<OrderListItem> items = new List<OrderListItem>();

        public OrderList(String path)
        {
            String input = PDFUtil.ReadPdf(path);
            this.id = Utils.GetText(input, "Entrega No.: ", "\n");
            this.date = Utils.ToDate(Utils.GetText(input, "Fecha: ", "\n"), "dd.MM.yyyy");
            this.order = Utils.GetText(input, "Pedido No.: ", "\n");
            this.code = Utils.GetText(input, "Su no. de pedido: ", "\n");
            this.condition = Utils.GetText(input, "Condición de despacho: ", "\n");
            this.incoterm = Utils.GetText(input, "Incoterm: ", "\n");

            String packsText = Utils.GetText(input, "\nempaque\n", "\nSuma de peso");
            String[] lines = Utils.Split(packsText, "\n");
            for(int i = 0; i < lines.Length; i++)
            {
                if(Utils.Split(lines[i], " ").Length > 5)
                {
                    String packedCode = Utils.Split(lines[i], " ")[1];
                    if(packedCode.EndsWith("*"))
                        packedCode = Utils.Split(lines[++i], " ")[0];
                    String itemsText = Utils.GetText(input, "\nHu-Nr.: " + packedCode);
                    itemsText = Utils.SplitText(itemsText, "\nHu-Nr.: ")[0];
                    String zoneItems = "";
                    String[] zonesItems = Utils.Split(itemsText, "UKZ\n");
                    for(int j = 1; j < zonesItems.Length; j++)
                    {
                        zoneItems += Utils.Split(zonesItems[j], "\nPágina\n")[0];
                        int le = zoneItems.LastIndexOf('\n');
                        zoneItems = zoneItems.Substring(0, le + 1);
                    }

                    String[] itemsLines = Utils.Split(zoneItems, "\n");
                    foreach (String itemLine in itemsLines)
                    {
                        String[] dataLine = Utils.Split(itemLine, " ");
                        if (dataLine.Length > 5 && Utils.IsInteger(dataLine[0]))
                        {
                            this.items.Add(new OrderListItem(packedCode, itemLine));
                        }

                    }

                }
            }
        }

        public int GetSupplierOrder() => Utils.SimplifiedNumber(this.code);

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("ID: " + this.id + "\t\t");
            sb.Append("Date: " + this.date.ToShortDateString() + "\n");
            sb.Append("Order: " + this.order + "\t\t");
            sb.Append("Code: " + this.code + "\n");
            sb.Append("Condition: " + this.condition + "\t");
            sb.Append("Incoterm: " + this.incoterm + "\n");
            sb.Append("----------------------------------\n");
            sb.Append("Items: \n");
            this.items.ForEach(i => sb.Append(i));
            return sb.ToString();
        }
    }

    class OrderListItem
    {
        public String packetCode;      // Hu-Nr.:
        public String pn;              // Material Denominación        // Link with the bill
        public int quantity;        // Cantidad / unidad UKZ

        public OrderListItem(String pc, String input)
        {
            this.packetCode = pc;

            String[] info = Utils.Split(input, " ");
            this.pn = info[1];
            this.quantity = Utils.ToInt(info[2]);
        }

        public String GetStatus(Bill bill)
        {
            foreach(BillItem item in bill.items)
            {
                if (item.ValidPN(this.pn)) return "Available";
            }
            return "Extra Item";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Packet Code: " + this.packetCode + "\t\t");
            sb.Append("Part Number: " + this.pn + "\n");
            sb.Append("Quantity: " + this.quantity + "\n");
            return sb.ToString();
        }
    }

    class BillOutputItem
    {
        public int id;                 // Supplier No(ETN)             // 51344            // NOT DEFINED
        public int invoice;            // Invoice No.                  // 385              // Bill.GetInvoice()
        public DateTime date;          // Invoice date                 // 23-11-2018       // Bill.date
        public Double billTotal;       // Total value invoice          // 18.873,33        // Bill.total
        public int itemId;             // Item                         // 10               // AUTOGENERATED FROM 10 IN STEPS OF 10 (10, 20, 30, ...)
        public String pn;              // Article No                   // 81391436104      // OrderListItem.GetSimplifiedPN()
        public int quantity;           // Quantity                     // 1                // OrderListItem.quantity
        public Double unitPrice;       // Price                        // 1241,2           // BillItem.unitPrice
        public int supplierOrder;      // Supplier Order No            // 108              // OrderList.GetSupplierOrder()
        public String packCode;        // Picket No (Barcode of Box)   // 91811210829      // OrderListItem.packetCode
        public String billCode;        // BL                           // FRGSF0000385     // Bill.code

        public BillOutputItem(Bill bill, OrderList order, String pc, String pn, int id, int item)
        {
            this.id = id;
            this.invoice = bill.GetInvoice();
            this.date = bill.date;
            this.billTotal = bill.total;
            this.itemId = item;
            String orderPN = pn;
            String fullPN = "";
            try
            {
                fullPN = bill.items.Find(i => i.ValidPN(orderPN)).pn;
                this.pn = bill.items.Find(i => i.ValidPN(orderPN)).GetSimplifiedPN(); // Link between files
                this.quantity = order.items.Find(o => o.packetCode.Equals(pc) && o.pn.Equals(fullPN)).quantity;
            }
            catch (Exception)
            {
                this.pn = null;
            }

            this.unitPrice = (this.pn != null) ? bill.items.Find(i => i.ValidPN(fullPN)).unitPrice : 0;
            this.supplierOrder = order.GetSupplierOrder();
            this.packCode = pc;
            this.billCode = bill.code;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("----------------------------------\n");
            sb.Append("ID: " + this.id + "\t\t\t");
            sb.Append("Invoice: " + this.invoice + "\n");
            sb.Append("Date: " + this.date.ToShortDateString() + "\t\t");
            sb.Append("Bill Total: " + this.billTotal + "\n");
            sb.Append("Item ID: " + this.itemId + "\t\t");
            sb.Append("Part Number: " + this.pn + "\n");
            sb.Append("Quantity: " + this.quantity + "\t\t");
            sb.Append("Unit Price: " + this.unitPrice + "\n");
            sb.Append("Supplier Order: " + this.supplierOrder + "\t");
            sb.Append("Packet Code: " + this.packCode + "\n");
            sb.Append("Bill Code: " + this.billCode + "\n");
            return sb.ToString();
        }

        public static void ExportOutput(Bill bill, List<OrderList> orders, String path, View view)
        {
            view.StatusUpdate("Loading Output");
            List<BillOutputItem> output = BillOutputItem.LoadOutput(bill, orders);

            using (ExcelUtil eu = new ExcelUtil(Utils.GetOutputTemplate()))
            {
                int line = 1;
                eu.SelectWorksheet(1);
                int itemCount = output.Count;
                int count = 0;
                foreach (BillOutputItem item in output)
                {
                    view.StatusUpdate("Exporting Output - Sheet I (" + ++count + " of " + itemCount + ")");
                    if (item.pn != null)
                    {
                        eu.WriteCell(line, 0, item.id);
                        eu.WriteCell(line, 1, item.invoice);
                        eu.WriteCell(line, 2, item.date.ToShortDateString());
                        eu.WriteCell(line, 3, item.billTotal);
                        eu.WriteCell(line, 4, item.itemId);
                        eu.WriteCell(line, 5, item.pn);
                        eu.WriteCell(line, 6, item.quantity);
                        eu.WriteCell(line, 7, item.unitPrice);
                        eu.WriteCell(line, 8, item.supplierOrder);
                        eu.WriteCell(line, 9, item.packCode);
                        eu.WriteCell(line, 10, item.billCode);
                        line++;
                    }
                }

                line = 1;
                eu.SelectWorksheet(2);
                itemCount = bill.items.Count;
                count = 0;
                foreach (BillItem item in bill.items)
                {
                    view.StatusUpdate("Exporting Output - Sheet II (" + ++count + " of " + itemCount + ")");
                    eu.WriteCell(line, 0, bill.code);
                    eu.WriteCell(line, 1, bill.date.ToShortDateString());
                    eu.WriteCell(line, 2, bill.total);
                    eu.WriteCell(line, 3, item.quantity);
                    eu.WriteCell(line, 4, item.pn);
                    eu.WriteCell(line, 5, item.unitPrice);
                    eu.WriteCell(line, 6, item.amount);
                    eu.WriteCell(line, 7, item.discount);
                    eu.WriteCell(line, 8, item.total);
                    eu.WriteCell(line, 9, item.GetStatus(bill, orders));
                    line++;
                }

                line = 1;
                eu.SelectWorksheet(3);
                itemCount = orders.Count;
                count = 0;
                foreach (OrderList order in orders)
                {
                    view.StatusUpdate("Exporting Output - Sheet III (" + ++count + " of " + itemCount + ")");
                    foreach (OrderListItem item in order.items)
                    {
                        eu.WriteCell(line, 0, order.id);
                        eu.WriteCell(line, 1, order.date.ToShortDateString());
                        eu.WriteCell(line, 2, order.order);
                        eu.WriteCell(line, 3, order.code);
                        eu.WriteCell(line, 4, order.condition);
                        eu.WriteCell(line, 5, order.incoterm);
                        eu.WriteCell(line, 6, item.packetCode);
                        eu.WriteCell(line, 7, item.pn);
                        eu.WriteCell(line, 8, item.quantity);
                        eu.WriteCell(line, 9, item.GetStatus(bill));
                        line++;
                    }
                }

                eu.SaveAs(path);
            }
        }

        public static List<BillOutputItem> LoadOutput(Bill bill, List<OrderList> orders)
        {
            List<BillOutputItem> output = new List<BillOutputItem>();
            int itemId = 10;
            foreach(OrderList order in orders)
            {
                foreach(OrderListItem item in order.items)
                {
                    output.Add(new BillOutputItem(bill, order, item.packetCode, item.pn, 51344, itemId));
                    itemId += 10;
                }
            }
            return output;
        }
    }
}
