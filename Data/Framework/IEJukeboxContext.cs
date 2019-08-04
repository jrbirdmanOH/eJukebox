using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using Domain;

namespace Data.Framework
{
    public interface IEJukeboxContext
    {
        IQueryable<T> Table<T>();
        T Get<T>(int id);
        T Get<T>(string id);
        T Get<T>(Date id);
        T Load<T>(int id);
        void ClearSession();
        void Save(DomainObject entity);
        void Refresh(DomainObject entity);
        void BulkSave(IEnumerable<DomainObject> entities);
        void Delete(DomainObject entity);
        IList<T> GetEntityFromStoredProcedure<T>(string procedure, params Parameter[] parameters);
        IList<T> GetScalarFromStoredProcedure<T>(string procedure, params Parameter[] parameters);
        IList<T> GetEntityFromFunction<T>(string function, params Parameter[] parameters);
        void ExecuteStoredProcedure(string procedure, params Parameter[] parameters);
        /// <summary>
        /// A statement transaction is for a single statement. If a statement transaction is nested in another transaction
        /// it does not cause a flush.
        /// </summary>
        ITransaction BeginStatementTransaction();
        bool AutoFlush { get; set; }
        void Flush();
        bool IsConnected { get; }

    }
}
