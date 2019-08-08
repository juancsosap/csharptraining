namespace pooStarting
{
    public abstract class Person
    {
        private static int _count = 0;
        public static int quantity => Person._count;

        public readonly int id;

        private string _name, _surname, _type;

        public string name { get => this._name; set => this._name = value; }
        public string surname { get => this._surname.ToUpper(); set => this._surname = value; }
        protected string type { get => this._type; set => this._type = value; }

        public abstract string info { get; }
        
        public Person() => Person._count++;
        public Person(int id, string name, string surname) : this()
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
        }
    }

    class Client : Person
    {
        private const string localType = "Client";

        private string _company;
        public string company { get => this._company; set => this._company = value; }

        public override string info => this.type + " : " + this.company + " : " + this.surname.ToUpper() + ", " + this.name;

        public Client(int id, string name, string surname, string company) : base(id, name, surname)
        {
            this.company = company;
            this.type = localType;
        }
        public Client(Person person, string company) : this(person.id, person.name, person.surname, company){}
    }

    class Employee : Person
    {
        private const string localType = "Employee";

        private string _role;
        public string role { get => this._role; set => this._role = value; }

        public override string info => this.type + " : " + this.surname.ToUpper() + ", " + this.name + " : " + this.role;

        public Employee(int id, string name, string surname, string role) : base(id, name, surname)
        {
            this.role = role;
            this.type = localType;
        }
        public Employee(Person person, string role) : this(person.id, person.name, person.surname, role) { }
    }

}
