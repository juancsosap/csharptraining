using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Globalization;

namespace BillApp
{
    class Utils
    {
        public static String LoadFolder()
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                return fbd.ShowDialog() == DialogResult.OK ? fbd.SelectedPath : null;
            }
        }

        public static String LoadPath(String fileFilter)
        {
            using(OpenFileDialog ofd = new OpenFileDialog() { Filter = fileFilter, ValidateNames = true, Multiselect = false })
            {
                return ofd.ShowDialog() == DialogResult.OK ? ofd.FileName : null;
            }
        }

        public static List<String> LoadPaths(String fileFilter)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = fileFilter, ValidateNames = true, Multiselect = true })
            {
                return ofd.ShowDialog() == DialogResult.OK ? ofd.FileNames.ToList() : null;
            }
        }

        public static String GetOutputFileName(String folder, String filename)
        {
            return Path.Combine(folder, filename + ".xlsx");
        }

        public static string GetOutputTemplate()
        {
            return Path.Combine(Application.StartupPath, ConfigurationManager.AppSettings.Get("outputTemplate"));
        }

        public static int SimplifiedNumber(String input)
        {
            Regex notDigitsOnly = new Regex(@"[^\d]");
            String strNumber = notDigitsOnly.Replace(input, "");
            return Int32.Parse(strNumber);
        }

        public static String[] Split(String input, String separator)
        {
            return input.Split(new String[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static String GetText(String input, String begin, String end)
        {
            String[] endKey = new String[] { end };
            return GetText(input, begin).Split(endKey, StringSplitOptions.RemoveEmptyEntries)[0];
        }

        public static String GetText(String input, String begin)
        {
            String[] beginKey = new String[] { begin };
            return input.Split(beginKey, StringSplitOptions.RemoveEmptyEntries)[1];
        }

        public static String[] SplitText(String input, String delimiter)
        {
            String[] delimiterKey = new String[] { delimiter };
            return input.Split(delimiterKey, StringSplitOptions.RemoveEmptyEntries);
        }

        public static int ToInt(String input)
        {
            return Int32.Parse(Utils.Split(input, ".")[0], CultureInfo.InvariantCulture);
        }

        public static Double ToDouble(String input)
        {
            return Double.Parse(input, CultureInfo.InvariantCulture);
        }

        public static DateTime ToDate(String input, String format)
        {
            return DateTime.ParseExact(input, format, CultureInfo.InvariantCulture);
        }

        public static bool IsInteger(String text)
        {
            return text.All((c) => c >= '0' && c <= '9');
        }
    }
}
