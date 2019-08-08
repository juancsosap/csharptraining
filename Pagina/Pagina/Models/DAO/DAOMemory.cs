using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pagina.Models.DAO
{
    public class DAOMemoryPersona : DAO<Persona>
    {
        private List<Persona> data = new List<Persona>();
        private static DAOMemoryPersona instance = null;

        private DAOMemoryPersona()
        {
            data.Add(new Persona() { id = 1, nombre = "Juan", apellido = "Perez", edad = 20, email = "juan@uai.cl", direccion = "Providencia", tarjeta = "4770415897972386" });
            data.Add(new Persona() { id = 2, nombre = "José", apellido = "Lopez", edad = 30, email = "jose@uai.cl", direccion = "Providencia", tarjeta = "4770415897972386" });
            data.Add(new Persona() { id = 3, nombre = "Luis", apellido = "Gutierrez", edad = 40, email = "luis@uai.cl", direccion = "Providencia", tarjeta = "4770415897972386" });
            data.Add(new Persona() { id = 4, nombre = "Pepe", apellido = "Alvares", edad = 50, email = "pepe@uai.cl", direccion = "Providencia", tarjeta = "4770415897972386" });
        }

        public static DAOMemoryPersona getInstance()
        {
            if(instance == null)
            {
                instance = new DAOMemoryPersona();
            }
            return instance;
        }

        public void Crear(Persona p)
        {
            p.id = data.Select(per => per.id).Max() + 1;
            data.Add(p);
        }

        public Persona Obtener(int id)
        {
            return data.Where(p => p.id == id).Single();
        }

        public List<Persona> ObtenerTodas()
        {
            return data;
        }

        public void Actualizar(Persona p)
        {
            data.Remove(data.Where(d => d.id == p.id).Single());
            data.Add(p);
        }

        public void Borrar(Persona p)
        {
            data.Remove(data.Where(d => d.id == p.id).Single());
        }

    }
}