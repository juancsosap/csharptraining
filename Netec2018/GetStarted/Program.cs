using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetStarted
{
    class Program
    {
        private String dato = "valor";
        private static String data = "valor";

        static void Main(string[] args)
        {

            #region Request Info

            Console.Write("Nombre: ");
            String nombre = Console.ReadLine();

            Console.Write("Edad: ");
            byte edad = Byte.Parse(Console.ReadLine());

            Console.Write("Cargo: ");
            String cargo = Console.ReadLine();

            #endregion

            Persona persona = new Empleado(cargo, nombre, edad);

            PersonaStruct persona2 = new PersonaStruct();

            Console.WriteLine(persona2.Nombre);

            persona.Nombre = "Luis";

            Console.WriteLine(persona.descripcion("-"));
            Console.WriteLine(persona.descripcion());

            Console.WriteLine(saludo());
            Console.WriteLine(new Program().saluda());
            Console.WriteLine(new Program().dato);

            Console.WriteLine(data);

            Ciudades ciudades = Ciudades.GetInstance();

            for(int i = 0; i<ciudades.valores.Length/2; i++)
            {
                Console.WriteLine(ciudades.valores[i, 0] + ":" + ciudades.valores[i, 1]);
            }
            
            Console.ReadKey();
        }

        private String saluda()
        {
            return dato + Program.data;
        }

        private static String saludo()
        {
            return data + (new Program()).dato;
        }

    }

    class Persona
    {
        private String nombre;
        public String Nombre {
            set => this.nombre = value;
            get => this.nombre;
        }

        private Byte edad;
        public Byte Edad
        {
            set => this.edad = value > 150 ? (Byte) 150 : value;
            get => this.edad;
        }

        public Persona() : this("", 0) { }
        public Persona(String nombre, Byte edad)
        {
            this.Nombre = nombre;
            this.Edad = edad;
        }

        public String descripcion() => this.descripcion(":");
        public virtual String descripcion(String delimitador) => this.Nombre + delimitador + this.Edad;

    }

    struct PersonaStruct
    {
        private String nombre;
        public String Nombre
        {
            set => this.nombre = value;
            get => this.nombre;
        }

        private Byte edad;
        public Byte Edad
        {
            set => this.edad = value > 150 ? (Byte)150 : value;
            get => this.edad;
        }

        public String descripcion() => this.descripcion(":");
        public String descripcion(String delimitador) => this.Nombre + delimitador + this.Edad;

    }

    class Empleado : Persona
    {
        private String cargo;

        public Empleado(String cargo, String nombre, Byte edad) : base(nombre, edad) => this.cargo = cargo;

        public new String descripcion()
        {
            return base.descripcion() + ":" + this.cargo;
        }
        public override String descripcion(String delimitador)
        {
            return base.descripcion(delimitador) + delimitador + this.cargo;
        }
    }

    class Ciudades
    {
        public String[,] valores = new String[5,2];

        private static Ciudades instance = null;

        private Ciudades()
        {
            valores[0, 0] = "RM";
            valores[0, 1] = "Santiago";

            valores[1, 0] = "Tarapaca";
            valores[1, 1] = "Arica";

            valores[2, 0] = "Los Lagos";
            valores[2, 1] = "Osorno";

            valores[3, 0] = "BioBio";
            valores[3, 1] = "Concepcion";

            valores[4, 0] = "Valparaiso";
            valores[4, 1] = "Viña";
        }

        public static Ciudades GetInstance()
        {
            if(instance == null)
            {
                instance = new Ciudades();
            }
            return instance;
        }

    }

}
