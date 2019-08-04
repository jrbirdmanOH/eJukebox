using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Framework
{

    public interface ITransaction : IDisposable
    {
        ITransaction Parent { get; }
        bool IsActive { get; }
        bool WasRolledBack { get; }
        bool WasCommitted { get; }
        void Commit();
        void Rollback();
        void Rollback(bool suppressExceptions);
    }
}
