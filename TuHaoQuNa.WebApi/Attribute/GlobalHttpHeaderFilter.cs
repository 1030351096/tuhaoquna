using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using DripOldDriver;

namespace TuHaoQuNa.WebApi.Attribute
{
    public class GlobalHttpHeaderFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();

            if (!apiDescription.ActionDescriptor.GetCustomAttributes<NotSignAttribute>().Any())
            {
                operation.parameters.Add(new Parameter { name = "time", @in = "header", description = "时间戳", required = false, type = "string" });
                operation.parameters.Add(new Parameter { name = "token", @in = "header", description = "请求特征值", required = false, type = "string" });
                operation.parameters.Add(new Parameter { name = "sign", @in = "header", description = "签名", required = false, type = "string" });
            }
        }
    }
}