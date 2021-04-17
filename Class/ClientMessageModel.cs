using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalDemo.Class
{
    /// <summary>
    /// 服务端发送给客户端的信息
    /// </summary>
    [Serializable]
    public class ClientMessageModel
    {
        /// <summary>
        /// 接收用户编号
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 组编号
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// 发送的内容
        /// </summary>
        public string Context { get; set; }
    }
}
