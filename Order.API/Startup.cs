﻿using Microsoft.AspNetCore.Authentication;
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
using Order.API.Controllers.PlacedOrders.Mapper;
using Order.API.Controllers.PlacedOrders.Mapper.Interface;
using Order.API.Helpers;
using Order.Services.CostumerServices;
using Order.Services.CostumerServices.Interfaces;
using Order.Services.ItemServices;
using Order.Services.ItemServices.Interfaces;
using Order.Services.PlacedOrderServices;
using Order.Services.PlacedOrderServices.Interfaces;
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

            services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            services.AddAuthorization(options =>
            {
                options.AddPolicy("MustBeCostumer", policy => policy.RequireRole("COSTUMER", "ADMIN"));
                options.AddPolicy("MustBeAdmin", policy => policy.RequireRole("ADMIN"));
            });


            services.AddSingleton<ICostumerService, CostumerService>();
            services.AddSingleton<ICostumerMapper, CostumerMapper>();

            services.AddSingleton<IItemService, ItemService>();
            services.AddSingleton<IItemMapper, ItemMapper>();

            services.AddSingleton<IPlacedOrderService, PlacedOrderService>();
            services.AddSingleton<IPlacedOrderMapper, PlacedOrderMapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseMvc();

            app.UseSwaggerUi3WithApiExplorer(settings => { settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase; });
        }
    }
}
