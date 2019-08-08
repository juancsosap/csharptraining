using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pooStarting
{
    class Program
    {
        static void Main(string[] args)
        {
            Person client1 = new Client(101, "Juan", "Sosa", "Netec");
            Console.WriteLine(client1.info);
            Person client2 = new Client(102, "Carlos", "Peña", "GK");
            Console.WriteLine(client2.info);

            Person employee1 = new Employee(201,"Ana","Prada","Engineer");
            Console.WriteLine(employee1.info);
            Person employee2 = new Employee(202, "Griselda", "Perez", "System");
            Console.WriteLine(employee2.info);
            
            Console.WriteLine(Person.quantity);
            
            Operable oper;
            Operation operation = Operation.SUB;
            switch (operation)
            {
                case Operation.ADD:
                    oper = new Addition();
                    break;
                case Operation.SUB:
                    oper = new Substraction();
                    break;
                case Operation.MUL:
                    oper = new Multiplication();
                    break;
                default:
                    oper = new Divition();
                    break;
            }
            
            Console.WriteLine(oper.operate(1, 2));
            Console.ReadKey();

        }

        enum Operation { ADD, SUB, MUL, DIV }
    }
}
