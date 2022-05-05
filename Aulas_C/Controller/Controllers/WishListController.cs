using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class WishListController : ControllerBase{
    [HttpPost]
    [Route("register")]

    public object addProductToWishList([FromBody] WishListDTO request){
        var wishlistModel = Model.WishList.convertDTOToModel(request);
        var clientModel = wishlistModel.getClient();

<<<<<<< HEAD
        List<object> products = new List<object>();
        foreach(var prod in wishlist.getProducts()){
            wishlist.save(wishlist.getClient().getDocument(), 1);

            products.Add(new{
                nome = prod.getName(),
                bar_code = prod.getBarCode()
            });
=======
        foreach(var prod in wishlistModel.getProducts()){
            wishlistModel.save(clientModel.getDocument(), prod.findID());
>>>>>>> dfba4c61b3a22c480ba5b45b6b28097482009303
        }

        return new{
            response= "salvou no banco"
        };
    }
}