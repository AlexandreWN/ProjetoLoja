using Microsoft.EntityFrameworkCore;
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
            optionsBuilder.UseSqlServer("Data Source = JVLPC0565\\SQLEXPRESS; Initial Catalog = dd; Integrated Security = True");
           //optionsBuilder.UseSqlServer("Data Source = CTPC3616; Initial Catalog = ProjetoLoja; Integrated Security = True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(a => a.id);
                entity.Property(a => a.street);
                entity.Property(a => a.city);
                entity.Property(a => a.state);
                entity.Property(a => a.country);
                entity.Property(a => a.postal_code);
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
                entity.HasOne(p => p.address);
                entity.Property(p => p.password);
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
                entity.HasOne(p => p.address);
                entity.Property(p => p.password);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(pr => pr.id);
                entity.Property(pr => pr.name);
                entity.Property(pr => pr.bar_code);
            });
            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(pu => pu.id);
                entity.Property(pu => pu.number_confirmation);
                entity.Property(pu => pu.number_nf);
                entity.Property(pu => pu.payment_type);
                entity.Property(pu => pu.purchase_status);
                entity.Property(pu => pu.purchase_value);
                entity.HasOne(p => p.product);
                entity.HasOne(p => p.client);
                entity.HasOne(p => p.store);
            });
            modelBuilder.Entity<Stocks>(entity =>
            {
                entity.HasKey(s => s.id);
                entity.Property(s => s.quantity);
                entity.Property(s => s.unit_price);
                entity.HasOne(p => p.product);
                entity.HasOne(p => p.store);
                entity.Property(s => s.unit_price);

            });
            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(st => st.id);
                entity.Property(st => st.name);
                entity.Property(st => st.CNPJ);
                entity.HasOne(p => p.owner);

            });
            modelBuilder.Entity<WishList>(entity =>
            {
                entity.HasKey(w => w.id);
                entity.HasOne(c => c.client);
                entity.HasOne(p => p.product);
               
            });
        }
}
