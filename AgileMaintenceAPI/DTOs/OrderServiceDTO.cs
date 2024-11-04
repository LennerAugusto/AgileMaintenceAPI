using AgileMaintenceAPI.Models;

namespace AgileMaintenceAPI.DTOs
{
    public class OrderServiceDTO
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }  
        public string Vehicle { get; set; }
        public string Plate { get; set; }
        public string Defect { get; set; }
        public DateTime DateInit { get; set; }
        public DateTime DateEnd { get; set; }
        public bool isActive { get; set; }
        public ClientEntity Client { get; set; }

    }
}
