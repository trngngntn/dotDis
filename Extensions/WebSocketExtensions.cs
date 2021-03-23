using System;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Models;

namespace Extensions{
    public static class WebSocketExtension{

        private const int BUFFER_SIZE = 1024;
        private static ConcurrentDictionary<WebSocket, JsonGeneric> socketInfo;
        public static async Task SendData(this WebSocket socket, byte[] data)
        {
            int offset = 0, length = BUFFER_SIZE;
            while (offset < data.Length)
            {
                length = (data.Length - offset) < BUFFER_SIZE ? (data.Length - offset) : BUFFER_SIZE;
                //Console.WriteLine("[LOG] offset = {0}, length = {1}, data = {2}", offset, length, data.Length);
                await socket.SendAsync(
                    new ArraySegment<byte>(data, offset, length),
                    WebSocketMessageType.Text,
                    (offset + length) == data.Length, CancellationToken.None
                );
                offset += length;
            }
        }
        public static void SetSubscriber(this WebSocket socket, JsonGeneric info)
        {
        }
    }
}