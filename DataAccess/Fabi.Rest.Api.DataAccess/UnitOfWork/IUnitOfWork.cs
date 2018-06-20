using System;
using Fabi.Rest.Api.DataAccess.Repositories;

namespace Fabi.Rest.Api.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
         ICustomerRepository CustomerRepository { get; set; }
    }
}