using System;
using System.Collections.Generic;
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
                });
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // 使Swagger中间件生效 core中 组件都是以中间件形式.
            app.UseSwagger();

            //启用swaggerUI  在此处的docV1必须与  op.SwaggerDoc name一致
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/docV1/swagger.json", "DemoApiV1");
            });


            app.UseMvc();
        }
    }
}
