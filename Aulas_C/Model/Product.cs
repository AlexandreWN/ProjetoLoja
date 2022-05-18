using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;
namespace Model;
using Microsoft.EntityFrameworkCore;
public class Product: IValidateDataObject, IDataController<ProductDTO, Product>
{ 
    private string name;
    private string bar_code;
    private string description;
    private string image;
    public List<ProductDTO> productDTO = new List<ProductDTO>();

    public string getDescripton(){
        return description;
    }
    public void setDescription(string description){
        this.description = description;
    }
    public string getImage(){
        return image;
    }
    public void setImage(string image){
        this.image = image;
    }
    public string getName() 
    { 
        return name; 
    }
    public void setName(string name)
    {
        this.name = name;
    }
    public string getBarCode() 
    { 
        return bar_code; 
    }
    public void setBarCode(string bar_code)
    { 
        this.bar_code = bar_code; 
    }

    public bool validateObject()
    {
        if (this.getBarCode() == null) return false;
        if (this.getName() == null) return false;
        if (this.getImage() == null) return false;
        if (this.getDescripton() == null) return false;

        return true;
    }


    public static object find(int id){
        using(var context = new DAO.LibraryContext())
        {
            var product = context.Stocks.Include(s => s.product).FirstOrDefault(a => a.id == id);
            return new{
                id = id,
                name = product.product.name,
                image = product.product.image,
                description = product.product.description,
                bar_code = product.product.bar_code,
                price = Math.Round(product.unit_price, 2)
            };
        }
    }
    

    public int findID(){
        using(var context = new DAO.LibraryContext())
        {
            var product = context.Product.FirstOrDefault(a => a.bar_code == this.bar_code);
            return product.id;
        }
      
    }
    public static List<object> getAllProducts(){
        using(var context = new DAO.LibraryContext())
        {
            var allStocks = context.Stocks.Include(s => s.product);
            List<object> products = new List<object>();
            foreach(var prod in allStocks){
               products.Add(new{
                   id = prod.product.id,
                   name = prod.product.name,
                   image = prod.product.image,
                   description = prod.product.description,
                   bar_code = prod.product.bar_code,
                   price = prod.unit_price,
                   StockId = prod.id
               });
            }
            return products;
        }
    }

    public static string removeProduct(int id){
        using(var context = new LibraryContext())
        {
            var purchases = context.Purchase.Where(p => p.product.id == id);
            foreach(var purchase in purchases){
                Purchase.removePurchase(purchase.id);
            }
            context.SaveChanges();
            var stocks = context.Stocks.Where(s=> s.product.id == id);
            foreach(var stock in stocks){
                Stocks.removeStocks(stock.id);
            } 
            context.SaveChanges();
             var whishList = context.WishList.Where(s=> s.product.id == id);
            foreach(var whish in whishList){
                WishList.removeWishList(whish.id);
            } 
            context.SaveChanges();
            var product = context.Product.FirstOrDefault(e=>e.id == id);
            context.Remove(product);
            context.SaveChanges();
            return "foi removido!";
            }
        }
    public int save()
    {
        var id = 0;
        using (var context = new LibraryContext())
        {
            var product = new DAO.Product
            {
                name = this.name,
                bar_code = this.bar_code,
                image = this.image,
                description = this.description
            };
            context.Product.Add(product);
            context.SaveChanges();
            id = product.id;
        }
        return id;
    }
    public void delete(ProductDTO obj) { }
    public void update(ProductDTO obj) {
        using (var context = new DAO.LibraryContext())
        {
            var product = context.Product.FirstOrDefault(i => i.bar_code == obj.bar_code);

            if (product != null)
            {
                context.Entry(product).State = EntityState.Modified;
                if(product.name == null) product.name = obj.name;
                if(product.bar_code == null)product.bar_code = obj.bar_code;
            }
            context.SaveChanges();
        }
     }

    public ProductDTO findById(int id)
    {
        return new ProductDTO();
    }

    public List<ProductDTO> getAll()
    {
        return this.productDTO;
    }


    public ProductDTO convertModelToDTO()
    {
        var productDTO = new ProductDTO();
        productDTO.name = this.name;
        productDTO.bar_code = this.bar_code;
        productDTO.image = this.image;
        productDTO.description = this.description;
        return productDTO;
    }
    public static Product convertDTOToModel(ProductDTO obj)
    {
       Product product = new Product(); 
        product.name = obj.name;
        product.bar_code = obj.bar_code;
        product.image = obj.image;
        product.description = obj.description;
        return product;
    }
}
