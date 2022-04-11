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
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Haskey(a => a.Id);
                entity.Property(a => a.street);
                entity.Property(a => a.city);
                entity.Property(a => a.state);
                entity.Property(a => a.country);
                entity.Property(a => a.post_code);
            });
            modelBuilder.Entity<Client>(entity =>
            {

                entity.HasKey(p => p.id);
                entity.Property(p => p.name);
                entity.Property(p => p.date_of_birth);
                entity.Property(p => p.document);
                entity.Property(p => p.email);
                entity.Property(p => p.phone);
                entity.Property(p => p.login);
            });
            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(p => p.id);
                entity.Property(p => p.name);
                entity.Property(p => p.date_of_birth);
                entity.Property(p => p.document);
                entity.Property(p => p.email);
                entity.Property(p => p.phone);
                entity.Property(p => p.login);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Haskey(pr => pr.id);
                entity.Property(pr => pr.name);
                entity.Property(pr => pr.unit_price);
                entity.Property(pr => pr.bar_code);
            });
            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.Haskey(pu => pu.id);
                entity.HasOne(pr => pr.Product).WithMany(pu => pu.Purchase);
                entity.HasOne(p => p.Client).WithMany(pu => pu.Purchase);
                entity.Property(pu => pu.payment);
                entity.Property(pu => pu.number_confirmation);
                entity.Property(pu => pu.number_nf);
                entity.Property(pu => pu.payment_type);
                entity.Property(pu => pu.puchaseStatusEnum);
            });
            modelBuilder.Entity<Stocks>(entity =>
            {
                entity.HasKey(s => s.id);
                entity.Property(s => s.product);
                entity.Property(s => s.quantity);
            });
            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(st => st.id);
                entity.Property(st => st.name);
                entity.Property(st => st.cnpj);
            });
            modelBuilder.Entity<WishList>(entity =>
            {
                entity.HasOne(c => c.Client).WithMany(c => c.WishList);
                entity.HasOne(p => p.Product).WithMany(p => p.WishList);
            });
        }
}
