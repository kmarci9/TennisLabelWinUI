using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisLabel.Data;

namespace TennisLabel.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected TennisDbContext database;

        public Repository(TennisDbContext context)
        {
            database = context;
        }

        public abstract int Create(T item);


        public bool Delete(int id)
        {
            T entity = GetOne(id);
            if (entity == null) return false;
            database.Set<T>().Remove(entity);
            database.SaveChanges();
            return true;
        }

        public void Detach(T entity)
        {
            database.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }

        public abstract T GetOne(int id);

        public IQueryable<T> GetTable()
        {
            return database.Set<T>().AsQueryable();
        }

        public abstract void Update(T item);



    }
}
