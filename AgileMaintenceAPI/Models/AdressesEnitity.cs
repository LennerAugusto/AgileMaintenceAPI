using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AgileMaintenceAPI.Models
{
    [Table("Adresses")]
    public class AdressesEntity : BaseEnitty
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Logradouro { get; set; }  
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        
        [JsonIgnore]
        public ClientEntity? Client { get; set; }
    }
}
