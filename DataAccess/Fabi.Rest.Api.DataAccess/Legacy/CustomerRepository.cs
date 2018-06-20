using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fabi.Rest.Api.DataAccess.Context;
using Fabi.Rest.Api.DataAccess.Models;
using Fabi.Rest.Api.DataAccess.Repositories;
using Fabi.Rest.Api.Logging.Logging;

namespace Fabi.Rest.Api.DataAccess.Legacy
{
    public class CustomerRepository : RepositoryBase, ICustomerRepository
    {
        private readonly SalesContext _salesContext;

        public CustomerRepository(SalesContext salesContext, IRestApiLogger apiLogger) : base(apiLogger)
        {
            _salesContext = salesContext ?? throw new ArgumentNullException(nameof(salesContext));
        }

        public Task<IEnumerable<CustomerModel>> LoadAllCustomers()
        {
            return Task.FromResult<IEnumerable<CustomerModel>>(result: _salesContext.Customers.OrderBy(o => o.Name));
        }
    }
}