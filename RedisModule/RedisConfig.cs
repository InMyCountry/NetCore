using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisModule
{
    public static class RedisConfig
    {

        public static void AddUserRedis(this IServiceCollection services)
        {
            services.AddDistributedRedisCache(options => {
                options.Configuration = "127.0.0.1";
                options.InstanceName = "StepByStepDemo";
            });
        }
        //public static IApplicationBuilder UseUserSwagger(this IApplicationBuilder app )
        //{
        //    return app;
        //}
    }
}
