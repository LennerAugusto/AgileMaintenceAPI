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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<ClientEntity>()
                .HasMany(c => c.Adresses)
                .WithOne(a => a.Client)
                .HasForeignKey(a => a.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<ClientEntity>()
                .HasMany(c => c.OrderServices)
                .WithOne(o => o.Client)
                .HasForeignKey(o => o.ClientId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
