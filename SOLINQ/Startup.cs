using Microsoft.EntityFrameworkCore;
using Elections.Data;
using Elections.Repositories;
using Microsoft.OpenApi.Models;

namespace Elections
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }
        public void ConfigureServices(IServiceCollection services) {
            string mysqlConnectionString = _configuration.GetConnectionString("MySql");
            services.AddDbContext<ElectionsDbContext>(options => options.UseSqlServer(mysqlConnectionString));

            services.AddSwaggerGen(swagger =>
              {
                  swagger.SwaggerDoc("v1", new OpenApiInfo
                  {
                      Version = "v1",
                      Title = "Elections API"
                  });
              });

            services
                .AddScoped<IDashboardRepository, DashboardRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (!env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app
              .UseSwagger()
              .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Elections"));

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
        }

    }
}
