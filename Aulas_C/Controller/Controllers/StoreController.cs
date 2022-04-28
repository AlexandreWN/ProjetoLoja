using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class StoreController : ControllerBase{
    [HttpGet]
    [Route()]
    public void getAllStore(){

    }
    [HttpPost]
    [Route()]
    public void registerStore(StoreDTO store){

    }
    [HttpGet]
    [Route()]
    public void getStoreInformation(StoreDTO store){

    }
}