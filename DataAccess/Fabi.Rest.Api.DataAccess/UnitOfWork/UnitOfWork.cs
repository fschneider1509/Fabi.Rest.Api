using System;
using Fabi.Rest.Api.DataAccess.Context;
using Fabi.Rest.Api.DataAccess.InMemory;
using Fabi.Rest.Api.DataAccess.Legacy;
using Fabi.Rest.Api.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fabi.Rest.Api.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SalesContext _salesContext;
        public UnitOfWork() 
        {
            _salesContext = CreateSalesContext();
            _salesContext.Customers.AddRange(CustomerInMemoryData.GetCustomerInMemoryData());
            _salesContext.SaveChanges();
            CustomerRepository = new CustomerRepository(_salesContext);
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
                _salesContext?.Dispose();
            }  
        }

        private SalesContext CreateSalesContext()
        {
            var dbOptions = new DbContextOptionsBuilder<SalesContext>()
                .UseInMemoryDatabase(databaseName: "Fabi_Rest_Api_Db")
                .Options;
            return new SalesContext(dbOptions);
        }
    }
}