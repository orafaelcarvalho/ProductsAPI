using System;
using System.Data;

namespace ProductsAPI.Infra.DbSession
{
    public interface IDbSessionDapper : IDisposable
    {
        public IDbConnection Connection { get; }
    }
}
