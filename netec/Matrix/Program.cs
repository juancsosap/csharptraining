using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m0 = new Matrix();
            Console.WriteLine(m0);

            Matrix m1 = new Matrix(3,4,100);

            /*
             *  1 1 1
             *  1 1 1
             *  1 1 1
             */

            Console.WriteLine(m1);

            int[,] matrix2 = { {100,200,300,400}, 
                               {400,500,600,400}, 
                               {700,800,900,400} };
            
            Matrix m2 = new Matrix(matrix2);

            Console.WriteLine(m2);
            /*
             *  1 2 3
             *  4 5 6
             *  7 8 9
             *  
             */

            Matrix m3 = m1 + m2;

            Console.WriteLine(m3);

            Matrix m4 = new Matrix(10, 10, 1000);
            Console.WriteLine(m4);

            /*
             *  2 3 4
             *  5 6 7
             *  8 9 10
             */
            Console.ReadLine();
        }
    }
}
