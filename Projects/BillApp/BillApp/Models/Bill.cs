using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillApp.Models
{
    class Bill
    {
        public String code;            // Factura Folio Interno    // FRGSF0000385
        public DateTime date;          // Fecha y Hora de Emisión: // 23/11/2018 16:37:14
        public Double total;           // Total                    // 18,873.33
        public List<BillItem> items = new List<BillItem>();

        public int GetInvoice() => Utils.SimplifiedNumber(this.code);

        public Bill(String path, String lang)
        {
            CultureInfo ci = new CultureInfo(lang);

            String input = PDFUtil.ReadPdf(path);

            /*
             Fecha de Expedición:
             Fecha de Orden de Compra:
             2019-08-05T16:02:48-05:00 8/5/2019
             */

            this.code = Utils.GetText(input, "Factura Folio Interno: ", "\n");
            this.date = Utils.ToDate(Utils.GetText(input, "Fecha de Orden de Compra:\n", "T"), "yyyy-MM-dd"); // 2019-01-24
            this.total = Utils.ToDouble(Utils.GetText(input, "\nTotal\n", "\n"), ci);
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
                    this.items.Add(new BillItem(line, ci));
                }
            }
        }

        public bool ValidBill()
        {
            Double total = 0;
            this.items.ForEach(i => total += i.quantity * i.unitPrice);
            return this.total == total;
        }

        public int GetQuantity(String pn)
        {
            int quantity = 0;
            this.items.ForEach(i => {
                if (i.pn.Equals(pn))
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
}
