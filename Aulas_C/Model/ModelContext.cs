using Interfaces;
using System;
using Microsoft.EntityFrameworkCore;
namespace Model;

public class ModelContext : DbContext
{
	public ModelContext()
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            //REFERENTES A ADDRESS
            modelBuilder.Properties<string>().Where(a => a.Name == "street");
            modelBuilder.Properties<string>().Where(a => a.Name) == "city");
            modelBuilder.Properties<string>().Where(a => a.Name) == "state");
            modelBuilder.Properties<string>().Where(a => a.Name) == "country");
            modelBuilder.Properties<string>().Where(a => a.Name) == "post_code"); throw new NotImplementedException();

            //REFERENTES A CLIENT
            modelBuilder.Entity<Client>().Property<int>("PersonForeignKey");
            modelBuilder.Entity<Client>().HasOne(c => c.Person).WithMany(p => p.Client).HasForeignKey("PersonForeignKey");

            //REFERENTES A OWNER
            modelBuilder.Entity<Owner>().Property<int>("PersonForeignKey");
            modelBuilder.Entity<Ownert>().HasOne(c => c.Person).WithMany(own => own.Owner).HasForeignKey("PersonForeignKey");

        //REFERENTES A PERSON
        modelBuilder.Properties<string>().Where(per => per.Name) == "name");
            modelBuilder.Properties<int>().Where(per => per.Name) == "age");
            modelBuilder.Properties<string>().Where(per => per.Name) == "document");
            modelBuilder.Properties<string>().Where(per => per.Name) == "email");
            modelBuilder.Properties<string>().Where(per => per.Name) == "phone");
            modelBuilder.Properties<string>().Where(per => per.Name) == "login");

            //REFERENTES A PRODUCT
            modelBuilder.Properties<string>().Where(pro => pro.Name) == "name");
            modelBuilder.Properties<double>().Where(pro => pro.Name) == "unit_price");
            modelBuilder.Properties<string>().Where(pro => pro.Name) == "bar_code");

            //REFERENTES A PURCHASE
            modelBuilder.Properties<DateTime>().Where(pur => pur.Name) == "date_purchase");
            modelBuilder.Properties<string>().Where(pur => pur.Name) == "payment");
            modelBuilder.Properties<string>().Where(pur => pur.Name) == "number_confirmation");
            modelBuilder.Properties<string>().Where(pur => pur.Name) == "number_nf");
            modelBuilder.Properties<int>().Where(pur => pur.Name) == "payment_type");
            modelBuilder.Properties<int>().Where(pur => pur.Name) == "purchaseStatusEnum");

            //REFERENTES A STOCKS
            modelBuilder.Properties<int>().Where(stoc => stoc.Name) == "quantity");

            //REFERENTES A STORE
            modelBuilder.Properties<int>().Where(stor => stor.Name) == "name");
            modelBuilder.Properties<int>().Where(stor => stor.Name) == "cnpj");

            //REFERENTES A WISHLIST

        }
    }
}