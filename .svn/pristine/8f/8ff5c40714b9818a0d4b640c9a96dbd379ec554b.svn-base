/********************************************************************************
**
**　　　　　　　　┏┓　　　┏┓+ +
**　　　　　　　┏┛┻━━━┛┻┓ + +
**　　　　　　　┃　　　　　　　┃ 　
**　　　　　　　┃　　　━　　　┃ ++ + + +
**　　　　　　 ████━████ ┃+
**　　　　　　　┃　　　　　　　┃ +
**　　　　　　　┃　　　┻　　　┃
**　　　　　　　┃　　　　　　　┃ + +
**　　　　　　　┗━┓　　　┏━┛
**　　　　　　　　　┃　　　┃　　　　　　　　　　　
**　　　　　　　　　┃　　　┃ + + + +
**　　　　　　　　　┃　　　┃　　　　Code is far away from bug with the animal protecting　　　　　　　
**　　　　　　　　　┃　　　┃ + 　　　　神兽保佑,代码无bug　　
**　　　　　　　　　┃　　　┃
**　　　　　　　　　┃　　　┃　　+　　　　　　　　　
**　　　　　　　　　┃　 　　┗━━━┓ + +
**　　　　　　　　　┃ 　　　　　　　┣┓
**　　　　　　　　　┃ 　　　　　　　┏┛
**　　　　　　　　　┗┓┓┏━┳┓┏┛ + + + +
**　　　　　　　　　　┃┫┫　┃┫┫
**　　　　　　　　　　┗┻┛　┗┻┛+ + + +
**

** ***********************************************************************
** 程序集			: TuHaoQuNa.WebApi
** 文件名			: SwaggerConfig.cs
** 作者				: 滴。老司机
** 邮箱             : 370326433@qq.com
** 创建时间			: 2017-08-19
** 最后修改者		: 滴。老司机
** 最后修改时间		: 2017-08-19
** ***********************************************************************

*********************************************************************************/
using System.Web.Http;
using WebActivatorEx;
using TuHaoQuNa.WebApi;
using Swashbuckle.Application;
using System;
using System.IO;
using System.Reflection;
using System.Linq;
using TuHaoQuNa.WebApi.Attribute;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace TuHaoQuNa.WebApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "土豪去哪API文档")
                        .Description("该文档包含土豪去哪PC站点、移动端、APP调用的Api接口相关描述")
                        .TermsOfService("土豪去哪")
                        .Contact(cc => cc
                            .Name("滴。老司机")
                            .Email("370326433@qq.com"));
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                    var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var commentsFileName = @"bin\TuHaoQuNa.WebApi.xml";
                    var commentsFile = Path.Combine(baseDirectory, commentsFileName);
                    //将注释的XML文档添加到SwaggerUI中
                    c.IncludeXmlComments(commentsFile);
                    c.OperationFilter<GlobalHttpHeaderFilter>();

                })
                .EnableSwaggerUi("help/{*assetPath}", b =>
                {
                    //对js进行了拓展
                    b.InjectJavaScript(Assembly.GetExecutingAssembly(), "TuHaoQuNa.WebApi.SwaggerUI.Script.swagger.js");
                    b.InjectStylesheet(Assembly.GetExecutingAssembly(), "TuHaoQuNa.WebApi.SwaggerUI.Css.style.css");
                    //b.EnableOAuth2Support(
                    //        clientId: "test-client-id",
                    //        clientSecret: null,
                    //        realm: "test-realm",
                    //        appName: "Swagger UI"
                    //    //additionalQueryStringParams: new Dictionary<string, string>() { { "foo", "bar" } }
                    //    );

                });
        }
    }
}
