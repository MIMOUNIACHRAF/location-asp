using Microsoft.EntityFrameworkCore;

namespace Location_Voiture.Models
{
    public class MyContext :DbContext
    {
        public MyContext(DbContextOptions<MyContext>options):base(options)
        { }
        public DbSet<User> Users { get; set;}
        public DbSet<Voiture> Voitures { get; set;}
        public DbSet<Marque> Marques { get; set;}
        public DbSet<Assurance> Assurances { get; set;}
        public DbSet<Client> Clients { get; set;}
        public DbSet<Location> Locations { get; set;}
    }
}
