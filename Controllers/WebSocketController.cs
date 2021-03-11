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
        private static Dictionary<int, List<UserSession>> userBinding = new Dictionary<int, List<UserSession>>();

        public async Task InitSocket(HttpContext context, WebSocket webSocket)
        {
            int uid = (int)context.Session.GetInt32("active-user");
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
            else // user change state from offline to online
            {
                List<UserSession> newUSessionList = new List<UserSession>();
                UserSession newUSession = new UserSession(context.Session);
                newUSession.AddSocket(webSocket);
                newUSessionList.Add(newUSession);
                userBinding.Add(uid, newUSessionList);
                Console.WriteLine("Add new user binding");
                InformUserOnline(uid, webSocket);
            }
            await ProcessData(context, webSocket);
        }

        private async Task CloseSocket(HttpContext context, WebSocket webSocket)
        {
            int uid = (int)context.Session.GetInt32("active-user");
            await InformUserOffline(uid);
            List<UserSession> uSessionList = userBinding[uid];
            bool endSession = false;
            UserSession temp = null;
            //context.Session.R
            foreach (UserSession userSession in uSessionList)
            {
                userSession.GetSockets().Remove(webSocket);
                if (userSession.GetSockets().Count == 0)
                {
                    endSession = true;
                    temp = userSession;
                }
            }
            if (endSession)
            {
                //temp.
                uSessionList.Remove(temp);
                if (uSessionList.Count == 0)
                {
                    userBinding.Remove(uid);
                }
            }

        }

        public async Task ProcessData(HttpContext context, WebSocket webSocket)
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
                    //temp.ToArray();
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
                //await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, none);
                received = await webSocket.ReceiveAsync(temp, CancellationToken.None);
            }
            // close socket
            Task closeSocket = CloseSocket(context, webSocket);
        }

        private async Task Process(string type, string data)
        {
            foreach (KeyValuePair<int, List<UserSession>> kvp in userBinding)
            {
                Console.WriteLine("Key = {0}", kvp.Key);
            }

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

        private async Task BroadcastMesgToUser(PrivateMessage mesg)
        {
            if (UserIsOnline(mesg.RecvID))
            {
                Console.WriteLine("[LOG] Broadcasting message to user " + mesg.RecvID);
                List<UserSession> uSessions = userBinding[mesg.RecvID];
                foreach (UserSession uSession in uSessions)
                {
                    foreach (WebSocket webSocket in uSession.GetSockets())
                    {
                        JsonGeneric obj = new JsonGeneric("recv_private_message", JsonSerializer.Serialize<PrivateMessage>(mesg));
                        await SendDataToSocket(JsonSerializer.SerializeToUtf8Bytes<JsonGeneric>(obj), webSocket);
                    }
                }
            }
        }

        private async Task SendDataToSocket(byte[] data, WebSocket webSocket)
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
        private void BroadcastMesgToChannel(ChannelMessage mesg)
        {

        }

        private void BroadcastNotf(string uid)
        {

        }

        private async Task BroadcastInfo(JsonGeneric obj, WebSocket webSocket)
        {
            await SendDataToSocket(JsonSerializer.SerializeToUtf8Bytes<JsonGeneric>(obj), webSocket);
        }

        private bool UserIsOnline(int uid)
        {
            return userBinding.ContainsKey(uid);
        }

        private async Task InformFriendStatus(int uid, WebSocket socket)
        {
            Console.WriteLine("[LOG] Informing friend status to user {0}", uid);
            List<int> fUids = User.ListFriendUid(uid);
            List<UserStatus> userStatus = new List<UserStatus>();
            foreach (int fUid in fUids)
            {
                if (UserIsOnline(fUid)) userStatus.Add(new UserStatus(fUid, 1));
                else userStatus.Add(new UserStatus(fUid, 0));
            }
            JsonGeneric obj = new JsonGeneric("friend_status", JsonSerializer.Serialize<List<UserStatus>>(userStatus));
            await BroadcastInfo(obj, socket);
        }
        private void InformUserOnline(int uid, WebSocket webSocket)
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
                    Task sendStatus = IterateUserSocket(fUid, action);
                    ///
                    Console.WriteLine("[LOG] Inform user {1} that user {0} is currently online", fUid, uid);
                    JsonGeneric friendOnlineInform = new JsonGeneric("user_online", fUid.ToString());
                    Task recvStatus = BroadcastInfo(friendOnlineInform,webSocket);
                }
            }
        }
        
        private async Task InformUserOffline(int uid)
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
                    await IterateUserSocket(fUid, action);
                }
            }
        }
        private async Task IterateUserSocket(int uid, Func<WebSocket, Task> action)
        {
            List<UserSession> uSessionList = userBinding[uid];
            foreach (UserSession uSession in uSessionList)
            {
                foreach (WebSocket socket in uSession.GetSockets())
                {
                    await action(socket);
                }
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