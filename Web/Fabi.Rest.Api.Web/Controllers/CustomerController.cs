using System.Threading.Tasks;
using System;
using Fabi.Rest.Api.Domain.Services;
using Fabi.Rest.Api.Logging.Logging;
using Microsoft.AspNetCore.Mvc;
using Fabi.Rest.Api.Domain.Legacy;
using Fabi.Rest.Api.DataAccess.UnitOfWork;
using AutoMapper;
using Fabi.Rest.Api.DataAccess.Context;

namespace Fabi.Rest.Api.Web.Controllers
{
    [Route("api/v1/customer")]
    public class CustomerController : ApiBaseController
    {
        public CustomerController(IRestApiLogger apiLogger, IMapper mapper, SalesContext salesContext) : base(apiLogger, mapper, salesContext)
        {}

        /// <summary>
        /// Get all available customers.
        /// </summary>
        /// <returns>List of customers.</returns>
        /// <response code="200">All customers were loaded successfully.</response>
        /// <response code="500">Error while loading all customers.</response>
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll() 
        {
            ApiLogger.Info("Getting all customers!");
            using(var customerService = new CustomerService(ApiLogger, new UnitOfWork(ApiLogger, SalesContext), Mapper))
            {
                try
                {
                    await Task.Delay(1000);
                    var customers = await customerService.LoadAllCustomersAsync();
                    return Ok(customers);
                } catch(Exception ex) 
                {
                    ApiLogger.Error("Error while getting all customers!", ex: ex);
                    return StatusCode(500);
                }
            }
        }
    }
}