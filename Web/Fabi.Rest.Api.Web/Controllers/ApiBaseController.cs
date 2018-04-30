using System;
using Fabi.Rest.Api.Logging.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Fabi.Rest.Api.Web.Controllers
{
    public abstract class ApiBaseController : Controller
    {
        public ApiBaseController(IRestApiLogger apiLogger)
        {
            ApiLogger = apiLogger ?? throw new ArgumentNullException(nameof(apiLogger));
        }

        public IRestApiLogger ApiLogger { get; private set; } 
    }
}