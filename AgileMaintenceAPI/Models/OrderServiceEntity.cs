using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgileMaintenceAPI.Models
{
    [Table("OrderService")]
    public class OrderServiceEntity : BaseEnitty
    {
        public Guid ClientId { get; set; }
        public string Vehicle { get; set; }
        public string Plate { get; set; }
        public string Defect { get; set; }
        public DateTime DateInit {  get; set; }
        public DateTime DateEnd { get; set; }   
        public Guid AutoRepairID { get; set; }
        public ClientEntity Client { get; set; }
    }
}
