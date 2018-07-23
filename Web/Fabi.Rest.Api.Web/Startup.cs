using AutoMapper;
using Fabi.Rest.Api.DataAccess.Context;
using Fabi.Rest.Api.DataAccess.InMemory;
using Fabi.Rest.Api.DataAccess.UnitOfWork;
using Fabi.Rest.Api.Domain.Legacy;
using Fabi.Rest.Api.Domain.Services;
using Fabi.Rest.Api.Logging.Legacy;
using Fabi.Rest.Api.Logging.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Fabi.Rest.Api.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAutoMapper();
            services.AddSwaggerGen(g => {
                g.SwaggerDoc("v1", new Info{
                   Title = "Fabis ASP DotNetCore REST Api for Testing",
                   Version = "v1" 
                });
            });
            DependencyRegistration(services);
            DatabaseContextCreation(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(s => {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Fabis ASP DotNetCore REST Api for Testing (v1)");
            });

            app.UseMvc();
        }

        private void DependencyRegistration(IServiceCollection services) 
        {
            services.AddSingleton<IRestApiLogger, RestApiLogger>();
        }

        private void DatabaseContextCreation(IServiceCollection services) 
        {
            var serviceProvider = services.BuildServiceProvider();
            var databaseOptions = new DbContextOptionsBuilder<SalesContext>()
                .UseInMemoryDatabase(databaseName: "Fabi_Rest_Api_Db")
                .Options;

            var salesContext = new SalesContext(databaseOptions, serviceProvider.GetService<IRestApiLogger>());
            salesContext.Customers.AddRange(CustomerInMemoryData.GetCustomerInMemoryData());
            salesContext.Apps.AddRange(AppInMemoryData.GetAppInMemoryData());
            salesContext.SaveChanges();
            services.AddSingleton<SalesContext>(salesContext);
        }
    }
}
