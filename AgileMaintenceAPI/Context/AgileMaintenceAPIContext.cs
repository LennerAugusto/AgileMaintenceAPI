using AgileMaintenceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AgileMaintenceAPI.Context
{
    public class AgileMaintenceAPIContext : DbContext 
    {
        public AgileMaintenceAPIContext(DbContextOptions<AgileMaintenceAPIContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }  
        public DbSet<OrderService> OrderServices { get; set; }  
    }
}
