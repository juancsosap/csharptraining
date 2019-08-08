using System.Text.RegularExpressions;

namespace InfiniteProject
{
    /*class InfiniteIntegerEven : InfiniteInteger
    {
        public InfiniteIntegerEven(string value) : base(value)
        {
            int last = int.Parse(value.Substring(value.Length - 1, 1));
            this.number = ((last % 2) == 0) ? value : "0";
        }

    }*/
    class InfiniteInteger
    {
        public readonly string number;

        private const int SIZE = 18;

        public InfiniteInteger(string value)
        {
            Regex regex = new Regex("^[1-9][0-9]*$");
            Match match = regex.Match(value);
            this.number = (match.Success) ? value : "0";
        }

        /*  11111111110
         *   9999999999
         *   9999999999 +
         * ------------
         *  19999999998
         */

        public static InfiniteInteger operator +(InfiniteInteger num1, InfiniteInteger num2)
        {
            int size1 = num1.number.Length;
            int size2 = num2.number.Length;
            int size = (size1 > size2) ? size1 : size2;

            string strNum1 = addZeros(num1.number, size);
            string strNum2 = addZeros(num2.number, size);

            //string strNum1 = num1.addZeros(size);
            //string strNum2 = num2.addZeros(size);
            string strResult = "";

            int drest = 0;

            for(int i=0; i<size; i++)
            {
                int dval1 = int.Parse(strNum1.Substring(size - i - 1, 1));
                int dval2 = int.Parse(strNum2.Substring(size - i - 1, 1));
                int dresult = dval1 + dval2 + drest;
                //drest = (dresult > 9) ? 1 : 0;
                //dresult = (dresult > 9) ? dresult - 10 : dresult;
                drest = dresult / 10; // 15 ----> 1
                dresult = dresult % 10; // 15 --> 5
                strResult = dresult + strResult;
            }
            strResult = ((drest > 0) ? "1" : "") + strResult;
            
            return new InfiniteInteger(strResult);
        }

        private static string addZeros(string num, int size)
        {
            //string num = this.number;
            int numSize = num.Length;
            int zeros = size - numSize;
            for (int i=0; i<zeros; i++)
            {
                num = "0" + num;
            }
            return num;
        }

        public override string ToString() => this.number;
    }
}
