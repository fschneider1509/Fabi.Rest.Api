using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fabi.Rest.Api.DataAccess.Context;
using Fabi.Rest.Api.DataAccess.Models;
using Fabi.Rest.Api.DataAccess.Repositories;

namespace Fabi.Rest.Api.DataAccess.Legacy
{
    public class CustomerRepository : ICustomerRepository
    {
        private SalesContext _salesContext;
        public CustomerRepository(SalesContext salesContext) 
        {
            _salesContext = salesContext;
        }

        public Task<IEnumerable<CustomerModel>> LoadAllCustomers()
        {
            return Task.FromResult<IEnumerable<CustomerModel>>(result: _salesContext.Customers.OrderBy(o => o.Name));
        }
    }
}