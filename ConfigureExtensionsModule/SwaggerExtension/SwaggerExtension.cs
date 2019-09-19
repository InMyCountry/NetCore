using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using SwashbuckleModule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SwaggerExtension
    {
        public static void AddUserSwagger(this IServiceCollection services)
        {
            // 配置 Swagger 文档信息
            services.AddSwaggerGen(s =>
            {
                // 根据 API 版本信息生成 API 文档
                //
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    s.SwaggerDoc(description.GroupName, new Info
                    {
                        Contact = new Contact
                        {
                            Name = "联系人",
                            Email = "邮箱",
                            Url = "地址"
                        },
                        Description = "Api.NetCore 接口文档",
                        Title = "Api.NetCore",
                        Version = description.ApiVersion.ToString()
                    });
                }

                // 在 Swagger 文档显示的 API 地址中将版本信息参数替换为实际的版本号
                s.DocInclusionPredicate((version, apiDescription) =>
                {
                    if (!version.Equals(apiDescription.GroupName))
                        return false;

                    var values = apiDescription.RelativePath
                        .Split('/')
                        .Select(v => v.Replace("v{version}", apiDescription.GroupName)); apiDescription.RelativePath = string.Join("/", values);
                    return true;
                });

                // 参数使用驼峰命名方式
                s.DescribeAllParametersInCamelCase();

                // 取消 API 文档需要输入版本信息
                s.OperationFilter<RemoveVersionFromParameter>();

                // 获取接口文档描述信息
                //var basePath = Path.GetDirectoryName(AppContext.BaseDirectory);
                //Console.WriteLine(basePath);
                //var apiPath = Path.Combine(basePath, "Api.NetCore.xml");
                //s.IncludeXmlComments(apiPath, true);

                #region 启用swagger验证功能
                //添加一个必须的全局安全信息，和AddSecurityDefinition方法指定的方案名称一致即可，CoreAPI。
                var security = new Dictionary<string, IEnumerable<string>> { { "fff", new string[] { } }, };
                s.AddSecurityRequirement(security);
                s.AddSecurityDefinition("fff", new ApiKeyScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 在下方输入Bearer {token} 即可，注意两者之间有空格",
                    Name = "Authorization",//jwt默认的参数名称
                    In = "header",//jwt默认存放Authorization信息的位置(请求头中)
                    Type = "apiKey"
                });
                #endregion
                #region 读取xml信息         
                //获取基目录
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                //获取所有的xml文件
                string[] files = Directory.GetFiles(baseDirectory, "*.xml");
                foreach (var item in files)
                {
                    //启用xml注释.该方法第二个参数启用控制器的注释，默认为false.
                    s.IncludeXmlComments(item, true);
                }
                #endregion
            });
        }
        public static IApplicationBuilder UseUserSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            // 启用 Swagger 文档
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                // 默认加载最新版本的 API 文档
                foreach (var description in provider.ApiVersionDescriptions.Reverse())
                {
                    s.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        $"Sample API {description.GroupName.ToUpperInvariant()}");
                }
            });
            return app;
        }
    }
}
