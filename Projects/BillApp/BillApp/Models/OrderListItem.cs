using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillApp.Models
{
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
            foreach (BillItem item in bill.items)
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
}
