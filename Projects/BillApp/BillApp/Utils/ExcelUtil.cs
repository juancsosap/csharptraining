using System;
using System.Runtime.Serialization;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace BillApp
{
    class ExcelUtil : IDisposable
    {
        private _Application excel = new _Excel.Application();
        private Workbook wb;
        private Worksheet ws;

        public ExcelUtil(String path, int sheet = 1, bool newFile = false)
        {
            if (newFile)
            {
                CreateWorkbook(path);
            }
            else
            {
                OpenWorkbook(path, sheet);
            }
        }

        private void OpenWorkbook(String path, int sheet)
        {
            wb = excel.Workbooks.Open(path);
            SelectWorksheet(sheet);
        }

        private void CreateWorkbook(String path)
        {
            wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            ws = wb.Worksheets[1];
            SaveAs(path);
        }

        public String ReadCell(int row, int col)
        {
            return ws.Cells[row + 1, col + 1].Value2;
        }

        public void WriteCell(int row, int col, Object value)
        {
            string data = (value is DateTime) ? ((DateTime)value).ToShortDateString() :
                                                value.ToString();
            ws.Cells[row + 1, col + 1].Value2 = data;
        }

        public void WriteRow(int row, int start, params Object[] datas)
        {
            foreach (Object data in datas)
            {
                WriteCell(row, start++, data);
            }
        }

        public void SelectWorksheet(int sheet)
        {
            ws = wb.Worksheets[sheet];
        }

        public void DeleteWorksheet(int sheet)
        {
            wb.Worksheets[sheet].Delete();
        }

        public void CreateNewSheet()
        {
            wb.Worksheets.Add(After: ws);
        }

        public void Save()
        {
            wb.Save();
        }

        public void SaveAs(String newPath)
        {
            wb.SaveAs(newPath);
        }

        public void Dispose()
        {
            wb.Close();
        }
    }
}
