using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class OwnerController : ControllerBase{
    [HttpPost]
    [Route()]
    public void registerOwner(OwnerDTO owner){

    }

    [HttpGet]
    [Route()]
    public void getInformations(){

    }
}