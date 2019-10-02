using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BillApp.Models
{
    class BillItem
    {
        public int quantity;           // Cant.
        public String pn;              // N. Parts
        public Double unitPrice;       // P. Unitario
        public Double amount;          // Importe                  // unitPrice * quantity
        public Double discount;        // Descuento
        public Double total;           // Total                    // amount - discount

        public BillItem(String line, CultureInfo ci)
        {
            String[] values = Utils.Split(line, " ");
            int size = values.Length;

            this.quantity = Utils.ToInt(values[0]);
            this.pn = values[2];
            this.unitPrice = Utils.ToDouble(values[size - 4], ci);
            this.amount = Utils.ToDouble(values[size - 3], ci);
            this.discount = Utils.ToDouble(values[size - 2], ci);
            this.total = Utils.ToDouble(values[size - 1], ci);
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
                foreach (OrderListItem item in order.items)
                {
                    if (this.ValidPN(item.pn)) quantity += item.quantity;
                }
            }
            return quantity > bill.GetQuantity(this.pn) ? "Exceded" :
                   quantity == bill.GetQuantity(this.pn) ? "OK" :
                   quantity == 0 ? "Not Available" :
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
}
