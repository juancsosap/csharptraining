using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pooStarting
{
    public interface Operable
    {
        int operate(int valA, int valB);
    }

    public class Addition : Operable
    {
        public int operate(int valA, int valB)
        {
            return valA + valB;
        }
    }

    public class Substraction : Operable
    {
        public int operate(int valA, int valB)
        {
            return valA - valB;
        }
    }

    public class Multiplication : Operable
    {
        public int operate(int valA, int valB)
        {
            return valA * valB;
        }
    }

    public class Divition : Operable
    {
        public int operate(int valA, int valB)
        {
            return valA / valB;
        }
    }
}
