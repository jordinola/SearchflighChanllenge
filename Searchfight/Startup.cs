using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
