using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleDDoSerhii.Entites;

namespace SimpleDDoSerhii.Clients
{
    public interface IClient
    {
        void StartAttack(NetworkCredentional networkCredentional);
    }
}
