using Fabi.Rest.Api.DataAccess.UnitOfWork;
using Fabi.Rest.Api.Domain.Legacy;
using Fabi.Rest.Api.Domain.Services;
using Fabi.Rest.Api.Logging.Legacy;
using Fabi.Rest.Api.Logging.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Fabi.Rest.Api.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
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
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
        }
    }
}
