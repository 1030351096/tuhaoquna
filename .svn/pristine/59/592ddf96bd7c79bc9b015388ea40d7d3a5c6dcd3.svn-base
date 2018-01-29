using DripOldDriver.Cache;
using System;
using System.Collections.Generic;
using System.Configuration;
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
** 程序集			: TuHaoQuNa.WebApi.Attribute
** 文件名			: GlobalActionFilterAttribute.cs
** 作者				: 滴。老司机
** 邮箱             : 370326433@qq.com
** 创建时间			: 2017-08-19
** 最后修改者		: 滴。老司机
** 最后修改时间		: 2017-08-19
** ***********************************************************************

*********************************************************************************/
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using TuHaoQuNa.WebApi.Models;
using DripOldDriver;
using TuHaoQuNa.Business;

namespace TuHaoQuNa.WebApi.Attribute
{
    /// <summary>
    /// 全局Action过滤器
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class GlobalActionFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 在调用操作方法之前发生。
        /// </summary>
        /// <param name="actionContext">操作上下文。</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateResponse(new ApiResult()
                {
                    Data = actionContext.ModelState.Values.SelectMany(v => v.Errors).Select(p => p.ErrorMessage),
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "参数校验失败"
                });
            }
            else
            {
                if (!actionContext.ActionDescriptor.GetCustomAttributes<NotSignAttribute>().Any())
                {
                    //签名校验
                    var token = HttpContext.Current.Request.Headers["token"];
                    token = string.IsNullOrWhiteSpace(token) ? HttpContext.Current.Request["token"]: token;
                    var sign = HttpContext.Current.Request.Headers["sign"];
                    sign = string.IsNullOrWhiteSpace(sign) ? HttpContext.Current.Request["sign"] : sign;
                    var time = HttpContext.Current.Request.Headers["time"];
                    time = string.IsNullOrWhiteSpace(time) ? HttpContext.Current.Request["time"] : time;
                    var data = actionContext.ActionArguments["data"].ToJson_();
                    if (Math.Abs(time.ToLong_() - DateTime.Now.ToTimeStamp_()) > 1000 * 60*60)
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(new ApiResult()
                        {
                            Data = actionContext.ModelState.Values.SelectMany(v => v.Errors).Select(p => p.ErrorMessage),
                            StatusCode = HttpStatusCode.Forbidden,
                            Message = "服务器拒绝了请求"
                        });
                    }
                    else
                    {
                        if (Sign(token,time,data).ToUpper()!=sign.ToUpper())
                        {
                            actionContext.Response = actionContext.Request.CreateResponse(new ApiResult()
                            {
                                Data = actionContext.ModelState.Values.SelectMany(v => v.Errors).Select(p => p.ErrorMessage),
                                StatusCode = HttpStatusCode.Forbidden,
                                Message = "服务器拒绝了请求"
                            });
                        }
                    }
                }
                
            }
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="token"></param>
        /// <param name="time"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        string Sign(string token, string time, string data)
        {
            var apiKey = Config_BLL.Config.Get<string>("TuHaoQuNa.ApiKey");
            return (apiKey.MD5_().ToUpper()+token+time+data).MD5_();
        }
    }
}