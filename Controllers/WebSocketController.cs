using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Extensions;
using System.Text;
using dotDis.Models;
using System.Linq;
using System.Text.Json;
using dotdis.Models;

namespace dotdis.Controllers
{
    public static class WebSocketController
    {
        private const int BUFFER_SIZE = 1024;
        //private static Dictionary<int, List<ISession>> userSession = new Dictionary<int, List<ISession>>();

        public static async Task InitSocket(HttpContext context, WebSocket webSocket)
        {
            int uid = (int)context.Session.GetBindedUid();
            if (UserIsOnline(uid)) // user is currently online
            {
                if (context.Session.IsBindedToUid(uid)) context.Session.AddSocket(webSocket);
                else context.Session.BindToUid(uid);
            }
            else // user change state from offline to online
            {
                context.Session.BindToUid(uid);
                context.Session.AddSocket(webSocket);
                Console.WriteLine("Add new user binding");
                InformUserOnline(uid, webSocket);
            }
            await ProcessData(context, webSocket);
        }

        private static void CloseSocket(HttpContext context, WebSocket webSocket)
        {
            context.Session.CloseSocket(webSocket);
        }

        public static async Task ProcessData(HttpContext context, WebSocket webSocket)
        {
            Console.WriteLine("[LOG] Processing........");
            byte[] buffer = new byte[BUFFER_SIZE];
            ArraySegment<byte> temp = new ArraySegment<byte>(buffer);
            WebSocketReceiveResult received = await webSocket.ReceiveAsync(temp, CancellationToken.None);
            List<byte> dataByte = new List<byte>();
            while (!received.CloseStatus.HasValue)
            {
                if (received.EndOfMessage) // receive final mesg part
                {
                    dataByte.AddRange(buffer.Take(received.Count));
                    string data = Encoding.UTF8.GetString(dataByte.ToArray());
                    JsonGeneric obj = JsonSerializer.Deserialize<JsonGeneric>(data);
                    Console.WriteLine("RECV_MESG:" + obj);
                    await Process(obj.Type, obj.Data);
                    dataByte = new List<byte>();
                }
                else
                {
                    dataByte.AddRange(buffer);
                }
                // continue waiting to receive data
                received = await webSocket.ReceiveAsync(temp, CancellationToken.None);
            }
            // close socket
            CloseSocket(context, webSocket);
        }

        private static async Task Process(string type, string data)
        {
            Console.WriteLine("[LOG] Processing message type: " + type);
            switch (type)
            {
                case "sent_private_message":
                    PrivateMessage mesg = JsonSerializer.Deserialize<PrivateMessage>(data);
                    await BroadcastMesgToUser(mesg);
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

        private static async Task BroadcastMesgToUser(PrivateMessage mesg)
        {
            if (UserIsOnline(mesg.RecvID))
            {
                Console.WriteLine("[LOG] Broadcasting message to user " + mesg.RecvID);
                Func<WebSocket, Task> action = async(socket) => {
                    JsonGeneric obj = new JsonGeneric("recv_private_message", JsonSerializer.Serialize<PrivateMessage>(mesg));
                    await SendDataToSocket(JsonSerializer.SerializeToUtf8Bytes<JsonGeneric>(obj), socket);
                };
                await IterateUserSockets(mesg.RecvID, action);
            }
        }

        private static async Task SendDataToSocket(byte[] data, WebSocket webSocket)
        {
            //byte[] buffer = new byte[BUFFER_SIZE];
            int offset = 0, length = BUFFER_SIZE;
            while (offset < data.Length)
            {
                length = (data.Length - offset) < BUFFER_SIZE ? (data.Length - offset) : BUFFER_SIZE;
                Console.WriteLine("[LOG] offset = {0}, length = {1}, data = {2}", offset, length, data.Length);
                await webSocket.SendAsync(new ArraySegment<byte>(data, offset, length), WebSocketMessageType.Text, (offset + length) == data.Length, CancellationToken.None);
                offset += length;
            }
            Console.WriteLine("[LOG] Sent data to Socket");
        }
        private static void BroadcastMesgToChannel(ChannelMessage mesg)
        {

        }

        private static void BroadcastNotf(string uid)
        {

        }

        private static async Task BroadcastInfo(JsonGeneric obj, WebSocket webSocket)
        {
            await SendDataToSocket(JsonSerializer.SerializeToUtf8Bytes<JsonGeneric>(obj), webSocket);
        }

        private static bool UserIsOnline(int uid)
        {
            return Extensions.SessionExtensions.UserIsOnline(uid);
        }

        private static void InformUserOnline(int uid, WebSocket webSocket)
        {
            Console.WriteLine("[LOG] Informing that user {0} is just online", uid);
            List<int> fUids = User.ListFriendUid(uid);
            foreach (int fUid in fUids)
            {
                if (UserIsOnline(fUid))
                {
                    ///
                    Console.WriteLine("[LOG] Inform user {0} that user {1} is just online", fUid, uid);
                    JsonGeneric userOnlineInform = new JsonGeneric("user_online", uid.ToString());
                    Func<WebSocket, Task> action = async (socket) => await BroadcastInfo(userOnlineInform, socket);
                    Task sendStatus = IterateUserSockets(fUid, action);
                    ///
                    Console.WriteLine("[LOG] Inform user {1} that user {0} is currently online", fUid, uid);
                    JsonGeneric friendOnlineInform = new JsonGeneric("user_online", fUid.ToString());
                    Task recvStatus = BroadcastInfo(friendOnlineInform, webSocket);
                }
            }
        }

        public static async Task InformUserOffline(int uid)
        {
            Console.WriteLine("[LOG] Informing that user {0} is just offline", uid);
            List<int> fUids = User.ListFriendUid(uid);
            foreach (int fUid in fUids)
            {
                if (UserIsOnline(fUid))
                {
                    Console.WriteLine("[LOG] Inform user {0} that user {1} is just offline", fUid, uid);
                    JsonGeneric userOnlineInform = new JsonGeneric("user_offline", uid.ToString());
                    Func<WebSocket, Task> action = async (socket) => await BroadcastInfo(userOnlineInform, socket);
                    await IterateUserSockets(fUid, action);
                }
            }
        }
        private static async Task IterateUserSockets(int uid, Func<WebSocket, Task> action)
        {
            List<ISession> sessionList = Extensions.SessionExtensions.GetUserSessions(uid);
            foreach (ISession session in sessionList)
            {
                foreach (WebSocket socket in session.GetSockets())
                {
                    await action(socket);
                }
            }
        }

        private static async Task IterateUserSessions(int uid, Func<ISession, Task> action)
        {
            List<ISession> sessionList = Extensions.SessionExtensions.GetUserSessions(uid);
            foreach (ISession session in sessionList)
            {
                await action(session);
            }
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