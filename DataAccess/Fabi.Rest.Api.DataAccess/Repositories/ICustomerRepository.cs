namespace Fabi.Rest.Api.DataAccess.Repositories
{
    public interface ICustomerRepository
    {
         Task<IEnumerable<CustomerModel>> LoadAllCustomers();
    }
}