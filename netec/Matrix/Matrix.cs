using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
private --> Solo dentro de la Clase
protected --> Dentro de la Clase y sus hijos
internal --> Dentro del Namespace
protected internal --> Dentro de la Clase, sus hijos ó dentro del NS
public ---> En todos lados

NS A ---> Papa ---> protected internal trabajo
NS B ---> Hijo : Papa
NS A ---> Mama
*/

namespace Matrix
{
    class Matrix
    {
        protected int[,] matrix;
        protected int rows, columns;

        public Matrix() : this(3, 3, 0) { }

        public Matrix(int defaultValue) : this(3, 3, defaultValue) { }

        public Matrix(int rows, int columns) : this(rows, columns, 0) { }

        public Matrix(int rows, int columns, int defaultValue)
        {
            this.matrix = new int[rows,columns];
            for(int r=0; r<rows; r++)
            {
                for(int c=0; c<columns; c++)
                {
                    this.matrix[r, c] = defaultValue;
                }
            }
            this.rows = rows;
            this.columns = columns;
        }

        public Matrix(int[,] value)
        {
            this.matrix = value;
            this.rows = value.GetUpperBound(0) + 1;
            this.columns = value.GetUpperBound(1) + 1;
        }

        public Matrix(Matrix m) : this(m.ToArray()) { }

        public int[,] ToArray() => this.matrix;

        public override string ToString()
        {
            StringBuilder text = new StringBuilder("",1000);
            for (int r = 0; r < this.rows; r++)
            {
                for (int c = 0; c < this.columns; c++)
                {
                    text.Append(this.matrix[r, c] + "\t"); // 1000 2000 4000 8000
                }
                text.Append("\n");
            }
            return text.ToString();
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            int[,] m1A = m1.ToArray();
            int[,] m2A = m2.ToArray();
            int rows = m1A.GetUpperBound(0) + 1;
            int columns = m1A.GetUpperBound(1) + 1;
            int[,] resultA = new int[rows, columns];
            try
            {
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        resultA[r, c] = m1A[r, c] + m2A[r, c];
                    }
                }
            }
            catch(System.IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new Matrix(resultA);
        }

    }

}

/*
        Person
            virtual Conocer

        Client : Person
            override Conocer

        Employee : Person
            new Conocer

        Person juan = new Client()
        Person pepe = new Employee()
            juan.Conocer()   /Client.Conocer()
            pepe.Conocer()   /Person.Conocer()
        */
