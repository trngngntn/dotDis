using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using dotdis.Models;
using System.Collections.Generic;

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
        public static void PrintIndexAndValues(ArraySegment<byte> arrSeg)
        {
            for (int i = arrSeg.Offset; i < (arrSeg.Offset + arrSeg.Count); i++)
            {
                Console.WriteLine("   [{0}] : {1}", i, arrSeg.Array[i]);
            }
            Console.WriteLine();
        }
        public static async Task Echo(HttpContext context, WebSocket webSocket)
        {
            var buffer = new byte[4];
            var none = CancellationToken.None;
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), none);
            while (!result.CloseStatus.HasValue)
            {
                Console.WriteLine(result.MessageType + "  " + result.EndOfMessage);
                var mesg = new ArraySegment<byte>(buffer, 0, result.Count);
                //PrintIndexAndValues(mesg);
                Console.WriteLine("SUBP: " + webSocket.SubProtocol);
                await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, none);
                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), none);
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, none);
        }
    }
}