using System.Collections.Generic;
using System.Linq.Expressions;
using Mechanic.Infra;
using Mechanic.Infra.Interfaces;
using Mechanic.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Mechanic.Infra
{
    public class MechanicRepository<T> : IMechanicRepository<T>
        where T : class
    {
        private bool shareContext = false;

        private readonly ApplicationDbContext Context;
        private DbSet<T> entities;
        private string errorMessage = string.Empty;

        public MechanicRepository(ApplicationDbContext context)
        {
            Context = context;
            entities = Context.Set<T>();
        }

        protected DbSet<T> DbSet
        {
            get
            {
                return Context.Set<T>();
            }
        }

        public void Dispose()
        {
            if (shareContext && (Context != null))
                Context.Dispose();
        }

        public virtual IQueryable<T> All()
        {
            return DbSet.AsQueryable();
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable<T>();
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50)
        {
            int skipCount = index * size;
            var _resetSet = filter != null ? DbSet.Where(filter).AsQueryable() : DbSet.AsQueryable();
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public bool Contains(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public virtual T Find(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public virtual async Task<T> FindAsync(params object[] keys)
        {
            return await DbSet.FindAsync(keys);
        }

        public virtual T Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public virtual T Create(T TObject)
        {
            var newEntry = DbSet.Add(TObject);
            if (!shareContext)
                Context.SaveChanges();
            return newEntry.Entity;
        }

        public virtual async Task<T> CreateAsync(T TObject)
        {
            var newEntry = await DbSet.AddAsync(TObject);
            if (!shareContext)
                await Context.SaveChangesAsync();
            return newEntry.Entity;
        }

        public virtual int Count
        {
            get
            {
                return DbSet.Count();
            }
        }

        public virtual int Delete(T TObject)
        {
            DbSet.Remove(TObject);
            if (!shareContext)
                return Context.SaveChanges();
            return 0;
        }

        public virtual int Update(T TObject)
        {
            var entry = Context.Entry(TObject);
            DbSet.Attach(TObject);
            entry.State = EntityState.Modified;
            if (!shareContext)
                return Context.SaveChanges();
            return 0;
        }

        public virtual int Delete(Expression<Func<T, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                DbSet.Remove(obj);
            if (!shareContext)
                return Context.SaveChanges();
            return 0;
        }

        public virtual Task<int> UpdateAsync(T t)
        {
            var entry = Context.Entry(t);
            DbSet.Attach(t);
            entry.State = EntityState.Modified;
            if (!shareContext)
                return Context.SaveChangesAsync();
            return Task.FromResult(0);
        }
    }
}