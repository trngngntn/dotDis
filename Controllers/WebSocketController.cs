using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Extensions;
using System.Text;
using System.Linq;
using System.Text.Json;
using Models;

namespace Controllers
{
    public static class WebSocketController
    {
        private const int BUFFER_SIZE = 1024;
        private const int TYPE_R_SUBS_PRIVATE_MESG = 0;
        private const int TYPE_R_SUBS_CHANNEL_MESG = 1;
        private const int TYPE_R_LOAD_PRIVATE_MESG = 2;
        private const int TYPE_R_LOAD_CHANNEL_MESG = 3;
        private const int TYPE_R_SENT_PRIVATE_MESG = 4;
        private const int TYPE_R_SENT_CHANNEL_MESG = 5;
        private const int TYPE_B_RECV_PRIVATE_MESG = 6;
        private const int TYPE_B_RECV_CHANNEL_MESG = 7;
        private const int TYPE_B_INFO_USER_ONL = 8;
        private const int TYPE_B_INFO_USER_OFF = 9;

        public static async Task InitSocket(HttpContext context, WebSocket webSocket)
        {
            int? uidN = context.Session.GetBindedUid();
            if(uidN == null){
                context.Response.Redirect("/Login");
                webSocket.Abort();
                return;
            }
            int uid = (int)uidN;
            if (UserIsOnline(uid)) // user is currently online
            {
                // check if there is a new session
                if (!context.Session.IsBindedToUid(uid)) context.Session.BindToUid(uid);
            }
            else // user change state from offline to online
            {
                context.Session.BindToUid(uid);
                Console.WriteLine("Add new user binding");
                InformUserOnline(uid, webSocket);
            }
            context.Session.AddSocket(webSocket);
            await ReadDataFromSocket(context, webSocket);
        }

        private static void CloseSocket(HttpContext context, WebSocket webSocket)
        {
            Console.WriteLine("[LOG] Close Socket");
            context.Session.CloseSocket(webSocket);
        }

        public static async Task ReadDataFromSocket(HttpContext context, WebSocket webSocket)
        {
            Console.WriteLine("[LOG] Listening to Socket\n.............");
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
                    Process(obj.Type, obj.Data);
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
        private static async Task SendDataToSocket(byte[] data, WebSocket webSocket)
        {
            //byte[] buffer = new byte[BUFFER_SIZE];
            int offset = 0, length = BUFFER_SIZE;
            while (offset < data.Length)
            {
                length = (data.Length - offset) < BUFFER_SIZE ? (data.Length - offset) : BUFFER_SIZE;
                Console.WriteLine("[LOG] offset = {0}, length = {1}, data = {2}", offset, length, data.Length);
                await webSocket.SendAsync(
                    new ArraySegment<byte>(data, offset, length),
                    WebSocketMessageType.Text,
                    (offset + length) == data.Length, CancellationToken.None
                );
                offset += length;
            }
            Console.WriteLine("[LOG] Sent data to Socket");
        }

        private static void Process(int type, string data)
        {
            Console.WriteLine("[LOG] Processing message type: " + type);
            switch (type)
            {
                //Processing Private Messages---------------------------------------------------------------------------
                case TYPE_R_SUBS_PRIVATE_MESG:
                    break;
                case TYPE_R_LOAD_PRIVATE_MESG:
                    {
                        string[] info = JsonSerializer.Deserialize<string>(data).Split(";");
                    }
                    break;
                case TYPE_R_SENT_PRIVATE_MESG:
                    PrivateMessage mesg = JsonSerializer.Deserialize<PrivateMessage>(data);
                    BroadcastMesgToUser(mesg);
                    break;

                //Processing Channel Messages---------------------------------------------------------------------------
                case TYPE_R_SUBS_CHANNEL_MESG:
                    break;
                case TYPE_R_LOAD_CHANNEL_MESG:
                    break;
                case TYPE_R_SENT_CHANNEL_MESG:
                    break;
                default:
                    break;
            }
        }

        private static void BroadcastMesgToUser(PrivateMessage mesg)
        {
            if (UserIsOnline(mesg.RecvID))
            {
                Console.WriteLine("[LOG] Broadcasting message to user " + mesg.RecvID);
                Func<WebSocket, Task> action = async (socket) =>
                {
                    JsonGeneric obj = new JsonGeneric(TYPE_B_RECV_PRIVATE_MESG, JsonSerializer.Serialize<PrivateMessage>(mesg));
                    await SendDataToSocket(JsonSerializer.SerializeToUtf8Bytes<JsonGeneric>(obj), socket);
                };
                IterateUserSockets(mesg.RecvID, action);
            }
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
                    JsonGeneric userOnlineInform = new JsonGeneric(TYPE_B_INFO_USER_ONL, uid.ToString());
                    Func<WebSocket, Task> action = async (socket) => await BroadcastInfo(userOnlineInform, socket);
                    IterateUserSockets(fUid, action);
                    ///
                    Console.WriteLine("[LOG] Inform user {1} that user {0} is currently online", fUid, uid);
                    JsonGeneric friendOnlineInform = new JsonGeneric(TYPE_B_INFO_USER_ONL, fUid.ToString());
                    Task recvStatus = BroadcastInfo(friendOnlineInform, webSocket);
                }
            }
        }

        public static void InformUserOffline(int uid)
        {
            Console.WriteLine("[LOG] Informing that user {0} is just offline", uid);
            List<int> fUids = User.ListFriendUid(uid);
            foreach (int fUid in fUids)
            {
                if (UserIsOnline(fUid))
                {
                    Console.WriteLine("[LOG] Inform user {0} that user {1} is just offline", fUid, uid);
                    JsonGeneric userOnlineInform = new JsonGeneric(TYPE_B_INFO_USER_OFF, uid.ToString());
                    Func<WebSocket, Task> action = async (socket) => await BroadcastInfo(userOnlineInform, socket);
                    IterateUserSockets(fUid, action);
                }
            }
        }
        private static void IterateUserSockets(int uid, Func<WebSocket, Task> action)
        {
            List<ISession> sessionList = Extensions.SessionExtensions.GetUserSessions(uid);
            foreach (ISession session in sessionList)
            {
                foreach (WebSocket socket in session.GetSockets())
                {
                    Task doAction = action(socket);
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
    }
}