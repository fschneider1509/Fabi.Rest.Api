using System;
using Fabi.Rest.Api.Logging.Logging;
using Microsoft.EntityFrameworkCore;

namespace Fabi.Rest.Api.DataAccess.Context
{
    public class DbContextBase : DbContext, IDisposable
    {
        public DbContextBase(DbContextOptions options, IRestApiLogger apiLogger) : base(options) 
        {
            ApiLogger = apiLogger ?? throw new ArgumentNullException(nameof(apiLogger));
        }

        protected IRestApiLogger ApiLogger { get; private set; }

        public override void Dispose()
        {
            base.Dispose();
            ApiLogger.Info($"Disposing the {this.GetType().ToString()} ...");
            Dispose(true);  
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing){  
            if (disposing){  
                foreach (var property in GetType().GetProperties())
                {
                    var disposable = property.GetValue(this) as IDisposable;
                    disposable?.Dispose();
                }
            }  
        }
    }
}