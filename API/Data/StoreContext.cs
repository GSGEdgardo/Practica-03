using Microsoft.EntityFrameworkCore;


namespace API.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { id = 1, name = "customer1", rut = "20.416.853-9"},
                new Customer { id = 2, name = "customer2", rut = "12.613.809-1"}
            );
            modelBuilder.Entity<Dish>().HasData(
                new Dish { id = 1, name = "Pollo con papas", price = 8000},
                new Dish { id = 2, name = "Cazuela", price = 5000}
            );
            modelBuilder.Entity<Purchase>().HasData(
                new Purchase { id = 1, customer_id = 1, dish_id = 1, created_at = DateTime.Now.AddDays(-7), updated_at = DateTime.Now.AddDays(-7)  },
                new Purchase { id = 2, customer_id = 1, dish_id = 2, created_at = DateTime.Now.AddDays(-100), updated_at = DateTime.Now.AddDays(-100) },
                new Purchase { id = 3, customer_id = 2, dish_id = 1, created_at = DateTime.Now.AddDays(-10), updated_at = DateTime.Now.AddDays(-10) }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}

