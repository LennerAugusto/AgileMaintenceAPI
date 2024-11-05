using AgileMaintenceAPI.Models;

namespace AgileMaintenceAPI.DTOs.ClientDTO
{
    public class ClientCreateDTO
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public AdressesEntity Adresses { get; set; }
    }
}
