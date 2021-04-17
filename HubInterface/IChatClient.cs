using SignalDemo.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalDemo.HubInterface
{
    public interface IChatClient
    {
        /// <summary>
        /// 客户端接收数据触发函数名
        /// </summary>
        /// <param name="clientMessageModel">消息实体类</param>
        /// <returns></returns>
        Task ReceiveMessage(ClientMessageModel clientMessageModel);
        /// <summary>
        /// Echart接收数据触发函数名
        /// </summary>
        /// <param name="data">JSON格式的可以被Echarts识别的data数据</param>
        /// <returns></returns>
        Task EchartsMessage(Array data);
        /// <summary>
        /// 客户端获取自己登录后的UID
        /// </summary>
        /// <param name="clientMessageModel">消息实体类</param>
        /// <returns></returns>
        Task GetMyId(ClientMessageModel clientMessageModel);
    }
}
