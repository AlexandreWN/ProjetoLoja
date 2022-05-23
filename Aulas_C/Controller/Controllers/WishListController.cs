using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
namespace Controller.Controllers;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("[controller]")]
public class WishListController : ControllerBase{
    
    [Authorize]
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

    [Authorize]
    [HttpDelete]
    [Route("delete/{id}")]
    public object removeProductToWishList(int id){
        try{
            var whishList = Model.WishList.removeProductToWishList(id);
            return whishList;
        }
        catch(Exception){
            return ("Erro ao deletar");
        }  
    }
    
    [Authorize]
    [HttpGet]
    [Route("get/{id}")]
    public IActionResult getWishListById(int id){
        var wish = Model.WishList.find(id);
        var result = new ObjectResult(wish);
        Response.Headers.Add("Access-Control-Allow-Origin", "*");
        return result;
    }
}