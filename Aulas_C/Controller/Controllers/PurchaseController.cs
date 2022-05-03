using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class PurchaseController : ControllerBase{
    [HttpPost]
    [Route("register")]
    public object makePurchase([FromBody] PurchaseDTO purchase){
        return new{
            date_purchase = purchase.date_purchase,
            purchase_value = purchase.purchase_value,
            payment_type = purchase.payment_type,
            purchase_status = purchase.purchase_status,
            number_confirmation = purchase.number_confirmation,
            number_nf = purchase.number_nf,
            client = purchase.client,
            store = purchase.store,
            productsDTO = purchase.productsDTO
        };
    }

    [HttpGet]
    [Route("getClient/{id}")]
    public List<PurchaseDTO> getClientPurchase(int id){
        var purchase = Model.Purchase.getClientPurchases(id);
        return purchase;
    }

    [HttpGet]
    [Route("getStore/{id}")]
    public List<object> getStorePurchase(int id){
        var purchase = Model.Purchase.getStorePurchases(id);
        return purchase;
    }
}