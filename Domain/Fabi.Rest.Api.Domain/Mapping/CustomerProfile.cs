using AutoMapper;
using Fabi.Rest.Api.DataAccess.Models;
using Fabi.Rest.Api.Domain.Dto;

namespace Fabi.Rest.Api.Domain.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile() 
        {
            CreateMap<CustomerModel, CustomerDto>();
        }
    }
}