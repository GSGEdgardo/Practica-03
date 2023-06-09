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
                new Book { id = 1, code = "codigolibro1", book = "Yvette Corwin V", cant_reserved = 0, description = "Ea non nesciunt distinctio aspernatur eum id id" },
                new Book { id = 2, code = "codigolibro2", book = "Felipa Lindgren DVM", cant_reserved = 0, description = "lure quibusdam aut quo qui pariatur eum libero." }
            );
        }
    }
}

