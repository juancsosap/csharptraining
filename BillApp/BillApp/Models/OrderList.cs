using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillApp.Models
{
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
            for (int i = 0; i < lines.Length; i++)
            {
                if (Utils.Split(lines[i], " ").Length > 5)
                {
                    String packedCode = Utils.Split(lines[i], " ")[1];
                    if (packedCode.EndsWith("*"))
                        packedCode = Utils.Split(lines[++i], " ")[0];
                    String itemsText = Utils.GetText(input, "\nHu-Nr.: " + packedCode);
                    itemsText = Utils.SplitText(itemsText, "\nHu-Nr.: ")[0];
                    String zoneItems = "";
                    String[] zonesItems = Utils.Split(itemsText, "UKZ\n");
                    for (int j = 1; j < zonesItems.Length; j++)
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
}
