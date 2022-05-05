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
        WishList wishlist = WishList.convertDTOToModel(request);

        List<object> products = new List<object>();
        foreach(var prod in wishlist.getProducts()){
            wishlist.save(wishlist.getClient().getDocument(), 1);

            products.Add(new{
                nome = prod.getName(),
                bar_code = prod.getBarCode()
            });
        }

        return new{
            client = request.client,
            produtos = products
        };
    }
}