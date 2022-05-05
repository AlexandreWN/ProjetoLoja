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
    public object addProductToWishList([FromBody] WishListDTO wishList){
        WishList wishListDAO = WishList.convertDTOToModel(wishList);

        List<object> products = new List<object>();
        foreach(var prod in wishListDAO.getProducts()){
            wishListDAO.save((wishListDAO.get, prod.findID));
            products.Add(new{
                nome = prod.getName(),
                bar_code = prod.getBarCode()
            });
        }

        return new{
            client = wishList.client,
            produtos = products
        };
    }
}