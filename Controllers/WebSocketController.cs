using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using dotdis.Models;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace dotdis.Controllers
{
    public class WebSocketController
    {
        private class ActiveConnections{
            WebSocket webSocket;
            //Session
        }
        private Dictionary<string, ActiveConnections> userBinding;
        private static WebSocket temp;
        public void GetWS(){

        }
        private List<byte> mesg = new List<byte>();
        
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