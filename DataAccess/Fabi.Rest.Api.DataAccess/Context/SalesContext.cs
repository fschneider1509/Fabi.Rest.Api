using System;
using Fabi.Rest.Api.DataAccess.Models;
using Fabi.Rest.Api.Logging.Logging;
using Microsoft.EntityFrameworkCore;

namespace Fabi.Rest.Api.DataAccess.Context
{
    public class SalesContext : DbContextBase
    {
        public SalesContext(DbContextOptions<SalesContext> options, IRestApiLogger apiLogger) : base(options, apiLogger) 
        {}
        public DbSet<CustomerModel> Customers { get; set; } 
    }
}