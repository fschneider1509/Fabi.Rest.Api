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
    public class AppService : ServiceBase, IAppService
    {
        public AppService(IRestApiLogger apiLogger, IUnitOfWork unitOfWork, IMapper mapper) : base(apiLogger, unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<AppDto>> LoadAllAppsAsync()
        {
            var result =  await _unitOfWork.AppRepository.LoadAllApps();
            return result.Select(s => Mapper.Map<AppDto>(s));
        }
    }
}