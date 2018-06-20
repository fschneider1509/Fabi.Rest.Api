using System.Collections.Generic;
using System.Threading.Tasks;
using Fabi.Rest.Api.DataAccess.Models;

namespace Fabi.Rest.Api.DataAccess.Repositories
{
    public interface ICustomerRepository
    {
         Task<IEnumerable<CustomerModel>> LoadAllCustomers();
    }
}