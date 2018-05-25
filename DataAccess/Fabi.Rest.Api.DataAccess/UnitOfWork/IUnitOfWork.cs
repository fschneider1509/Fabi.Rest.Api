using Fabi.Rest.Api.DataAccess.Repositories;

namespace Fabi.Rest.Api.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
         ICustomerRepository CustomerRepository { get; set; }
    }
}