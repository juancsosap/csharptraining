using System;

namespace des1_app_lm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Name : ");
            String name = Console.ReadLine();

            Console.WriteLine("Surname : ");
            String surname = Console.ReadLine();

            Console.WriteLine("Age : ");
            int age = int.Parse(Console.ReadLine());

            Person persona = new Person(name, surname, age);
            
            Console.WriteLine("Name : " + persona.getName() + " " + persona.surname);
            Console.WriteLine("You are " + persona.age + " years old");
        }

        static void imprimir(string msg) => Console.WriteLine(msg);
    }

    class Person
    {
        private string _name;
        public string getName() => this._name;
        public void setName(string name) => this._name = (name.Length > 3) ? name : _name;

        private string _surname;
        public string surname { get => _surname.ToUpper(); set => _surname = value; }

        private int _age { get; set; }
        public int age { get => _age; set => _age = (value >= 0) ? value : _age; }

        public Person(string name, string surname, int age)
        {
            this.setName(name);
            this.surname = surname;
            this.age = age;
        }

    }
}
