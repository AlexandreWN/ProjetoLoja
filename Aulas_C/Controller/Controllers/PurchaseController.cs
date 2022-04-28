using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class PurchaseController : ControllerBase{
    [HttpGet]
    [Route()]
    public void getClientPurchase(int clientID){
        
    }

    [HttpGet]
    [Route()]
    public void getStorePurchase(int storeID){

    }

    [HttpPost]
    [Route()]
    public void makePurchase(PurchaseDTO purchase){
        
    }
}