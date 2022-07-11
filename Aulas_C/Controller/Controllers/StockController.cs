using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
namespace Controller.Controllers;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("[controller]")]
public class StockController : ControllerBase{
    
    [Authorize]
    [HttpPost]
    [Route("register")]
    public object addProductToStock([FromBody] Stocks2DTO stock){
        var id = Stocks.save(stock.storeid,stock.productid,stock.quantity,stock.unit_price);
        return new {
            unit_price = stock.unit_price,
            quantity = stock.quantity,
            store = stock.storeid,
            product = stock.productid
        };
    }

    [Authorize]
    [HttpPut]
    [Route("update")]
    public object updateStock([FromBody] StocksDTO obj){
        Stocks stockModel = Model.Stocks.convertDTOToModel(obj);
        stockModel.update(obj);
        return new {status = "sucess"};
    }
}