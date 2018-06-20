using System;
using AutoMapper;
using Fabi.Rest.Api.Logging.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Fabi.Rest.Api.Web.Controllers
{
    public abstract class ApiBaseController : Controller
    {
        public ApiBaseController(IRestApiLogger apiLogger, IMapper mapper)
        {
            ApiLogger = apiLogger ?? throw new ArgumentNullException(nameof(apiLogger));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IRestApiLogger ApiLogger { get; private set; } 

        public IMapper Mapper { get; private set; }
    }
}