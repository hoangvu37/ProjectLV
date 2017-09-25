using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.Objects;

namespace LV.Core.DAL.Base
{
    public delegate void OnBeforeSave(object obj);
    public delegate void OnSaveException(Exception exception);
    public delegate void OnSavechanged(object obj);

    public interface IUnitOfWork : IDisposable
    {
        OnBeforeSave BeforeSave { get; set; }
        OnSaveException SaveException { get; set; }
        //OnSavechanged SaveChangedEvent { get; set; }

        string UserID { get; set; }
        string BUID { get; set; }

        void SaveChanges();
        void SaveAndContinue();
        void BeginTransaction();

        void BeginTransaction(IsolationLevel level);

        void RollBackTransaction();

        void ReleaseCurrentTransaction(DbTransaction transaction);

        bool IsInTransaction { get; }

        bool CommitTransaction();

        bool CommitTransaction(bool hasError);

        bool CommitTransaction(System.Data.Entity.Core.Objects.SaveOptions saveOptions);

        bool CommitTransaction(bool hasError, System.Data.Entity.Core.Objects.SaveOptions saveOptions);

        object Orm { get; }
    }
}
