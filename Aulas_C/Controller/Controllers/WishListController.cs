using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
namespace Controller.Controllers;
namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class WishListController : ControllerBase{
          [HttpPost]
          [Route("register")]
          public object addProductToWishList([FromBody] WishListDTO wishList){
                    return new{
                              id = wishList.id,
                              client = wishList.client,
                              product = wishList.product
                    };
          }
}