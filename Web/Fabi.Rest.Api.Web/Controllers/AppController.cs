using System.Threading.Tasks;
using AutoMapper;
using Fabi.Rest.Api.DataAccess.Context;
using Fabi.Rest.Api.Logging.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Fabi.Rest.Api.Web.Controllers
{
    [Route("api/v1/apps")]
    public class AppController : ApiBaseController
    {
        public AppController(IRestApiLogger apiLogger, IMapper mapper, SalesContext salesContext) : base(apiLogger, mapper, salesContext)
        {}

        /// <summary>
        /// Get all available apps.
        /// </summary>
        /// <returns>List of apps.</returns>
        /// <response code="200">All apps were loaded successfully.</response>
        /// <response code="500">Error while loading all apps.</response>
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll() 
        {
            ApiLogger.Info("Getting all available apps!");
            await Task.Delay(2000);
            return await Task.FromResult(Ok());
        }
    }
}