using System.Threading.Tasks;
using System;
using Fabi.Rest.Api.Domain.Services;
using Fabi.Rest.Api.Logging.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Fabi.Rest.Api.Web.Controllers
{
    [Route("api/v1/customer")]
    public class CustomerController : ApiBaseController
    {
        private readonly ICustomerService _customerService;
        public CustomerController(IRestApiLogger apiLogger, ICustomerService customerService) : base(apiLogger)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

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
            try
            {
                await Task.Delay(3000);
                var customers = await _customerService.LoadAllCustomersAsync();
                return Ok(customers);
            } catch(Exception ex) 
            {
                ApiLogger.Error("Error while getting all customers!", ex: ex);
                return StatusCode(500);
            }
        }
    }
}