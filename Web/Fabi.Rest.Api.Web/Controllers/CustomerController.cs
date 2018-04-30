using System.Collections.Generic;
using System.Threading.Tasks;
using Fabi.Rest.Api.Domain.Dto;
using Fabi.Rest.Api.Logging.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Fabi.Rest.Api.Web.Controllers
{
    [Route("api/v1/customer")]
    public class CustomerController : ApiBaseController
    {
        public CustomerController(IRestApiLogger apiLogger) : base(apiLogger)
        {}

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll() 
        {
            ApiLogger.Info("Getting all customers!");
            var customers = new List<CustomerDto>
            {
                new CustomerDto 
                {
                    Id = 4711,
                    Name = "Apple Store Munich",
                    Address = "Rosenstraße 1, 80331 München",
                    ContactPerson = "Tim Cook"
                },
                new CustomerDto 
                {
                    Id = 1509,
                    Name = "Microsoft Deutschland",
                    Address = "Walter-Gropius-Straße 5, 80807 München",
                    ContactPerson = "Satya Nadella"
                }
            };
            return await Task.FromResult<IActionResult>(new ObjectResult(customers));
        }
    }
}