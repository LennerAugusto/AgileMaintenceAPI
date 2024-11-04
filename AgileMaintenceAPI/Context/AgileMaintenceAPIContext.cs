using AgileMaintenceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AgileMaintenceAPI.Context
{
    public class AgileMaintenceAPIContext : DbContext 
    {
        public AgileMaintenceAPIContext(DbContextOptions<AgileMaintenceAPIContext> options) : base(options)
        {

        }

        public DbSet<ClientEntity> Clients { get; set; }  
        public DbSet<OrderServiceEntity> OrderServices { get; set; }  
        public DbSet<AdressesEntity> Adresses { get; set; }

    
    }
}
