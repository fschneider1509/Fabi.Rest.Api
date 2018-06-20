using System.Collections.Generic;
using Fabi.Rest.Api.DataAccess.Models;

namespace Fabi.Rest.Api.DataAccess.InMemory
{
    public static class CustomerInMemoryData
    {
        public static IEnumerable<CustomerModel> GetCustomerInMemoryData()
        {
            yield return new CustomerModel
            {
                Id = 1,
                Name = "Apple Inc.",
                Address = "Infinite Loop Cupertino, CA 95014, USA",
                ContactPerson = "Tim Cook"
            };

            yield return new CustomerModel
            {
                Id = 2,
                Name = "Microsoft Corp.",
                Address = "One Microsoft Way Redmond, WA 98052-7329, USA",
                ContactPerson = "Satya Nadella"
            };

            yield return new CustomerModel
            {
                Id = 3,
                Name = "GitHub",
                Address = "88 Colin P Kelly Jr. St, USA",
                ContactPerson = "Nat Friedman"
            };

            yield return new CustomerModel
            {
                Id = 4,
                Name = "SAP SE",
                Address = "Dietmar-Hopp-Alee 16, Germany",
                ContactPerson = "Bill McDermott"
            };
        }
    }
}