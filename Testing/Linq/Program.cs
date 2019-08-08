using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = generateNumbers(60, 10, 99);
            printNumbers(num);
            int[] newNum = filterNumbers(num, 50);  // SELECT valor FROM array WHERE valor >= 50 ORDER BY valor DESC;
            printNumbers(newNum);
            int[] newNumColl = filterNumbersColl(num, 50);
            printNumbers(newNumColl);
            var newNumLinq = from i in num where i >= 50 orderby i descending select i;
            printNumbers(newNumLinq.ToArray<int>());
            Console.ReadLine();
        }

        static int[] generateNumbers(int size, int min, int max)
        {
            int[] num = new int[size];
            Random val = new Random();
            for(int i=0; i<size; i++)
            {
                num[i] = val.Next(min, max);
            }
            return num;
        }

        static int[] filterNumbers(int[] num, int min)
        {
            int count = 0;
            for (int i = 0; i < num.Length; i++)
                count += (num[i] >= min) ? 1 : 0;

            int[] newNum = new int[count];
            int j = 0;
            for (int i = 0; i < num.Length; i++)
                if (num[i] >= min)
                {
                    newNum[j] = num[i];
                    j++;
                }

            Array.Sort(newNum);
            Array.Reverse(newNum);

            return newNum;
        }
    
        static int[] filterNumbersColl(int[] num, int min)
        {
            List<int> newNumColl = new List<int>();

            foreach (int v in num) {
                if(v >= min)
                    newNumColl.Add(v);
            }

            int[] newNum = newNumColl.ToArray();

            Array.Sort(newNum);
            Array.Reverse(newNum);

            return newNum;
        }

        static void printNumbers(int[] num)
        {
            StringBuilder text = new StringBuilder("");
            Console.WriteLine(num.Length);
            foreach (int v in num)
            {
                text.Append(v + "  ");
            }
            Console.WriteLine(text);
            Console.WriteLine();
        }
    }
}
