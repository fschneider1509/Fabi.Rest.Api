using Fabi.Rest.Api.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Fabi.Rest.Api.DataAccess.Context
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options) : base(options) 
        {

        }
        public DbSet<CustomerModel> Customers { get; set; } 
    }
}