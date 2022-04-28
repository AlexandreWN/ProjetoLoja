using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class StockController : ControllerBase{
    [HttpPost]
    [Route()]
    public void addProductToStock(object request) {

    }
    
    public void updateStock(object request) { }
}