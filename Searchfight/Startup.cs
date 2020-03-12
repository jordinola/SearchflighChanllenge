using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Searchfight.IServices;
using Searchfight.IServices.SearchEngineApis;
using Searchfight.IServices.SearchEnginesApiClients;
using Searchfight.IServices.SearchEnginesMappers;
using Searchfight.Services;
using Searchfight.Services.SearchEngineApis;
using Searchfight.Services.SearchEnginesApiClients;
using Searchfight.Services.SearchEnginesMappers;

namespace Searchfight
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

            services.AddTransient<ISearchEngineService, SearchEngineService>();
            services.AddTransient<ISearchEngineApiService, SearchEngineApiService>();
            services.AddTransient<IBingApiResultService, BingApiResultService>();
            services.AddTransient<IGoogleApiResultService, GoogleApiResultService>();

            services.AddSingleton<IBingSearchEngineClient, BingSearchEngineClient>();
            services.AddSingleton<IGoogleSearchEngineClient, GoogleSearchEngineClient>();

            services.AddSingleton<ISearchEngineMatchMapper, SearchEngineMatchMapper>();
;
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Searchfight", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Searchfight v1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
