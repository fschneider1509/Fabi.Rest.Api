using System;
using AutoMapper;
using Fabi.Rest.Api.DataAccess.Context;
using Fabi.Rest.Api.Logging.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Fabi.Rest.Api.Web.Controllers
{
    public abstract class ApiBaseController : Controller
    {
        public ApiBaseController(IRestApiLogger apiLogger, IMapper mapper, SalesContext salesContext)
        {
            ApiLogger = apiLogger ?? throw new ArgumentNullException(nameof(apiLogger));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            SalesContext = salesContext ?? throw new ArgumentNullException(nameof(salesContext));
        }

        public IRestApiLogger ApiLogger { get; private set; } 

        public IMapper Mapper { get; private set; }

        public SalesContext SalesContext { get; private set; }
    }
}