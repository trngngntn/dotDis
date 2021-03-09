using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using dotDis.Models;
using System.Linq;
using System.Text.Json;
using dotdis.Models;

namespace dotdis.Controllers
{
    public class WebSocketController
    {
        private const int BUFFER_SIZE = 1024;
        private static Dictionary<int, List<UserSession>> userBinding;

        public async Task InitSocket(HttpContext context, WebSocket webSocket)
        {
            int uid = Int32.Parse(context.Session.GetString("active-user"));
            if (UserIsOnline(uid)) // user is currently online
            {
                List<UserSession> uSessionList = userBinding[uid];
                bool sessionExist = false;
                foreach (UserSession uSession in uSessionList)
                {
                    if (uSession.Equals(context.Session)) // add socket to current session
                    {
                        sessionExist = true;
                        uSession.AddSocket(webSocket);
                    }
                }
                if (!sessionExist) // add new session with socket
                {
                    UserSession newUSession = new UserSession(context.Session);
                    newUSession.AddSocket(webSocket);
                    uSessionList.Add(newUSession);
                }
            }
            else
            {
                List<UserSession> newUSessionList = new List<UserSession>();
                UserSession newUSession = new UserSession(context.Session);
                newUSession.AddSocket(webSocket);
                newUSessionList.Add(newUSession);
                userBinding.Add(uid, newUSessionList);
            }
            await ProcessData(context, webSocket);
        }

        private void CloseSocket(){
            
        }
        public async Task ProcessData(HttpContext context, WebSocket webSocket)
        {
            byte[] buffer = new byte[BUFFER_SIZE];
            ArraySegment<byte> temp = new ArraySegment<byte>(buffer);
            WebSocketReceiveResult received = await webSocket.ReceiveAsync(temp, CancellationToken.None);
            List<byte> dataByte = new List<byte>();
            while (!received.CloseStatus.HasValue)
            {
                if (received.EndOfMessage) // receive final mesg part
                {
                    //temp.ToArray();
                    dataByte.AddRange(buffer.Take(received.Count));
                    string data = Encoding.UTF8.GetString(dataByte.ToArray());
                    //JsonGeneric obj = JsonSerializer.Deserialize<JsonGeneric>(data);
                    //Process(obj.Type, obj.Data);
                    Console.WriteLine("RECV_MESG:" + data);
                    dataByte = new List<byte>();
                }
                else
                {
                    dataByte.AddRange(buffer);
                }
                //await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, none);
                received = await webSocket.ReceiveAsync(temp, CancellationToken.None);
            }
            // close socket
            Console.WriteLine("[LOG] Close WebSocket");
            CloseSocket();
        }
        private void Process(string type, string data)
        {
            switch (type)
            {
                case "sent_private_message":
                    PrivateMessage mesg = JsonSerializer.Deserialize<PrivateMessage>(data);
                    break;
                case "load_private__message":
                    {
                        string[] info = JsonSerializer.Deserialize<string>(data).Split(";");


                    }
                    break;
                default:
                    break;
            }
        }

        private async Task BroadcastMesgToUser(PrivateMessage mesg)
        {
            if (UserIsOnline(mesg.RecvID))
            {
                List<UserSession> uSessions = userBinding[mesg.RecvID];
                foreach (UserSession uSession in uSessions)
                {
                    foreach (WebSocket webSocket in uSession.GetSockets())
                    {
                        await SendDataToSocket(JsonSerializer.SerializeToUtf8Bytes<PrivateMessage>(mesg), webSocket);
                    }
                }
            }
        }

        private async Task SendDataToSocket(byte[] data, WebSocket webSocket)
        {
            byte[] buffer = new byte[BUFFER_SIZE];
            int offset = 0, length = BUFFER_SIZE;
            while(offset < buffer.Length)
            {
                length = (buffer.Length - offset) < BUFFER_SIZE ? (buffer.Length - offset) : BUFFER_SIZE;
                await webSocket.SendAsync(new ArraySegment<byte>(data, offset, length), WebSocketMessageType.Text, offset + length < buffer.Length, CancellationToken.None);
            }
        }
        private void BroadcastMesgToChannel(ChannelMessage mesg)
        {

        }

        private void BroadcastNotf(string uid)
        {

        }

        private void BroadcastInfo()
        {

        }

        private bool UserIsOnline(int uid)
        {
            return userBinding.ContainsKey(uid);
        }

        //sample function for testing WebSocket
        /*public async Task Echo(HttpContext context, WebSocket webSocket)
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
        }*/
    }
}