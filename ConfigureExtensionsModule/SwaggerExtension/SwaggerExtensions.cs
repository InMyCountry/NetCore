//using Microsoft.AspNetCore.Builder;
//using Microsoft.Extensions.DependencyInjection;
//using Swashbuckle.AspNetCore.Swagger;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;

//namespace Microsoft.Extensions.DependencyInjection
//{
//    public static class SwaggerExtensions
//    {

//        public static IServiceCollection AddSwaggerConfigByUser(this IServiceCollection services)
//        {
//            // 注册Swagger服务
//            services.AddSwaggerGen(c =>
//            {
//                // 添加文档信息
//                c.SwaggerDoc("v1", new Info
//                {
//                    Title = "CoreWebApi",
//                    Version = "v1",
//                    Description = "ASP.NET CORE WebApi",
//                    Contact = new Contact
//                    {
//                        Name = "TheAcme",
//                        Email = "admin@163.com"
//                    }
//                });
//                #region 读取xml信息         
//                //获取基目录
//                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
//                //获取所有的xml文件
//                string[] files = Directory.GetFiles(baseDirectory, "*.xml");
//                foreach (var item in files)
//                {
//                    //启用xml注释.该方法第二个参数启用控制器的注释，默认为false.
//                    c.IncludeXmlComments(item, true);
//                }
//                #endregion

//                #region 启用swagger验证功能
//                //添加一个必须的全局安全信息，和AddSecurityDefinition方法指定的方案名称一致即可，CoreAPI。
//                var security = new Dictionary<string, IEnumerable<string>> { { "fff", new string[] { } }, };
//                c.AddSecurityRequirement(security);
//                c.AddSecurityDefinition("fff", new ApiKeyScheme
//                {
//                    Description = "JWT授权(数据将在请求头中进行传输) 在下方输入Bearer {token} 即可，注意两者之间有空格",
//                    Name = "Authorization",//jwt默认的参数名称
//                    In = "header",//jwt默认存放Authorization信息的位置(请求头中)
//                    Type = "apiKey"
//                });
//                #endregion
//            });

//            return services;
//        }

//        public static IApplicationBuilder UseSwaggerConfigByUser(this IApplicationBuilder app)
//        {

//            // 启用Swagger中间件
//            app.UseSwagger();

//            // 配置SwaggerUI
//            app.UseSwaggerUI(c =>
//            {
//                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoreWebApi");

//            });
//            return app;
//        }
//    }
//}
