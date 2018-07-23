using System;
using Fabi.Rest.Api.DataAccess.Context;
using Fabi.Rest.Api.DataAccess.InMemory;
using Fabi.Rest.Api.DataAccess.Legacy;
using Fabi.Rest.Api.DataAccess.Repositories;
using Fabi.Rest.Api.Logging.Logging;
using Microsoft.EntityFrameworkCore;

namespace Fabi.Rest.Api.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SalesContext _salesContext;
        private readonly IRestApiLogger _apiLogger;

        public UnitOfWork(IRestApiLogger apiLogger, SalesContext salesContext) 
        {
            _apiLogger = apiLogger ?? throw new ArgumentNullException(nameof(apiLogger));
            _salesContext = salesContext ?? throw new ArgumentNullException(nameof(salesContext));
            InitializeRepositories();
        }

        public ICustomerRepository CustomerRepository { get; set; }
        public IAppRepository AppRepository { get; set; }

        public void Dispose()
        {
            _apiLogger.Info($"Disposing the {this.GetType().ToString()} ...");
            Dispose(true);  
            GC.SuppressFinalize(this);
        }

        private void InitializeRepositories() 
        {
            CustomerRepository = new CustomerRepository(_salesContext, _apiLogger);
            AppRepository = new AppRepository(_salesContext, _apiLogger);
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