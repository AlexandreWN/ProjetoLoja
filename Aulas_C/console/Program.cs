using System;
using System.Text;
using DAO;

      //CREATE
      using(var context = new LibraryContext())
      {
        context.Database.EnsureCreated();
      }
      /*
      //INSERT
       using(var context = new LibraryContext())
      {
        context.Product.Add(new Product
        {
          name = "The Lord of the Rings",
          unit_price = 1.1,
          bar_code = "English",
        });
        context.SaveChanges();
      }
     //SELECT
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
      }/*
      //DELETE
      
       using (var context = new LibraryContext())
      {
            var products = new  Product  {id = 1 };
            context.Remove(products);
             context.SaveChanges();
      }
      using(var context = new LibraryContext())
      {
            context.Database.EnsureCreated();
      }


      //DELETE
using (var context = new LibraryContext())
{
      var products = new  Product  {id = 1 };
      context.Remove(products);
        context.SaveChanges();
}
*/
/*
//INSERT
  using(var context = new LibraryContext())
{
  context.Product.Add(new Product
  {
    name = "The Lord of the Rings",
    unit_price = 1.1,
    bar_code = "English",
  });
  context.SaveChanges();
}
//SELECT
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
/*

//UPDATE
  using(var context = new LibraryContext())
{
  var idP = 2;
  var dados = context.Product.Where(a => a.id.Equals(idP)).SingleOrDefault();
  dados.name = "batata";
  context.SaveChanges();
}
*/