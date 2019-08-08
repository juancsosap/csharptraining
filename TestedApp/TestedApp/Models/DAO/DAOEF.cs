using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestedApp.Models.DAO
{
    public class DAOEF<T, C> : IDAO<T> where T : class, IIndexable
                                      where C : DbContext, new()
    {
        private C db = new C();

        public T Create(T d)
        {
            T dato = db.Set<T>().Add(d);
            db.SaveChanges();
            return dato;
        }

        public T Retrive(int id)
        {
            return db.Set<T>().Find(id);
        }

        public List<T> RetriveAll()
        {
            return db.Set<T>().ToList();
        }

        public List<T> RetriveMany(int limit, int offset)
        {
            return db.Set<T>().OrderBy(d => d.id).Skip(offset).Take(limit).ToList();
        }

        public T Update(T d)
        {
            db.Entry<T>(d).State = EntityState.Modified;
            db.SaveChanges();
            return d;
        }

        public T Delete(int id)
        {
            T dato = this.Retrive(id);
            db.Entry<T>(dato).State = EntityState.Deleted;
            db.SaveChanges();
            return dato;
        }
    }
}