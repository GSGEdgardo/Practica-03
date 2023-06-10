using Microsoft.EntityFrameworkCore;


namespace API.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reserve> Reserves { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { id = 1, code = "codigo1", name = "Prof. Aleen Konopelsk", faculty = "Voluptatibus quia voluptatem quia nisi." },
                new User { id = 2, code = "codigo2", name = "Antoinette Mayer", faculty = "Animi laboriosam voluptatum assumenda odit." }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book { id = 1, code = "codigolibro1", book = "Yvette Corwin V", description = "Ea non nesciunt distinctio aspernatur eum id id" },
                new Book { id = 2, code = "codigolibro2", book = "Felipa Lindgren DVM", description = "lure quibusdam aut quo qui pariatur eum libero." }
            );
            modelBuilder.Entity<Reserve>().HasData(
                new Reserve { id = 1, user_id = 1, book_id = 1, reserved_at = DateTime.Now.AddDays(-7) },
                new Reserve { id = 2, user_id = 1, book_id = 2, reserved_at = DateTime.Now.AddDays(-100) },
                new Reserve { id = 3, user_id = 2, book_id = 1, reserved_at = DateTime.Now.AddDays(-10) },
                new Reserve { id = 4, user_id = 2, book_id = 2, reserved_at = DateTime.Now.AddDays(-1) }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}

