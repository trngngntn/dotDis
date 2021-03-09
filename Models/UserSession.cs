using Microsoft.AspNetCore.Http;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Web;

namespace dotDis.Models
{
    public class UserSession
    {
        ISession session;
        List<WebSocket> bindSockets;
        public UserSession(ISession session)
        {
            this.session = session;
            bindSockets = new List<WebSocket>(); 
        }

        public void AddWebSocket(WebSocket socket)
        {
            bindSockets.Add(socket);
        }
    }
}
