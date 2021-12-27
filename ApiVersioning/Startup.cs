using ApiVersioning.Infrastructure.Options;
using ApiVersioning.Infrastructure.Options.SwaggerGen;
using ApiVersioning.Infrastructure.ServiceCollectionExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace ApiVersioning
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddTransient<IConfigureOptions<MvcOptions>, ConfigureMvc>()
                .AddControllers();

            services.TryAddEnumerable(ServiceDescriptor.Transient<IApiDescriptionProvider, SubgroupDescriptionProvider>());

            
            services
                .AddTransient<IConfigureOptions<ApiVersioningOptions>, ConfigureApiVersioning>()
                .AddApiVersioning();
            
            services
                .AddTransient<IConfigureOptions<ApiExplorerOptions>, ConfigureApiExplorer>()
                .AddVersionedApiExplorer();
            
            services
                .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGen>()
                .AddTransient<IConfigureOptions<SwaggerOptions>, ConfigureSwagger>()
                .AddTransient<IConfigureOptions<SwaggerUIOptions>, ConfigureSwaggerUi>()
                .AddSwaggerGen();
            
            services
                .AddDomain();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}