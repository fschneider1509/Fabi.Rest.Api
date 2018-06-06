using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Fabi.Rest.Api.DataAccess.UnitOfWork;
using Fabi.Rest.Api.Domain.Dto;
using Fabi.Rest.Api.Domain.Services;
using Fabi.Rest.Api.Logging.Logging;

namespace Fabi.Rest.Api.Domain.Legacy
{
    public class CustomerService : ICustomerService
    {
        private readonly IRestApiLogger _apiLogger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IRestApiLogger apiLogger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _apiLogger = apiLogger ?? throw new ArgumentNullException(nameof(apiLogger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<CustomerDto>> LoadAllCustomersAsync()
        {
            var result = await _unitOfWork.CustomerRepository.LoadAllCustomers();
            return result.Select(s => Mapper.Map<CustomerDto>(s));
        }
    }
}