using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class WishListController : ControllerBase{
    [HttpPost]
    [Route()]
    public void addProductToWishList(object request){

    }
    
    [HttpDelete]
    [Route()]
    public void removeProductToWishList(object request){

    }
}