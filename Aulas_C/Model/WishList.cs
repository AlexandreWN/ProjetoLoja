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
    private List<Product> product = new List<Product>();
    private List<WishListDTO> wishListDTO = new List<WishListDTO>();

    public WishList(Client client)
    {
        this.client = client;
    }

    public void addProductToWishList(Product product) {
        product.Add(product);
    }

    public List<Product> getProducts() { 
        return product; 
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

    public int save(){
        var id = 0;

        using(var context = new LibraryContext())
        {
            var wishList = new DAO.WishList{

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
        
    }
}