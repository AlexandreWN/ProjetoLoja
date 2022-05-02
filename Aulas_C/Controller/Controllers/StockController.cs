using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class StockController : ControllerBase{
    [HttpPost]
    [Route("register")]
    public object addProductToStock([FromBody] StockDTO stock){
              return new {
                        unit_price = stock.unit_price,
                        quantity = stock.quantity,
                        store = stock.store,
                        product = stock.product
                        
              };
    }
}