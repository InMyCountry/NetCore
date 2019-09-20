﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkModule;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQModule;
using RedisModule;

namespace StepByStepDemo
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
            #region 配置
            services.AddUserSwagger();
            //添加版本服务
            services.AddApiVersionConfigByUser();
            services.AddJwtConfigByUser();

            //数据库配置
            services.AddDbContext<StepByStepDbContext>(Options => {
                Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            #endregion

            services.AddSingleton<RabbitMQConnect>();
            services.AddSingleton<RedisHelper>();
            services.AddUserRedis();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider, IApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //swagger
            app.UseUserSwagger(provider);
            //授权
            app.UseAuthentication();
            
            //配置Consul
            ServiceEntity serviceEntity = new ServiceEntity
            {
                IP = "localhost",
                Port = Convert.ToInt32(Configuration["Service:Port"]),
                ServiceName = Configuration["Service:Name"],
                ConsulIP = Configuration["Consul:IP"],
                ConsulPort = Convert.ToInt32(Configuration["Consul:Port"])
            };
            app.RegisterConsul(lifetime, serviceEntity);

            app.UseMvc();
        }
    }
}
