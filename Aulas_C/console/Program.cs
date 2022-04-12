using System;
using System.Text;
using DAO;


      using(var context = new LibraryContext())
      {
        // Creates the database if not exists
        context.Database.EnsureCreated();
    
        // Adds some books
        context.Product.Add(new Product
        {
          name = "The Lord of the Rings",
          unit_price = 1.1,
          bar_code = "English",
        });

        // Saves changes
        context.SaveChanges();
      }

      using (var context = new LibraryContext())
      {
        var dados = context.Product;
        foreach(var dado in dados)
        {
          var data = new StringBuilder();
          data.AppendLine($"{dado.id}");
          data.AppendLine($"{dado.unit_price}");
          data.AppendLine($"{dado.name}");
          data.AppendLine($"{dado.bar_code}");
          Console.WriteLine(data.ToString());
        }
      }
      