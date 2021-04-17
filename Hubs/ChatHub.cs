using Microsoft.AspNetCore.SignalR;
using SignalDemo.Class;
using SignalDemo.HubInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalDemo.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        /// <summary>
        /// 客户端连接时触发
        ///  
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            var user = Context.ConnectionId;
            //发送消息给 user
            await Clients.Client(user).GetMyId(new ClientMessageModel { UserId = user, Context = $"回来了{DateTime.Now:yyyy-MM:dd HH:mm:ss}" });


            //客户端连接后自动发送消息到客户端
            //SignalDemo.Pages.echarts.IndexModel clientData = new SignalDemo.Pages.echarts.IndexModel();
            //await clientData.OnPostAsync(user);

            //发送消息给除 user 以外的客户端
            await Clients.AllExcept(user).ReceiveMessage(new ClientMessageModel { UserId = user, Context = $"进来了{DateTime.Now:yyyy-MM:dd HH:mm:ss}" });
            await base.OnConnectedAsync();
        }

        /// <summary>
        /// 客户端断开连接时触发
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var user = Context.ConnectionId;
            //通知所有客户端
            await Clients.All.ReceiveMessage(new ClientMessageModel { UserId = user, Context = $"{user}离开了{DateTime.Now:yyyy-MM:dd HH:mm:ss}" });
            await base.OnDisconnectedAsync(exception);
        }



    }
}
