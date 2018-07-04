using Fabi.Rest.Api.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Fabi.Rest.Api.DataAccess.Context
{
    public interface ISalesContext
    {
         DbSet<CustomerModel> Customers { get; set; } 
    }
}