using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Fabi.Rest.Api.DataAccess.UnitOfWork;
using Fabi.Rest.Api.Domain.Dto;
using Fabi.Rest.Api.Domain.Services;
using Fabi.Rest.Api.Logging.Logging;

namespace Fabi.Rest.Api.Domain.Legacy
{
    public class CustomerService : ServiceBase, ICustomerService
    {
        public CustomerService(IRestApiLogger apiLogger, IUnitOfWork unitOfWork, IMapper mapper) : base(apiLogger, unitOfWork, mapper)
        {}
        public async Task<IEnumerable<CustomerDto>> LoadAllCustomersAsync()
        {
            var result = await _unitOfWork.CustomerRepository.LoadAllCustomers();
            return result.Select(s => Mapper.Map<CustomerDto>(s));
        }
    }
}