using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDbApiLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocsLearning
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
            // The following section is added to bind the appsettings.Json files to BookStoreDatabaseSettings
            //Example BookStoreDatabaseSettings object's ConnectionString property is populated with the 
            // BookStoreDatabaseSettings:Connectiontring property in appsettings.json.
            services.Configure<BookStoreDatabaseSettings>(
                Configuration.GetSection(nameof(BookStoreDatabaseSettings)));
            // requires using Microsoft.Extensions.Options for Ioptions
            //The interface IBookstoreDatabaseSettings is registered in DI with a Singleton Service LifeTime
            // When Injected the interface instance resolves to a BookStoreDatabaseSettings object
            services.AddSingleton<IBookstoreDatabaseSettings>(sp =>
            sp.GetRequiredService<IOptions<BookStoreDatabaseSettings>>().Value);

            services.AddControllers();
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
