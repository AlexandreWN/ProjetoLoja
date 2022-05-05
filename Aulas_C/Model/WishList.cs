using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DAO;
using DTO;
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

    public static int save(string document, int product){
        var id = 0;


        using(var context = new LibraryContext())
        {
            var clientDAO = context.Client.FirstOrDefault(c=>c.document == document);
            var productsDAO = context.Product.Where(p=>p.id == product).Single();
            var wishList = new DAO.WishList{
                client = clientDAO,
                product = productsDAO
            };

            context.WishList.Add(wishList);
            context.SaveChanges();

            id = wishList.id;

        }
         return id;
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