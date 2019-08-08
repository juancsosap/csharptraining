using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestedApp.Models.DAO
{
    public class DAOMemory<T> : IDAO<T> where T : class, IIndexable
    {
        private List<T> db = new List<T>();

        public T Create(T d)
        {
            d.id = db.Count == 0 ? 1 : db.Select(t => t.id).Max() + 1;
            db.Add(d);
            return d;
        }

        public T Retrive(int id)
        {
            return db.Where(t => t.id == id).Single();
        }

        public List<T> RetriveAll()
        {
            return db;
        }

        public List<T> RetriveMany(int limit, int offset)
        {
            return db.Skip(offset).Take(limit).ToList();
        }

        public T Update(T d)
        {
            db.Remove(this.Retrive(d.id));
            db.Add(d);
            return d;
        }

        public T Delete(int id)
        {
            T dato = this.Retrive(id);
            db.Remove(dato);
            return dato;
        }
    }
}