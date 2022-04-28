using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class PurchaseController : ControllerBase{
    [HttpGet]
    public int getClientPurchase(int clientID){
        
    }

    [HttpGet]
    public int getStorePurchase(int storeID){

    }

    public void makePurchase(PurchaseDTO purchase){
        
    }
}