using Microsoft.EntityFrameworkCore;
using RentalVideoSystem.Modals;

namespace restapipractise.Data
{
    public class ContextFile : DbContext
    {
        public ContextFile(DbContextOptions<ContextFile> options) : base(options)
        {

        }
        public DbSet<Customer> CustomerObject { get; set; }
        public DbSet<Manager> ManagerObject { get; set; }
        public DbSet<VideoCasste> VideoCasseteObject { get; set; }
        public DbSet<Store> SingleStore { get; set; }
        public DbSet<Collection> Collection { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>().HasData(
                new Manager
                {
                    ManagerId = 1,
                    Name = "MAMB",
                    Email = "ali123mazhar@gmail.com",
                    MobileNumber = "03035024309"
                });
                modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    Name = "MAMB",
                    Email = "ali123mazhar@gmail.com",
                    MobileNumber = "03035024309"
                });
            modelBuilder.Entity<VideoCasste>().HasData(
            new VideoCasste
            {
                VideoId = 1,
                TitleName = "Abcd2",
                Description = "This is the flop movie and one of the floppest movies in the world",
                Price = 5
            }
            );
        }
    }
}
