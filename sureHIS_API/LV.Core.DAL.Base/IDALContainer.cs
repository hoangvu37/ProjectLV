using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LV.Core.DAL.Base
{
    public interface IDALContainer
    {
        IRepository Repository { get; }
        IUnitOfWork UnitOfWork { get; }
        void Close();
        void Dispose();
    }
}
