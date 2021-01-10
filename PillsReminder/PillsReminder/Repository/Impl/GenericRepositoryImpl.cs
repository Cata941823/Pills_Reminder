using PillsReminder.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PillsReminder.Data;
using AppContext = PillsReminder.Data.AppContext;

namespace PillsReminder.Repository.Impl
{
    public abstract class GenericRepositoryImpl<T> : GenericRepository<T> where T : class
    {
        protected readonly AppContext _context;
        protected readonly DbSet<T> _table;

        public GenericRepositoryImpl(AppContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void CreateRange(List<T> entities)
        {
            _table.AddRange(entities);
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }


        public T FindById(int id)
        {
            return _table.Find(id);
        }

        public List<T> GetAll()
        {
            return _table.ToList();
        }

        public IQueryable<T> GetAllQuery()
        {
            return _context.Set<T>();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }
    }
}
