using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class StoreController : ControllerBase{
    [HttpGet]
    public void getAllStore(){

    }

    public void registerStore(StoreDTO store){

    }
    [HttpGet]
    public void getStoreInformation(StoreDTO store){

    }
}