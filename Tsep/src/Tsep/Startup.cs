using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StackExchange.Profiling.Mvc;
using StackExchange.Profiling.Storage;

namespace Tsep
{
    public class Startup
    {
      

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMiniProfiler();
            services.AddMemoryCache();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,IMemoryCache cache)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseFileServer();
            app.UseMiniProfiler(new StackExchange.Profiling.MiniProfilerOptions
            {
                RouteBasePath = "~/profiler",
                SqlFormatter = new StackExchange.Profiling.SqlFormatters.InlineFormatter(),
                Storage = new MemoryCacheStorage(cache, TimeSpan.FromMinutes(60))
            });
            app.UseMvcWithDefaultRoute();
        }
    }
}
