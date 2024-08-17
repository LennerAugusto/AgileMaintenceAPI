using System.Collections.ObjectModel;

namespace AgileMaintenceAPI.Models
{
    public class Adresses
    { 
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Logradouro { get; set; }  
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public DateTime DateCreated { get; set; } 
        public DateTime DateUpdated { get; set; }  
        public Client Client { get; set; }
    }
}
