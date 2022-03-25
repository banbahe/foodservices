using foodbll.AutoMappers;
using foodbll.Products;
using fooddal.Products;
using foodbll.Orders;
using fooddal.Orders;
using fooddtos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.OpenApi.Models;

namespace foodservices
{
    public class Startup
    {
        readonly string MyCors = "MyCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Custom 
            services.Configure<FoodSettings>(Configuration.GetSection("FoodSettings"));
            services.AddSingleton<MainMapper>();
            services.AddSingleton<MongoDbContext>();
            services.AddScoped<ResponseModel>();
            services.AddScoped<IProductDal, ProductDal>();
            services.AddScoped<IProductBll, ProductBll>();
            services.AddScoped<IOrderDal, OrderDal>();
            services.AddScoped<IOrderBll, OrderBll>();
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyCors,
                builder =>
                {
                    builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                });
            });
            // startswagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Version = "v1.0",
                    Title = "FOODSERVICES API REST",
                    Description = "API REST IA INTERACTIVE BELIVE .DO ",
                    TermsOfService = new Uri("https://github.com/stbndev/foodservices"),
                    Contact = new OpenApiContact
                    {
                        Name = "Eban",
                        Email = "eban.blanquel@gmail.com",
                        Url = new Uri("https://github.com/stbndev"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "WTFPL",
                        Url = new Uri("https://github.com/stbndev/chambaap-rest/blob/main/WTFPL.txt"),
                    }
                });
                var filePath = System.IO.Path.Combine(AppContext.BaseDirectory, "QDM.CDM.API.xml");
                c.IncludeXmlComments(filePath);
            });
            // end swagger
            // End Custom

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyCors);

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1.0/swagger.json", "FOODSERVICES API v1.0");
                options.RoutePrefix = string.Empty;
                options.DocumentTitle = "FOODSERVICES API REST Documentation";
                options.DocExpansion(DocExpansion.List);
            });

            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
