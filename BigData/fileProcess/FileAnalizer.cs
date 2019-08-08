using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fileProcess
{
    class FileAnalizer
    {
        public static List<Word> words = new List<Word>();
        public static int quantity = 0;

        public void analizeFile(Object fullPath)
        {
            String path = fullPath.ToString();
            WordAnalizer wa = new WordAnalizer(path);
            wa.proccessFile();
            lock (this)
            {
                FileAnalizer.words.AddRange(wa.getWordList());
                FileAnalizer.words.Sort();
                FileAnalizer.words = WordAnalizer.groupWords(FileAnalizer.words);
            }
            FileAnalizer.quantity--;
            Console.WriteLine("Ending Process File " + Path.GetFileName(path) + " - " + FileAnalizer.quantity);
        }
    }
}
