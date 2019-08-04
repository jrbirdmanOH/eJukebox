using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Castle.Core.Internal;
using Common;
using Data.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Data
{
    public abstract class Repository 
    {
        public readonly DbContext context;

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

        //internal IQueryable<T> Table<T>() where T : class
        internal DbSet<T> Table<T>() where T : class
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

        //Temporarily commented out for eJukebox usage
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

        protected IList<T> GetEntityFromStoredProcedure<T>(string name, params Parameter[] parameters) where T : class
        {
            return GetEntityFromDbProgramming<T>(QueryType.StoredProc, name, parameters);
        }

        protected IList<T> GetEntityFromFunction<T>(string function, params Parameter[] parameters) where T : class
        {
            return GetEntityFromDbProgramming<T>(QueryType.Function, function, parameters);
        }

        protected IList<T> GetScalarFromStoredProcedure<T>(string name, params Parameter[] parameters)
        {
            var query = new Query(name, QueryType.StoredProcWithValues, parameters);
            DbCommand cmd = context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = query.Sql;
            cmd.CommandType = CommandType.Text;
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }

            var result = cmd.ExecuteScalar();
            return new List<T>() { (T)result };
        }

        private IList<T> GetEntityFromDbProgramming<T>(QueryType queryType, string name, params Parameter[] parameters) where T : class
        {
            var query = new Query(name, queryType, parameters);
            if (query.Parameters != null)
            {
                return context.Set<T>().FromSql(query.Sql, query.Parameters).ToList();
            }
            else
            {
                return context.Set<T>().FromSql(query.Sql).ToList();
            }
        }

        protected Parameter<T> Parameter<T>(T value)
        {
            return new Parameter<T>(value);
        }
    }
}
