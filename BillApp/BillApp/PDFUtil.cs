using System;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace BillApp
{
    class PDFUtil
    {
        public static String ReadPdf(String filePath)
        {
            try
            {
                using (PdfReader reader = new PdfReader(filePath))
                {
                    StringBuilder sb = new StringBuilder();
                    for (int page = 1; page <= reader.NumberOfPages; page++)
                    {
                        sb.Append(PdfTextExtractor.GetTextFromPage(reader, page));
                    }
                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
