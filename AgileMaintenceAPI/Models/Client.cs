using Microsoft.AspNetCore.SignalR;
using System.Collections.ObjectModel;

namespace AgileMaintenceAPI.Models
{
    public class Client
    {
        public Client()
        {
            OrderServices = new Collection<OrderService>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }

        public ICollection<OrderService> OrderServices  { get; set; }
    }
}
