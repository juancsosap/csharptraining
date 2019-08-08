using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiniteCalc
{
    public class Program
    {
        static void Main(string[] args)
        {
            InfiniteInteger num1 = new InfiniteInteger("9999999999999999999999999999999999999999999999999999999999999999999999999999");
            InfiniteInteger num2 = new InfiniteInteger(9999);
            InfiniteInteger num3 = num1 + num2;
            Console.WriteLine(" " + num1.ToString() + "\n " + num2.ToString() + "\n\n" + num3.ToString());
            Console.ReadLine();
        }
    }
    public class InfiniteInteger
    {
        private string _number;
        public string value { get => _number; set => _number = value; }

        public InfiniteInteger(string value)
        {
            bool valid = true;
            for(int i=0; i<value.Length; i+=18)
            {
                int size = (value.Length - i) >= 18 ? 18 : (value.Length - i);
                string valued = value.Substring(i, size);
                long result;
                if (!long.TryParse(valued, out result))
                {
                    valid = false;
                    break;
                }
            }
            this.value = valid ? value : "0";
        }
        public InfiniteInteger(long value) : this(value + "") { }

        public override string ToString() => this.value;

        public static InfiniteInteger operator +(InfiniteInteger num1, InfiniteInteger num2)
        {
            int size1 = num1.value.Length;
            int size2 = num1.value.Length;
            int size = (size1 > size2) ? size1 : size2;
            num1 = addZeros(num1, size);
            num2 = addZeros(num2, size);

            String result = "";
            int restd = 0;
            for (int i = size - 1; i >= 0; i--)
            {
                int num1d = int.Parse(num1.value.Substring(i, 1));
                int num2d = int.Parse(num2.value.Substring(i, 1));
                int resultd = num1d + num2d + restd;
                restd = (resultd < 10) ? 0 : 1;
                resultd = (resultd < 10) ? resultd : resultd - 10;
                result = resultd + result;
            }
            result = ((restd > 0) ? "1" : "") + result;
            return new InfiniteInteger(result);
        }

        private static InfiniteInteger addZeros(InfiniteInteger num, int size, bool left)
        {
            int numSize = num.value.Length;
            for (int i = 0; i < (size - numSize); i++)
            {
                num.value = left ? "0" + num.value : num.value + "0";
            }
            return num;
        }
        private static InfiniteInteger addZeros(InfiniteInteger num, int size) => addZeros(num, size, true);

    }

}
