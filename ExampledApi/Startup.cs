using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using ApiVersioning.Infrastructure.Options.SwaggerGen;
using ExampledApi.Controllers.Auction;
using ExampledApi.Controllers.Infrastructure;
using ExampledApi.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ExampledApi
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

            services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    // use json serialization as strings for increased readability
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                });
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Auction API", 
                    Version = "v1",
                    Description = "The set of supported endpoints for integrating with the amazing FOOBAR auction site®"
                });
                
                // Toggle xml comments in output for swagger documentation
                var xmlFilename = $"{typeof(Program).Assembly.GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                
                // Use limited namespacing
                c.CustomSchemaIds(x => x.FullName?.StripUntil('.', 3));

                // c.SupportNonNullableReferenceTypes(); // Sets Nullable flags appropriately.              
                // c.UseAllOfToExtendReferenceSchemas(); // Allows $ref enums to be nullable
                // c.UseAllOfForInheritance();  // Allows $ref objects to be nullable
                // c.DocumentFilter<RemoveDefaultApiVersionRouteDocumentFilter>();
                // c.SchemaFilter<AddSwaggerRequiredSchemaFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExampledApi v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
