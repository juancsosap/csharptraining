using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pagina.Models.DAO
{
    public class DAOEFPersona : DAO<Persona>
    {
        private AppDBContext db = new AppDBContext();

        public void Crear(Persona p)
        {
            db.Entry<Persona>(p).State = EntityState.Added;
            db.SaveChanges();

            //db.Personas.Add(p);
            //db.SaveChanges();
        }

        public Persona Obtener(int id)
        {
            return db.Personas.Find(id);
        }

        public List<Persona> ObtenerTodas()
        {
            return db.Personas.ToList();
        }

        public void Actualizar(Persona p)
        {
            db.Entry<Persona>(p).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Borrar(Persona p)
        {
            db.Entry<Persona>(p).State = EntityState.Deleted;
            db.SaveChanges();

            //db.Personas.Remove(p);
            //db.SaveChanges();
        }
        
    }

    public class DAOEF<T, C> : DAO<T> where T : class 
                                      where C : DbContext, new()
    {
        private C db = new C();

        public void Crear(T d)
        {
            db.Entry<T>(d).State = EntityState.Added;
            db.SaveChanges();
        }

        public T Obtener(int id)
        {
            return db.Set<T>().Find(id);
        }

        public List<T> ObtenerTodas()
        {
            return db.Set<T>().ToList();
        }

        public void Actualizar(T d)
        {
            db.Entry<T>(d).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Borrar(T d)
        {
            db.Entry<T>(d).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}