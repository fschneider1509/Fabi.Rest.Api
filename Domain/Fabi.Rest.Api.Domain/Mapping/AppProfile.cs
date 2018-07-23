using AutoMapper;
using Fabi.Rest.Api.DataAccess.Models;
using Fabi.Rest.Api.Domain.Dto;

namespace Fabi.Rest.Api.Domain.Mapping
{
    public class AppProfile : Profile
    {
        public AppProfile() 
        {
            CreateMap<AppModel, AppDto>();
        }
    }
}