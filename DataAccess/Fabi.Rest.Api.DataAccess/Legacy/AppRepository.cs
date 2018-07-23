using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fabi.Rest.Api.DataAccess.Context;
using Fabi.Rest.Api.DataAccess.Models;
using Fabi.Rest.Api.DataAccess.Repositories;
using Fabi.Rest.Api.Logging.Logging;

namespace Fabi.Rest.Api.DataAccess.Legacy
{
    public class AppRepository : RepositoryBase, IAppRepository
    {
        private readonly SalesContext _salesContext;
        public AppRepository(SalesContext salesContext, IRestApiLogger apiLogger) : base(apiLogger)
        {
            _salesContext = salesContext ?? throw new ArgumentNullException(nameof(salesContext));
        }

        public Task<IEnumerable<AppModel>> LoadAllApps()
        {
            return Task.FromResult<IEnumerable<AppModel>>(result: _salesContext.Apps);
        }
    }
}