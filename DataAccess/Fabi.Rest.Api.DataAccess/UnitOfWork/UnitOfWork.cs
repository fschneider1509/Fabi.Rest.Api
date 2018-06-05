using System;
using Fabi.Rest.Api.DataAccess.Context;
using Fabi.Rest.Api.DataAccess.Legacy;
using Fabi.Rest.Api.DataAccess.Repositories;

namespace Fabi.Rest.Api.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork(SalesContext salesContext) 
        {
            CustomerRepository = new CustomerRepository(salesContext);
        }

        public ICustomerRepository CustomerRepository { get; set; }

        public void Dispose()
        {
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