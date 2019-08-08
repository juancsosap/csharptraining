using fileDownloading;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace fileProcess
{
    class Program
    {
        public static void Main(string[] args)
        { 
            String pathUrl = @"RFCs/";
            List<Thread> tl = new List<Thread>();
            int q = 8294; //8294

            ActionTimeMeter timeMeter = new ActionTimeMeter();
            timeMeter.Begin();

            for (int i = 0; i < q; i++) 
            {
                String fileName = "rfc" + (i + 1) + ".txt";
                tl.Add(new Thread((new FileAnalizer()).analizeFile));
                FileAnalizer.quantity++;
                Console.WriteLine("Starting Process File " + fileName + " - " + FileAnalizer.quantity);
                
                tl[i].Start(pathUrl + fileName);
            }
            for (int i = 0; i < q; i++) 
                tl[i].Join();

            Console.WriteLine();
            List<Word> fwl = new List<Word>();
            StreamWriter wfile = new StreamWriter("result.log");
            foreach (Word w in FileAnalizer.words)
                if(w.word.Length > 3)
                {
                    fwl.Add(new Word(w.word, w.quantity));
                    wfile.Write(w.word + "," + w.quantity + "\n");
                }
            wfile.Close();
            Console.WriteLine();

            int maxQ = fwl.Max(x => x.quantity);
            int averageQ = (int) fwl.Average(x => x.quantity > maxQ/2 ? x.quantity : maxQ/2);
            foreach (Word w in fwl)
                if (w.quantity > averageQ)
                    Console.WriteLine(w.word + ":" + w.quantity);

            Console.WriteLine("RunTime " + timeMeter.End());
            
            Console.ReadLine();
        }

        
        
    }
}
