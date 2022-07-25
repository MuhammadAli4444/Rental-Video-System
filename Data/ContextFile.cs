using Microsoft.EntityFrameworkCore;
using RentalVideoSystem.Modals;

namespace restapipractise.Data
{
    public class ContextFile : DbContext
    {
        public ContextFile(DbContextOptions<ContextFile> options) : base(options)
        {

        }
        public DbSet<Store> Store { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Manager> ManagerTable { get; set; }
        public DbSet<VideoCasste> VideoCassete { get; set; }
        public DbSet<ReminderEmail> ReminderEmail { get; set; }
        public DbSet<VideoCassete> RentalVideoCasset { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //  base.OnModelCreating(modelBuilder);
           // modelBuilder.Seed();
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    GenericId = 1,
                    Name = "MAMB",
                    Email = "ali123mazhar@gmail.com",
                    MobileNumber = "03035024309",
                    Role = "Manager"
                },
                  new ApplicationUser
                  {
                      GenericId = 2,
                      Name = "Abdullah",
                      Email = "abdullah@gmail.com",
                      MobileNumber = "03035024308",
                      Role = "Customer"
                  }
                ) ;
            modelBuilder.Entity<Manager>().HasData(
new Manager
{

Id = 1
});
            modelBuilder.Entity<Customer>().HasData(
new Customer
{

    Id = 1
});
            modelBuilder.Entity<VideoCasste>().HasData(
new VideoCasste
{
    VideoId = 1,
    TitleName = "Abcd2",
    Description = "Amazing movie",
    Price = 100
});

        }
    }
}
