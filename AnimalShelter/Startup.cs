using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AnimalShelter.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace AnimalShelter
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

            services.AddDbContext<AnimalShelterContext>(opt =>
                opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
                { 
									Title = "AnimalShelter", 
									Version = "v1",
									Description = "API for adding animals to a Shelter" 
                });
									var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
									var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
									c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
					app.UseSwagger();
					app.UseSwaggerUI(c => 
					{
						c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnimalShelter API v1");
						c.RoutePrefix = string.Empty;
				  });
						if (env.IsDevelopment())
						{
								app.UseDeveloperExceptionPage();
								
						}

						// app.UseHttpsRedirection();

						app.UseRouting();

						app.UseAuthorization();

						app.UseEndpoints(endpoints =>
						{
								endpoints.MapControllers();
						});
        }
    }
}
