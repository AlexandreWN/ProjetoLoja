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
      
      // Gets and prints all books in database
      using (var context = new LibraryContext())
      {
        var books = context.Product;
        foreach(var book in books)
        {
          var data = new StringBuilder();
          data.AppendLine($"ISBN: {book.id}");
          data.AppendLine($"Title: {book.unit_price}");
          data.AppendLine($"Publisher: {book.name}");
          data.AppendLine($"Publishersss: {book.bar_code}");
          Console.WriteLine(data.ToString());
        }
      }
      