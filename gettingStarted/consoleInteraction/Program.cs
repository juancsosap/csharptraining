using System;

namespace ConsoleInteraction {
    class Program {
        static void Main(string[] args) {
            Person user;
            if(args.Length > 0) {
                if (args[0].Equals("--vervose")) {
                    Console.WriteLine("Please, Type your name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Please, Type your surname:");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Please, Type your age:");
                    int age = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Please, Type your heigth:");
                    double heigth = Double.Parse(Console.ReadLine());
                    user = new Person(name, surname, age, heigth);
                } else {
                    user = new Person(args[0], args[1], Int32.Parse(args[2]), Double.Parse(args[3]));
                }
                Console.WriteLine("Thanks for the info {0}.", user.getFullName());
                Console.WriteLine("Then, you are {0} old and {1:F2} tall.", user.getAge(), user.getHeigth());
            }
        }

        private class Person {

            public string name { get; set; }

            public string surname { get; set; }

            private int _age;
            public int age {
                get { return _age; }
                set { _age = (value > 0 && value < 250) ? value : 0; }   
            }

            public double heigth {
                get { return heigth; }
                set { heigth = (value > 0 && value < 3) ? value : 0; }
            }
            
            public Person() : this("", "", 0, 0) { }
            public Person(string name, string surname) : this(name, surname, 0, 0) { }
            public Person(string name, string surname, double heigth) : this(name, surname, 0, heigth) { }
            public Person(string name, string surname, int age, double heigth)
            {
                this.name = name;
                this.surname = surname;
                this.age = age;
                this.heigth = heigth;
            }
            
            public string getFullName() {
                return this.name + " " + this.surname;
            }

            public void setAge(string age) {
                this.age = Convert.ToInt32(age);
            }
            public string getAge() {
                return this.age + " years";
            }

            public string getHeigth() {
                return this.heigth + " mtrs";
            }

        }
    }
}