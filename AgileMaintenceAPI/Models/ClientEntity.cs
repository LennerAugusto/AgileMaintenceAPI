using Microsoft.AspNetCore.SignalR;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AgileMaintenceAPI.Models
{
    [Table("Client")]
    public class ClientEntity : BaseEnitty
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }

        public ICollection<AdressesEntity>? Adresses { get; set; }
        [JsonIgnore]
        public ICollection<OrderServiceEntity>? OrderServices  { get; set; }

    }
}
