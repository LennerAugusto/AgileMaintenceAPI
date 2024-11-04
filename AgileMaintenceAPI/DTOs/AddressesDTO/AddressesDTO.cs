namespace AgileMaintenceAPI.DTOs.AddressesDTO
{
    public class AddressesDTO
    {
        public bool IsActive { get; set; }
        public string ClientId { get; set; }  
        public string Name { get; set; }
        public string Number { get; set; }
        public string Logradouro { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
    }
}
