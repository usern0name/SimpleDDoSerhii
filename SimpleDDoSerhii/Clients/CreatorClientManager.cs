using System.Threading;
using SimpleDDoSerhii.Entites;
namespace SimpleDDoSerhii.Clients
{
    public abstract class CreatorClientManager 
    {
        public abstract IClient CreateClientManager();
        public void PoslatRusskiyKorabl(NetworkCredentional networkCredentional)
        {
            var client = CreateClientManager();
            Thread thread = new Thread(() => client.StartAttack(networkCredentional));
            thread.Start();
           
        }
    }
}
