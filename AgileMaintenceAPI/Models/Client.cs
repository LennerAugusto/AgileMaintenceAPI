using Microsoft.AspNetCore.SignalR;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public ICollection<Adresses> Adresses { get; set; }
        [JsonIgnore]
        public ICollection<OrderService> OrderServices  { get; set; }

    }
}
