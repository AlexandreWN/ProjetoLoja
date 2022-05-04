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
    public object addProductToStock([FromBody] StocksDTO stock){
        var stockModel = Model.Stocks.convertDTOToModel(stock);
        var StoreID = Store.findID(stockModel.getStore().getCNPJ());
        var ProductID = Product.findID(stockModel.getProduct().getBarCode());
        var quantity = stock.quantity;
        var unit_price = stock.unit_price;
        var id = stockModel.save(StoreID,ProductID,quantity,unit_price);
        return new {
            unit_price = stock.unit_price,
            quantity = stock.quantity,
            store = stock.store,
            product = stock.product
        };
    }
}