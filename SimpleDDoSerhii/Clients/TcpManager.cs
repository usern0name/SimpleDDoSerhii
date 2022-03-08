using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDDoSerhii.Clients
{
    public class TcpManager : CreatorClientManager
    {
        public override IClient CreateClientManager()
        {
            return new TcpClient();
        }

    }
}
