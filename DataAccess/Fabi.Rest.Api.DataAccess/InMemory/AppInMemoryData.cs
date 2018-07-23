using System.Collections.Generic;
using Fabi.Rest.Api.DataAccess.Models;

namespace Fabi.Rest.Api.DataAccess.InMemory
{
    public static class AppInMemoryData
    {
        public static IEnumerable<AppModel> GetAppInMemoryData()
        {
            yield return new AppModel 
            {
                Id = 1,
                Name = "XXX Phone App",
                Description = "App for service order processing with XXX.",
                Version = "1.29.6.0",
                Icon = "",
                IsBeta = false,
                AppType = 1
            };

            yield return new AppModel 
            {
                Id = 2,
                Name = "XXX Phone App",
                Description = "App for service order processing with XXX.",
                Version = "1.29.7.0",
                Icon = "",
                IsBeta = true,
                AppType = 1
            };

            yield return new AppModel 
            {
                Id = 3,
                Name = "YYY Product Information",
                Description = "Product Information App.",
                Version = "2.2.5",
                Icon = "",
                IsBeta = false,
                AppType = 2
            };

            yield return new AppModel 
            {
                Id = 4,
                Name = "Foobar Lead Generation App",
                Description = "App for generating customer leads.",
                Version = "4.5",
                Icon = "",
                IsBeta = false,
                AppType = 3
            };

            yield return new AppModel 
            {
                Id = 5,
                Name = "Installed Base App",
                Description = "Manage the machines that belong to the customers machine park",
                Version = "0.5.1",
                Icon = "",
                IsBeta = true,
                AppType = 1
            };

            yield return new AppModel 
            {
                Id = 6,
                Name = "Inventory App",
                Description = "Invenoty management app for technicians.",
                Version = "1.0.0",
                Icon = "",
                IsBeta = true,
                AppType = 2
            };

        }
    }
}