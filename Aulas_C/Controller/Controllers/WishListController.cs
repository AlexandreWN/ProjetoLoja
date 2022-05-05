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

        foreach(var prod in wishlistModel.getProducts()){
            wishlistModel.save(clientModel.getDocument(), prod.findID());
        }

        return new{
            response= "salvou no banco"
        };
    }
}