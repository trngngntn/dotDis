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
using Utils;
using DAL;

namespace Controllers
{
    public static class WebSocketController
    {
        private const int BUFFER_SIZE = 1024;
        private const int TYPE_R_SUBS_PRIVATE_MESG = 0;
        private const int TYPE_R_UNSB_PRVATE_MESG = 1;
        private const int TYPE_R_SUBS_CHANNEL_MESG = 2;
        private const int TYPE_R_UNSB_CHANNEL_MESG = 3;
        private const int TYPE_R_LOAD_PRIVATE_MESG = 4;
        private const int TYPE_R_LOAD_CHANNEL_MESG = 5;
        private const int TYPE_R_SENT_PRIVATE_MESG = 6;
        private const int TYPE_R_SENT_CHANNEL_MESG = 7;

        private const int TYPE_R_LOAD_ROOM_INFO = 100;
        private const int TYPE_B_INFO_ROOM_CHANNEL = 101;
        private const int TYPE_B_INFO_ROOM_MEMBER = 102;

        private const int TYPE_B_RECV_PRIVATE_MESG = 8;
        private const int TYPE_B_RECV_CHANNEL_MESG = 9;
        private const int TYPE_B_INFO_PRIVATE_MESG = 10;
        private const int TYPE_B_INFO_CHANNEL_MESG = 11;
        private const int TYPE_B_INFO_USER_ONL = 12;
        private const int TYPE_B_INFO_USER_OFF = 13;
        private const int TYPE_B_INFO_SEND_OK = 14;
        private const int TYPE_B_INFO_SEND_ERROR = 15;
        private const int TYPE_B_ACTN_LOG_OUT = -1;

        public static async Task InitSocket(HttpContext context, WebSocket webSocket)
        {
            int? uidN = context.Session.GetBindedUid();
            if (uidN == null)
            {
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
            ConsoleLogger.Log("Close Socket");
            context.Session.CloseSocket(webSocket);
        }

        public static async Task ReadDataFromSocket(HttpContext context, WebSocket webSocket)
        {
            Console.WriteLine("[LOG] Listening to Socket\n.............");
            byte[] buffer = new byte[BUFFER_SIZE];
            ArraySegment<byte> temp = new ArraySegment<byte>(buffer);
            try
            {
                WebSocketReceiveResult received = await webSocket.ReceiveAsync(temp, CancellationToken.None);
                List<byte> dataByte = new List<byte>();
                while (!received.CloseStatus.HasValue)
                {
                    if (received.EndOfMessage) // receive final mesg part
                    {
                        dataByte.AddRange(buffer.Take(received.Count));
                        string data = Encoding.UTF8.GetString(dataByte.ToArray());
                        JsonGeneric obj = JsonSerializer.Deserialize<JsonGeneric>(data);
                        Process(obj.Type, obj.Data, context.Session, webSocket);
                        dataByte = new List<byte>();
                    }
                    else
                    {
                        dataByte.AddRange(buffer);
                    }
                    // continue waiting to receive data
                    received = await webSocket.ReceiveAsync(temp, CancellationToken.None);
                }
            }
            catch (WebSocketException)
            {
                ConsoleLogger.Warn("Socket closed prematurely");
            }
            finally
            {
                CloseSocket(context, webSocket);
            }
        }

        private static void Process(int type, string data, ISession session, WebSocket socket)
        {
            Console.WriteLine("[LOG] Processing message type: " + type);
            switch (type)
            {
                //Processing Private Messages---------------------------------------------------------------------------
                case TYPE_R_SUBS_PRIVATE_MESG:
                    {
                        int uid = Int32.Parse(data);
                        // to do
                    }

                    break;
                case TYPE_R_UNSB_PRVATE_MESG:
                    {
                        int uid = Int32.Parse(data);
                        // to do
                    }
                    break;
                case TYPE_R_LOAD_PRIVATE_MESG:
                    {
                        string[] info = data.Split(";");
                        int uid = Int32.Parse(info[0]);
                        int index = Int32.Parse(info[1]);
                        List<PrivateMessage> mesgList = PrivateMessageDAO.Get((int)session.GetBindedUid(), uid, index);
                        JsonGeneric obj = new JsonGeneric(TYPE_B_INFO_PRIVATE_MESG,
                        JsonSerializer.Serialize<List<PrivateMessage>>(mesgList)
                        );
                        Task b = BroadcastInfo(obj, socket);
                    }
                    break;
                case TYPE_R_SENT_PRIVATE_MESG:
                    {
                        Console.Write("DAMNNNNN:" + data);
                        PrivateMessage mesg = JsonSerializer.Deserialize<PrivateMessage>(data);
                        int result = mesg.SendPrivateMessage();
                        if (result > 0)
                        {
                            BroadcastMesgToUser(mesg);
                        }
                        else
                        {
                            JsonGeneric obj = new JsonGeneric(TYPE_B_INFO_SEND_ERROR, "Sent error!");
                            Task t = BroadcastInfo(obj, socket);
                        }

                    }
                    break;

                //Processing Channel Messages---------------------------------------------------------------------------
                case TYPE_R_SUBS_CHANNEL_MESG:
                    break;
                case TYPE_R_LOAD_CHANNEL_MESG:
                    {
                        string[] info = data.Split(";");
                        int channelId = Int32.Parse(info[0]);
                        int index = Int32.Parse(info[1]);
                        List<ChannelMessage> mesgList = ChannelMessageDAO.Get(channelId, index);
                        JsonGeneric obj = new JsonGeneric(TYPE_B_INFO_CHANNEL_MESG,
                        JsonSerializer.Serialize<List<ChannelMessage>>(mesgList)
                        );
                        Task b = BroadcastInfo(obj, socket);
                    }
                    break;
                case TYPE_R_SENT_CHANNEL_MESG:
                    {
                        ChannelMessage mesg = JsonSerializer.Deserialize<ChannelMessage>(data);
                        mesg.SendChannelMessage();
                        BroadcastMesgToChannel(mesg);
                    }
                    break;
                //Processing Room
                case TYPE_R_LOAD_ROOM_INFO:
                    {
                        int roomId = data.ToInt();
                        // broadcast channels
                        List<Channel> channels = ChannelDAO.Get(roomId, (int)session.GetBindedUid());
                        JsonGeneric obj = new JsonGeneric(TYPE_B_INFO_ROOM_CHANNEL, JsonSerializer.Serialize<List<Channel>>(channels));
                        Task t = BroadcastInfo(obj, socket);
                        List<User> members = RoomDAO.GetMembers(roomId);
                        obj = new JsonGeneric(TYPE_B_INFO_ROOM_MEMBER, JsonSerializer.Serialize<List<User>>(members));
                        Task t1 = BroadcastInfo(obj, socket);
                    }
                    break;
                default:
                    break;
            }
        }

        private static void BroadcastMesgToUser(PrivateMessage mesg)
        {
            if (UserIsOnline(mesg.RecvID))
            {
                ConsoleLogger.Error("Broadcast MESG from UID:{0} to UID:{1}", mesg.SendID, mesg.RecvID);
                Func<WebSocket, Task> action = async (socket) =>
                {
                    JsonGeneric obj = new JsonGeneric(TYPE_B_RECV_PRIVATE_MESG, JsonSerializer.Serialize<PrivateMessage>(mesg));
                    await socket.SendData(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<JsonGeneric>(obj)));
                };
                IterateUserSockets(mesg.RecvID, action);
            }
        }


        private static void BroadcastMesgToChannel(ChannelMessage mesg)
        {
            List<int> uidList = ChannelDAO.GetAccessibleUID(mesg.ChannelID); /// list of user have permission to read message from channel
            foreach (int uid in uidList)
            {
                if (UserIsOnline(uid))
                {
                    ConsoleLogger.Log("Send new MESG UID:{0},CHAN:{1} to UID:{2}", mesg.SendID, mesg.ChannelID, uid);
                    Func<WebSocket, Task> action = async (socket) =>
                    {
                        JsonGeneric obj = new JsonGeneric(TYPE_B_RECV_CHANNEL_MESG, JsonSerializer.Serialize<ChannelMessage>(mesg));
                        await socket.SendData(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<JsonGeneric>(obj)));
                    };
                    IterateUserSockets(uid, action);
                }
            }
        }

        private static void BroadcastNotf(string uid)
        {

        }

        private static async Task BroadcastInfo(JsonGeneric obj, WebSocket socket)
        {
            await socket.SendData(JsonSerializer.SerializeToUtf8Bytes<JsonGeneric>(obj));
        }

        private static bool UserIsOnline(int uid)
        {
            return Extensions.SessionExtensions.UserIsOnline(uid);
        }

        private static void InformUserOnline(int uid, WebSocket webSocket)
        {
            ConsoleLogger.Log("Inform UID:{0} is online", uid);
            List<int> fUids = User.ListFriendUid(uid);
            foreach (int fUid in fUids)
            {
                if (UserIsOnline(fUid))
                {
                    ///
                    ConsoleLogger.Log("Inform UID:{0} is online to UID:{1}", uid, fUid);
                    JsonGeneric userOnlineInform = new JsonGeneric(TYPE_B_INFO_USER_ONL, uid.ToString());
                    Func<WebSocket, Task> action = async (socket) => await BroadcastInfo(userOnlineInform, socket);
                    IterateUserSockets(fUid, action);
                    ///
                    ConsoleLogger.Log("Inform back UID:{1} is online to UID:{0}", uid, fUid);
                    JsonGeneric friendOnlineInform = new JsonGeneric(TYPE_B_INFO_USER_ONL, fUid.ToString());
                    Task recvStatus = BroadcastInfo(friendOnlineInform, webSocket);
                }
            }
        }

        public static void InformUserOffline(int uid)
        {
            ConsoleLogger.Log("Inform UID:{0} is offline", uid);
            List<int> fUids = User.ListFriendUid(uid);
            foreach (int fUid in fUids)
            {
                if (UserIsOnline(fUid))
                {
                    ConsoleLogger.Log("Inform UID:{0} is offline to UID:{1}", uid, fUid);
                    JsonGeneric userOnlineInform = new JsonGeneric(TYPE_B_INFO_USER_OFF, uid.ToString());
                    Func<WebSocket, Task> action = async (socket) => await BroadcastInfo(userOnlineInform, socket);
                    IterateUserSockets(fUid, action);
                }
            }
        }
        private static void IterateUserSockets(int uid, Func<WebSocket, Task> action)
        {
            Console.Write("[LOG] Iterating user {0} sockets", uid);
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