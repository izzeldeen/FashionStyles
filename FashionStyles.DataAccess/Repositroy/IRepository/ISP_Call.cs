using Dapper;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace FashionStyles.DataAccess.Repositroy.IRepository
{
    public interface ISP_Call :IDisposable
    {
        T Single<T>(string procedurName, DynamicParameters param = null);

       void Execute(string procedurName, DynamicParameters param = null);

        T OneRecored<T> (string procedurName, DynamicParameters param = null);

        IEnumerable<T> List<T>(string procedurName, DynamicParameters param = null);

        Tuple<IEnumerable<T1>,IEnumerable<T2>> List<T1,T2>(string procedurName, DynamicParameters param = null);

    }
}
