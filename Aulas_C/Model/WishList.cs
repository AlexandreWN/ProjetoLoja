using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DAO;
using DTO;
namespace Model;
public class WishList : IValidateDataObject, IDataController<WishList, WishListDTO>
{
    private Client client;
    private List<Product> products = new List<Product>();

    public WishList(Client client)
    {
        this.client = client;
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

    public bool validateObject(WishList obj)
    {
        if(obj.getProducts() == null) return false;
        if(obj.getClient() == null) return false;
        return true;
    }

    public void delete(WishListDTO obj){

    }

    public int save(){
        var id = 0;

        using(var context = new DAOContext())
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
        return wishListDTO;
    }

    public static WishList convertDTOToModel(WishListDTO obj){
        return new WishList();
    }
}