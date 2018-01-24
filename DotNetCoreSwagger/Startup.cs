using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace DotNetCoreSwagger
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
            //下面 区分swagger版本是利用在每个action上添加，有时会显的比较麻烦，可以参考官方的方法，利用namespace来区分版本
            //https://github.com/domaindrivendev/Swashbuckle.AspNetCore#assign-actions-to-documents-by-convention


            //注册 swagger 生成器，可以在此处定义 多个文档，
            #region Info 类说明
            //public string Version { get; set; }  版本
            //public string Title { get; set; } 标题
            //public string Description { get; set; } 文档描述
            //public string TermsOfService { get; set; }  服务条款
            //public Contact Contact { get; set; }  联系人信息
            //public License License { get; set; }  授权信息
            #endregion
            services.AddSwaggerGen(op =>
                {
                    op.SwaggerDoc("docV1", new Info { Version = "v1", Title = "docTitle", Description = "描述接口实现什么内容", TermsOfService = "不能用于商业，仅供学习", Contact = new Contact { Name = "联系人", Url = "网址", Email = "xxx@xxx.com" }, License = new License { Name = "MIT", Url = "https://coursera.com" } });

                    op.SwaggerDoc("docV2", new Info { Version = "v2", Title = "docTitle2", Description = "描述接口实现什么内容2", TermsOfService = "不能用于商业，仅供学习2", Contact = new Contact { Name = "联系人2", Url = "网址2", Email = "xxx2@xxx.com" }, License = new License { Name = "MIT", Url = "https://coursera.com" } });

                    //增加api接口注释
                    var basePath = AppContext.BaseDirectory;
                    var xmlPath = Path.Combine(basePath, "DotNetCoreSwagger.xml");
                    op.IncludeXmlComments(xmlPath);

                });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //为了使用 wwwroot下的资源文件，需增加该句
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // 使Swagger中间件生效 core中 组件都是以中间件形式,定义接口文档生成格式.：
            app.UseSwagger(
                c =>
                {
                    c.RouteTemplate = "api-docs/{documentName}/swagger11.json";
                });

            //启用swaggerUI  在此处的docV1必须与  op.SwaggerDoc name一致
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "api-docs";//访问接口此时可以使用 xxxx/api-docs
                c.SwaggerEndpoint("/api-docs/docV1/swagger11.json", "DemoApiV1");

                c.SwaggerEndpoint("/api-docs/docV2/swagger11.json", "DemoApiV2");

                c.InjectStylesheet("/swagger-ui/CSS/custom.css");
                c.InjectOnCompleteJavaScript("/swagger-ui/JS/custom.js");
            });


            app.UseMvc();
        }
    }
}
