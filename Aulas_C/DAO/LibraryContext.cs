using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
=======

>>>>>>> 6765947ef58cfb7277eeca4db0d225d34c1ee2dc

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
            optionsBuilder.UseSqlServer("Data Source=(local)\\JVLPC0565\\SQLEXPRESS;Database=ProjetoLojaTeste;Integrated Security=sspi;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
<<<<<<< HEAD
            modelBuilder.Entity<Client>(entity =>
            {

                entity.HasKey(p => p.Id);
                entity.Property(p => p.name).IsRequired();
                entity.Property(p => p.date_of_birth).IsRequired();
                entity.Property(p => p.document).IsRequired();
                entity.Property(p => p.email).IsRequired();
                entity.Property(p => p.phone).IsRequired();
                entity.Property(p => p.login).IsRequired();
            });
            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.name).IsRequired();
                entity.Property(p => p.date_of_birth).IsRequired();
                entity.Property(p => p.document).IsRequired();
                entity.Property(p => p.email).IsRequired();
                entity.Property(p => p.phone).IsRequired();
                entity.Property(p => p.login).IsRequired();
            });
=======
>>>>>>> 6765947ef58cfb7277eeca4db0d225d34c1ee2dc
        }
}
