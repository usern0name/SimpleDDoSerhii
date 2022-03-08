using System;
using System.Text;
using SimpleDDoSerhii.Clients;
using SimpleDDoSerhii.Entites;
namespace SimpleDDoSerhii
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    new ConsoleInterface();
                }
                else
                {
                    var endPointAddress = args[0];
                    var destinationPort = args.Length > 1 ? int.Parse(args[1]) : 53;
                    var protocol = args.Length > 2 ? args[2] : "UDP";
                    Up(new NetworkCredentional { DestinationPort = destinationPort, EndPointAddress = endPointAddress, Protocol = protocol });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Up(NetworkCredentional nc)
        {
            switch (nc.Protocol)
            {
                case "UDP":
                    StartDdos(new UdpManager(), nc);
                    break;
                case "TCP":
                    StartDdos(new TcpManager(), nc);
                    break;
                default:
                    StartDdos(new TcpManager(), nc);
                    break;
            }
        }
        public static void StartDdos(CreatorClientManager creator, NetworkCredentional networkCredentional)
        {
            creator.PoslatRusskiyKorabl(networkCredentional);
        }


    }
}