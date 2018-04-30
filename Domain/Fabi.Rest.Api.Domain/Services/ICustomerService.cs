using System.Collections.Generic;
using System.Threading.Tasks;
using Fabi.Rest.Api.Domain.Dto;

namespace Fabi.Rest.Api.Domain.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> LoadAllCustomersAsync();
    }
}