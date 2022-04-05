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
            modelBuilder.Properties<string>().Where(p => p.Name == "document").Configure(p => p.IsKey());
        }
    }
}