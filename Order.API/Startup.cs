using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NJsonSchema;
using NSwag.AspNetCore;
using Order.API.Controllers.Costumers.Mapper;
using Order.API.Controllers.Costumers.Mapper.Interface;
using Order.API.Controllers.Items.Mapper;
using Order.API.Controllers.Items.Mapper.Interface;
using Order.Services.CostumerServices;
using Order.Services.CostumerServices.Interfaces;
using Order.Services.ItemServices;
using Order.Services.ItemServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API
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
            services.AddSwagger();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddSingleton<ICostumerService, CostumerService>();
            services.AddSingleton<ICostumerMapper, CostumerMapper>();

            services.AddSingleton<IItemService, ItemService>();
            services.AddSingleton<IItemMapper, ItemMapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();

            app.UseSwaggerUi3WithApiExplorer(settings => { settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase; });
            app.Run(async context => { context.Response.Redirect("/swagger"); });
        }
    }
}
