﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Lesson6
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(name: "FirstRoute",
            //    template: "Home", defaults: new
            //    {
            //        controller = "Home",
            //        action = "Index2"
            //    });

            //    routes.MapRoute(name: "default",
            //    template: "{controller=Employee}/{action=Index}/{id?}");
            //});
        }
      
    }
}
