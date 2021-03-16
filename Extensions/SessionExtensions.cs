using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Controllers;
using Microsoft.AspNetCore.Http;
using Models.Collections;

namespace Extensions
{
    public static class SessionExtensions
    {
        static string sessionId;
        private static ConcurrentDictionary<ISession, ConcurrentMap<string, object>> sessionItems;
        private static ConcurrentDictionary<ISession, List<WebSocket>> sessionSockets;
        private static ConcurrentDictionary<int, List<ISession>> userBindings;
        static ConcurrentMap<string, ISession> sessionMap;
        static SessionExtensions()
        {
            sessionItems = new ConcurrentDictionary<ISession, ConcurrentMap<string, object>>();
            sessionSockets = new ConcurrentDictionary<ISession, List<WebSocket>>();
            userBindings = new ConcurrentDictionary<int, List<ISession>>();
        }

        public static void InitSession(this ISession session)
        {
        }

        public static void Kill(this ISession session)
        {
            int uid = (int)session.GetBindedUid();
            userBindings[uid].Remove(session);
            if(sessionSockets.ContainsKey(session)){
                sessionSockets.Remove(session, out _);
            }
            if (userBindings[uid].Count == 0) // no more active session from user
            {
                WebSocketController.InformUserOffline(uid);
                userBindings.Remove(uid, out _);
            }
            //session.Clear();
        }

        public static void Set<T>(this ISession session, string key, T value)
        {
            sessionItems[session][key] = value;
        }

        public static T Get<T>(this ISession session, string key)
        {
            return (T)sessionItems[session][key];
        }

        /// Uid related methods -----------------------------------------------------------
        public static int? GetBindedUid(this ISession session)
        {
            return session.GetInt32("active-user");
        }

        public static void BindToUid(this ISession session, int uid)
        {
            if (!userBindings.ContainsKey(uid))
            {
                userBindings[uid] = new List<ISession>();
            }
            userBindings[uid].Add(session);
        }

        public static bool IsBindedToUid(this ISession session, int uid)
        {
            return userBindings[uid].Contains(session);
        }

        /// WebSocket related methods -----------------------------------------------------
        public static void AddSocket(this ISession session, WebSocket webSocket)
        {
            if(!sessionSockets.ContainsKey(session))
            {
                sessionSockets[session] = new List<WebSocket>();
            }
            sessionSockets[session].Add(webSocket);
        }

        public static List<WebSocket> GetSockets(this ISession session)
        {
            return sessionSockets[session];
        }

        public static void CloseSocket(this ISession session, WebSocket socket)
        {
            sessionSockets[session].Remove(socket);
            if (sessionSockets[session].Count == 0)
            {
                sessionSockets.Remove(session, out _);
                Kill(session);
            }
            socket.Abort();
        }

        public static List<ISession> GetUserSessions(int uid)
        {
            return userBindings[uid];
        }

        public static bool UserIsOnline(int uid)
        {
            return userBindings.ContainsKey(uid);
        }

    }
}