using fileDownloading;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace fileProcess
{
    class WordAnalizer
    {
        private String path;
        private List<Word> words = new List<Word>();

        private static ActionTimeMeter timeMeter = new ActionTimeMeter();

        public WordAnalizer(String path)
        {
            this.path = path;
            timeMeter.Begin();
        }

        public List<Word> getWordList() => words;

        public void proccessFile(Boolean process)
        {
            StreamReader rFile = new StreamReader(this.path, Encoding.Default);
            List<Word> tempWords = new List<Word>();
            while (rFile.Peek() >= 0)
            {
                String line = rFile.ReadLine();
                char[] separator = { ' ' };
                String[] wordsLine = line.Split(separator);
                foreach (String word in wordsLine)
                {
                    StringBuilder sbWord = new StringBuilder(word);
                    char[] removedChars = { ',', '.', ';', ':', '-', '—', '<', '[',
                                            '_', '!', '¡', '?', '¿', '(', '>', ']',
                                            ')', '»', '«', '"', '©', '+', '|', '=' };
                    Regex regex = new Regex("^[0-9]+$");
                    foreach (char cr in removedChars)
                        sbWord = sbWord.Replace(cr, ' ');
                    String finalWord = sbWord.ToString().ToLower().Trim();
                    if (finalWord.Length > 0 && !regex.Match(finalWord).Success)
                        tempWords.Add(new Word(finalWord,1));
                }
                if (process) Console.Write("#");

                words = WordAnalizer.groupWords(tempWords);

                StreamWriter wfile = new StreamWriter(this.path + ".log");
                foreach(Word w in words)
                    wfile.Write(w.word + "," + w.quantity + "\n");
                wfile.Close();

            }
        }
        public void proccessFile() { this.proccessFile(false); }

        public static List<Word> groupWords(List<Word> words)
        {
            List<Word> tempWords = new List<Word>();
            
            var wordList = from word in words orderby word group word by word.word;
            foreach (var wordGroup in wordList)
                tempWords.Add(new Word(wordGroup.Key, wordGroup.Sum(x => x.quantity)));

            tempWords.Sort((x, y) => x.quantity.CompareTo(y.quantity));

            return tempWords;
        }
    }
}
