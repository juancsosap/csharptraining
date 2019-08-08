using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BlogSite.Models
{
    public interface IGenericRepository<T> where T : class
    {
        // Create
        T Add(T entity, bool save = true);

        // Retrive
        T Get(Expression<Func<T, bool>> predicate);
        bool Exist(Expression<Func<T, bool>> predicate);
        List<T> GetAll(Func<T, Object> selector, int limit, int offset);
        List<T> FindBy(Expression<Func<T, bool>> predicate);

        // Update
        void Edit(T entity, bool save = true);

        // Delete
        T Delete(T entity, bool save = true);

        void Save();
        void Dispose();
    }

    public class GenericRepository<C, T> : IGenericRepository<T> 
           where T : class 
           where C : DbContext, new()
    {
        protected C db = null;

        public GenericRepository(C db) => this.db = db;
        public GenericRepository() : this(new C()) { }

        // Create
        public T Add(T entity, bool save = true)
        {
            T model = db.Set<T>().Add(entity);
            if (save) this.Save();
            return model;
        }

        // Retrive
        public T Get(Expression<Func<T, bool>> predicate) => db.Set<T>().Where(predicate).FirstOrDefault();
        public bool Exist(Expression<Func<T, bool>> predicate) => db.Set<T>().Where(predicate).FirstOrDefault() != null;
        public List<T> GetAll(Func<T, Object> selector, int limit, int offset) => db.Set<T>().OrderBy(selector).Skip(offset).Take(limit).ToList();
        public List<T> FindBy(Expression<Func<T, bool>> predicate) => db.Set<T>().Where(predicate).ToList();

        // Update
        public void Edit(T entity, bool save = true)
        {
            db.Entry(entity).State = EntityState.Modified;
            if (save) this.Save();
        }

        // Delete
        public T Delete(T entity, bool save = true)
        {
            T model = db.Set<T>().Remove(entity);
            if (save) this.Save();
            return model;
        }

        public void Save() => db.SaveChanges();
        public void Dispose() => db.Dispose();
    }

    public class IndexableGenericRepository<C, T> : GenericRepository<C, T> 
           where T : class, Indexable 
           where C : DbContext, new()
    {
        public IndexableGenericRepository(C db) : base(db) { }
        public IndexableGenericRepository() : base() { }
        
        // Retrive
        public T GetById(int Id) => db.Set<T>().FirstOrDefault(e => e.Id == Id);
        public bool Exist(int Id) => this.Exist(e => e.Id == Id);
        public List<T> GetAll(int limit, int offset) => this.GetAll(e => e.Id, limit, offset);

        // Delete
        public T Delete(int Id, bool save = true) => this.Delete(this.GetById(Id), save);
    }

}

