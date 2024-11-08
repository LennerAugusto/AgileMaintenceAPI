using System.ComponentModel.DataAnnotations.Schema;

namespace AgileMaintenceAPI.Models
{
    [Table("AutoRepair")]
    public class AutoRepairEntity : BaseEnitty
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }

    }
}
