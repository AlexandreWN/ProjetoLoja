using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase{
    [HttpPost]
    [Route()]
    public void registerOwner(ClientDTO client){

    }

    [HttpGet]
    [Route()]
    public void getInformations(){

    }
}