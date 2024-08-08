using AgileMaintenceAPI.Models;
using System.Runtime.InteropServices;

namespace AgileMaintenceAPI.DTOs
{
    public class ClientDTO
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }    
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public List<OrderService> orderServices { get; set; }
    }
}
