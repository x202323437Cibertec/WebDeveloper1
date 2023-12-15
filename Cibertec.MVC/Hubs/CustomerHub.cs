using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cibertec.MVC.Hubs
{
    public class CustomerHub : Hub
    {

        static List<string> CustomersIds = new List<string>();

        public void AddCustomerId(string pId)
        {
            if (!CustomersIds.Contains(pId)) CustomersIds.Add(pId);
            Clients.All.customerStatus(CustomersIds);
        }

        public void RemoveCustomerId(string pId)
        {
            if (CustomersIds.Contains(pId)) CustomersIds.Remove(pId);
            Clients.All.customerStatus(CustomersIds);
        }

        public override Task OnConnected()
        { 
            return Clients.All.customerStatus(CustomersIds);
        }

        public void Message(string pMessage)
        {
            Clients.All.getMessage(pMessage);
        }
    }
}