using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using dotDis.Models;

namespace dotdis.Controllers
{
    public class WebSocketController
    {
        private static Dictionary<string, List<UserSession>> userBinding;
        public void GetWS(){

        }
        private List<byte> mesg = new List<byte>();
        
        public void InitSocket(HttpContext context, WebSocket webSocket)
        {
            List<UserSession> uSessionList = userBinding[context.Session.GetString("active-user")];
            bool sessionExist = false;
            foreach(UserSession uSession in uSessionList)
            {
                if(uSession.Equals(context.Session))
                {
                    sessionExist = true;
                    uSession.AddWebSocket(webSocket);
                }
            }
            if (!sessionExist)
            {
                UserSession newUSession = new UserSession(context.Session);
                newUSession.AddWebSocket(webSocket);
            }
        }

        public async Task Echo(HttpContext context, WebSocket webSocket)
        {
            byte[] buffer = new byte[4];
            var none = CancellationToken.None;
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), none);
            while (!result.CloseStatus.HasValue)
            {
                Console.WriteLine(result.MessageType + "  " + result.EndOfMessage);
                var mesgx = new ArraySegment<byte>(buffer, 0, result.Count);
                //mesg.AddRange(buffer);
                mesg.AddRange(buffer);
                //PrintIndexAndValues(mesgx);
                //Console.WriteLine("toString: " + BitConverter.ToString(buffer));
                if(result.EndOfMessage == true)
                {
                    byte[] fin = mesg.ToArray();
                    Console.WriteLine("Final MESG: " + Encoding.UTF8.GetString(fin));
                }
                await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, none);
                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), none);
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, none);
        }
    }
}