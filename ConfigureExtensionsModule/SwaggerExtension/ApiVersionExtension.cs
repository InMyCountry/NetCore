using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{

    //需要安装两个类库
    //Install-Package Microsoft.AspNetCore.Mvc.Versioning
    //Install-Package Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer

    public static class ApiVersionExtension
    {
        /// <summary>
        /// 添加 API 版本控制扩展方法
        /// </summary>
        /// <param name="services">生命周期中注入的服务集合 <see cref="IServiceCollection"/></param>
        public static void AddApiVersionConfigByUser(this IServiceCollection services)
        {
            // 添加 API 版本支持
            services.AddApiVersioning(o =>
            {
                // 是否在响应的 header 信息中返回 API 版本信息
                o.ReportApiVersions = true;

                // 默认的 API 版本
                o.DefaultApiVersion = new ApiVersion(1, 0);

                // 未指定 API 版本时，设置 API 版本为默认的版本
                o.AssumeDefaultVersionWhenUnspecified = true;
            });

            // 配置 API 版本信息
            services.AddVersionedApiExplorer(option =>
            {
                // api 版本分组名称
                option.GroupNameFormat = "'v'VVVV";
                // 未指定 API 版本时，设置 API 版本为默认的版本
                option.AssumeDefaultVersionWhenUnspecified = true;
            });
        }
    }
}
