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
    public object addProductToWishList([FromBody] WishListRegisterDTO request){      

        var wishlistModel = new Model.WishList();

        var newID =  wishlistModel.save(request.document,request.productID,request.stockID);      

        return new{
            id = newID,
            response= "salvou no banco"
        };
    }

    [Authorize]
    [HttpDelete]
    [Route("delet/{id}/{document}")]
    public object removeProductToWishList(int id, string document){

        var whishList = Model.WishList.removeProductToWishList(id, document);
        Response.Headers.Add("Access-Control-Allow-Origin", "*");
        return whishList;
    }
    
    [Authorize]
    [HttpGet]
    [Route("get/{document}")]
    public IActionResult getWishListById(string document){
        var id = Model.Client.findID(document);
        var wish = Model.WishList.find(id);
        var result = new ObjectResult(wish);
        Response.Headers.Add("Access-Control-Allow-Origin", "*");
        return result;
    }
}