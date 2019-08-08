using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;

namespace WordAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(bookReview);
            t1.Start(@"books/book1.txt");
            Thread t2 = new Thread(bookReview);
            t2.Start(@"books/book2.txt");
            Thread t3 = new Thread(bookReview);
            t3.Start(@"books/book3.txt");
            Thread t4 = new Thread(bookReview);
            t4.Start(@"books/book4.txt");

            t1.Priority = ThreadPriority.Highest;

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            
            Console.WriteLine("Termine");
            Console.ReadLine();
        }

        public static void bookReview(Object bookPath)
        {
            String path = (String) bookPath;
            StreamReader file = new StreamReader(path, Encoding.Default);
            List<Word> words = new List<Word>();
            while (file.Peek() >= 0)
            {
                String line = file.ReadLine();
                char[] separator = { ' ' };
                String[] wordsLine = line.Split(separator);
                foreach (String word in wordsLine)
                {
                    StringBuilder newWord = new StringBuilder(word);
                    char[] removedChars = { ',', '.', ';', ':', '-', '—',
                                            '_', '!', '¡', '?', '¿', '(',
                                            ')', '»', '«', '"', '©' };
                    Regex regex = new Regex("^[0-9]+$");
                    foreach (char cr in removedChars)
                        newWord = newWord.Replace(cr, ' ');
                    String finalWord = newWord.ToString().ToLower().Trim();
                    if (finalWord.Length > 2 && !regex.Match(finalWord).Success)
                        words.Add(new Word(finalWord, 1));
                }
                // Console.Write("#");
            }
            /*
            Console.WriteLine();
            foreach (Word word in words)
                Console.Write(word.value + " ");
            Console.WriteLine();
            */
            var wordList = from word in words orderby word group word by word.value;

            Console.WriteLine();
            List<Word> summaryWords = new List<Word>();
            foreach (var group in wordList)
                summaryWords.Add(new Word(group.Key, group.Sum(w => w.quantity)));

            summaryWords.Sort((x, y) => x.quantity.CompareTo(y.quantity));
            //summaryWords.Reverse();

            foreach (Word w in summaryWords)
            {
                if (w.quantity > 100) { Console.WriteLine(Path.GetFileName(path) + ":" + w.value + " : " + w.quantity); }
            }
        }

    }

    class Word : IComparable
    {
        public String value { get; }
        public int quantity { get; }

        public Word(String word, int quantity)
        {
            this.value = word;
            this.quantity = quantity;
        }

        public int CompareTo(object obj) => this.value.CompareTo(((Word)obj).value);
    }

}



