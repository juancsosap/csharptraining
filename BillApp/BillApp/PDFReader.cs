using System;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace BillApp
{
    public static class PDFReader
    {
        public static String Read(String filePath)
        {
            StringBuilder sb = new StringBuilder();
            using (PdfReader reader = new PdfReader(filePath))
            { 
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    sb.Append(PdfTextExtractor.GetTextFromPage(reader, page));
                }
            }
            return sb.ToString();
        }
    }
}
