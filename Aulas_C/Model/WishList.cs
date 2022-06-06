using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DAO;
using DTO;
using Microsoft.EntityFrameworkCore;
namespace Model;
public class WishList : IValidateDataObject, IDataController<WishListDTO,WishList>
{
    private Client client;
    private List<Product> products = new List<Product>();
    private List<WishListDTO> wishListDTO = new List<WishListDTO>();

    public WishList(Client client)
    {
        this.client = client;
    }
    public WishList()
    {

    }

    public void addProductToWishList(Product product) {
        products.Add(product);
    }

    public List<Product> getProducts() { 
        return products; 
    }

    public Client getClient() {
        return client;
    }

    public bool validateObject()
    {
        if(this.getProducts() == null) return false;
        if(this.getClient() == null) return false;
        return true;
    }

    public void delete(WishListDTO obj){

    }

    public int save(string document, int productid){
        var id = 0;


        using(var context = new LibraryContext())
        {
            try{
                var clientDAO = context.Client.FirstOrDefault(c=>c.document == document);
                var productsDAO = context.Product.Where(p=>p.id == productid).Single();
                var wishList = new DAO.WishList{
                    client = clientDAO,
                    product = productsDAO
                };

                context.WishList.Add(wishList);
                context.SaveChanges();

                id = wishList.id;
            }catch(Exception e){

                Console.Write(e);

            }
           

           
        }
        return id;
    }

     public static string removeWishList(int  id){
         using(var context = new LibraryContext())
        {
            var wishList = context.WishList.FirstOrDefault(w => w.id == id);
            context.Remove(wishList);  
            context.SaveChanges();
            return " foi removido!";
        }
    }
     public static string removeProductToWishList(int idProd){
         using(var context = new LibraryContext())
        {
            var wishListProducts = context.WishList.Where(w => w.product.id == idProd);
            foreach(var prod in wishListProducts){
                context.Remove(prod);    
            }
             context.SaveChanges(); 
            return " foi removido!";
        }
    }
    
    public void update(WishListDTO obj){

    }

    public WishListDTO findById(int id)
    {

        return new WishListDTO();
    }

    public List<WishListDTO> getAll()
    {        
        return this.wishListDTO;      
    }
   
    public static List<object> find(int id){
        using(var context = new DAO.LibraryContext())
        {
            var stocks = context.Stocks;
            var wishlist = context.WishList.Include(s => s.client).Where(a => a.client.id == id).Join(stocks, w => w.product, s => s.product,(w,s) => new {
                id = w.product.bar_code,
                product = w.product.name,
                price = s.unit_price,
                description = w.product.description,
                image = w.product.image,
                name = w.product.name
            }).ToList().GroupBy(x => x.id);

            List<object> dados = new List<object>();
            foreach(var i in wishlist){
                var ordenado = i.OrderBy(p => p.price);
                dados.Add(ordenado.First());
            }
            return dados;
        }
    }
    public WishListDTO convertModelToDTO()
    {
        var wishListDTO = new WishListDTO();
        wishListDTO.client = this.client.convertModelToDTO();

        foreach(var prod in this.products)
        {
            wishListDTO.product.Add(prod.convertModelToDTO());
        }
        return wishListDTO;
    }

    public static WishList convertDTOToModel(WishListDTO obj){
        var wishList = new WishList(Client.convertDTOToModel(obj.client));
        foreach(var prod in obj.product)
        {
           wishList.addProductToWishList(Product.convertDTOToModel(prod));
        }
       return wishList;
        
    }
}