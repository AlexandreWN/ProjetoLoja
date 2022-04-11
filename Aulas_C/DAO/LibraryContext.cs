using Microsoft.EntityFrameworkCore;
using MySQL.EntityFrameworkCore.Extensions;

namespace DAO;
public class LibraryContext : DbContext
{
        //Mapeamento de entidade para tabela
        public DbSet<Address> Address { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Stocks> Stocks { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<WishList> WishList { get; set; }

          //provedor e string de conexão
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(local)\JVLPC0565\SQLEXPRESS;Database=ProjetoLojaTeste;Integrated Security=sspi;")
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
<<<<<<< HEAD
             
=======
             base.OnModelCreating(modelBuilder);
             modelBuilder.Entity<Person> (entity =>
                entity.Property
                
             )

>>>>>>> d07f0f5964bf9c55f94a7029eac3f6681e8e50da
        }
}
