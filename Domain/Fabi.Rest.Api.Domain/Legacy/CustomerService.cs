using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fabi.Rest.Api.Domain.Dto;
using Fabi.Rest.Api.Domain.Services;
using Fabi.Rest.Api.Logging.Logging;

namespace Fabi.Rest.Api.Domain.Legacy
{
    public class CustomerService : ICustomerService
    {
        private readonly IRestApiLogger _apiLogger;
        public CustomerService(IRestApiLogger apiLogger)
        {
            _apiLogger = apiLogger ?? throw new ArgumentNullException(nameof(apiLogger));
        }

        public async Task<IEnumerable<CustomerDto>> LoadAllCustomersAsync()
        {
            var customers = new List<CustomerDto>
            {
                new CustomerDto 
                {
                    Id = 4711,
                    Name = "Apple Store Munich",
                    Address = "Rosenstraße 1, 80331 München",
                    ContactPerson = "Tim Cook"
                },
                new CustomerDto 
                {
                    Id = 1509,
                    Name = "Microsoft Deutschland",
                    Address = "Walter-Gropius-Straße 5, 80807 München",
                    ContactPerson = "Satya Nadella"
                }
            };
            return await Task.FromResult<IEnumerable<CustomerDto>>(customers);
        }
    }
}