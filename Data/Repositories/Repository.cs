using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Data.Framework;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public abstract class Repository
    {
        private readonly DbContext context;

        protected Repository(DbContext context)
        {
            this.context = context;
        }

        internal virtual void Save<T>(T updated, int key) where T : class
        {
            var existing = this.Get<T>(key);
            if (existing != null)
            {
                context.Entry(existing).CurrentValues.SetValues(updated);
                context.SaveChanges();
            }
        }

        internal virtual void Save<T>(T updated, int key1, int key2) where T : class
        {
            var existing = this.Get<T>(key1, key2);
            if (existing != null)
            {
                context.Entry(existing).CurrentValues.SetValues(updated);
                context.SaveChanges();
            }
        }

        internal virtual void Save<T>(T entity, int key, bool clearSession)
        {
            throw new NotImplementedException();
        }

        //NOT IN NH REPO
        internal virtual T Add<T>(T item) where T : class
        {
            context.Set<T>().Add(item);
            context.SaveChanges();
            return item;
        }

        protected void Refresh<T>(T entity)
        {
            throw new NotImplementedException();
        }

        internal IQueryable<T> Table<T>() where T : class
        {
            return context.Set<T>();
            //return context.Set<T>().AsNoTracking();
        }

        internal T Get<T>(int id) where T : class
        {
            return context.Set<T>().Find(id);
        }

        //NOT IN NH REPO
        internal T Get<T>(int id1, int id2) where T : class
        {
            return context.Set<T>().Find(id1, id2);
        }

        internal T Get<T>(string id) where T : class
        {
            return context.Set<T>().Find(id);
        }

        //internal T Get<T>(Date id) where T : class
        //{
        //    return context.Set<T>().Find(id);
        //}

        internal T Load<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }

        //public ITransaction BeginStatementTransaction()
        //{
        //    throw new NotImplementedException();
        //}

        internal virtual void BulkSave<T>(IEnumerable<T> entities) where T : class
        {
            throw new NotImplementedException();
        }

        protected IList<T> GetEntityFromStoredProcedure<T>(string name, params Parameter[] parameters)
        {
            throw new NotImplementedException();
        }

        protected IList<T> GetEntityFromFunction<T>(string name, params Parameter[] parameters)
        {
            throw new NotImplementedException();
        }

        protected Parameter<T> Parameter<T>(T value)
        {
            return new Parameter<T>(value);
        }

        #region New Methods

        //internal virtual IEnumerable<T> Get<T>(
        //    Expression<Func<T, bool>> filter = null,
        //    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //    string includeProperties = "") where T : class
        //{
        //    IQueryable<T> query = this.context.Set<T>();

        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }

        //    foreach (var includeProperty in includeProperties.Split
        //        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        query = query.Include(includeProperty);
        //    }

        //    if (orderBy != null)
        //    {
        //        return orderBy(query).ToList();
        //    }
        //    else
        //    {
        //        return query.ToList();
        //    }
        //}

        //internal virtual IEnumerable<T> GetAll<T>() where T : class
        //{
        //    return context.Set<T>().ToList();
        //}

        #endregion

    }
}
