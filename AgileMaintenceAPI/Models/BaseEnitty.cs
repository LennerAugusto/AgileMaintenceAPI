using System.Text.Json.Serialization;

namespace AgileMaintenceAPI.Models
{
    public class BaseEnitty
    {
        
        public Guid Id { get; set; } = Guid.NewGuid();
        private DateTime DateCreated { get; set; } = DateTime.Now;
        private DateTime DateUpdated { get; set; }
        public bool IsAcive { get; set; }

        public void Update()
        {
            DateUpdated = DateTime.UtcNow;
        }
    }
}
