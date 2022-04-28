using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class OwnerController : ControllerBase{
    public void registerOwner(OwnerDTO owner){

    }

    [HttpGet]
    public int getInformations(){

    }
}