using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using SignalDemo.HubInterface;
using SignalDemo.Hubs;

namespace SignalDemo.Pages.echarts
{
    public class IndexModel : PageModel
    {

        private readonly IHubContext<ChatHub, IChatClient> _hubContext;

        public IndexModel(IHubContext<ChatHub, IChatClient> hubContext)
        {
            _hubContext = hubContext;
        }
      

        public async Task<JsonResult> OnPostAsync(string user)
        {
            if (string.IsNullOrWhiteSpace(user))
            {
                return new JsonResult(new { status = "fail", message = "NoUser" });
            }
            await Task.Factory.StartNew(async () =>
            {
                var rnd = new Random(DateTime.Now.Millisecond);
                //生产任务时此处需要修改，可改为定时（Job/Sleep）获取数据库数据或从消息队列中触发
                for (var i = 0; i < 100; i++)
                {
                    await _hubContext.Clients.Client(user)
                        .EchartsMessage(
                            new[] {
                                $"{rnd.Next(100,300)}",
                                $"{rnd.Next(100,320)}" ,
                                $"{rnd.Next(100,310)}",
                                "",
                                $"{rnd.Next(10,30)}",
                                $"{rnd.Next(10,30)}",
                                "",
                                $"{rnd.Next(130,310)}",
                                $"{rnd.Next(130,310)}",
                                $"{rnd.Next(13,31)}",
                                $"{rnd.Next(13,31)}",
                                "",
                                $"{rnd.Next(130,310)}",
                                $"{rnd.Next(130,310)}",
                                $"{rnd.Next(13,31)}",
                                $"{rnd.Next(130,310)}",
                                $"{rnd.Next(130,310)}"}
                            );
                    await Task.Delay(2000);
                }
            }, TaskCreationOptions.LongRunning);

            return new JsonResult(new { status = "ok" });
        }
    }
}
