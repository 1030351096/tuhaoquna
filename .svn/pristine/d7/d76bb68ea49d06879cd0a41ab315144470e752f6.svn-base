using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;

[assembly: OwinStartup(typeof(TuHaoQuNa.Web.Startup))]

namespace TuHaoQuNa.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //指定Hangfire使用内存存储后台任务信息
            GlobalConfiguration.Configuration.UseSqlServerStorage("TuHaoQuNa_Task");
            //启用HangfireServer这个中间件（它会自动释放）
            app.UseHangfireServer();
            //启用Hangfire的仪表盘（可以看到任务的状态，进度等信息）
            app.UseHangfireDashboard();
            //RecurringJob.AddOrUpdate<Task.DouBanInfoJob>(j=>
            //    j.Collection(dsd),
            //    Cron.Daily(21)
            //);
        }
    }
}
