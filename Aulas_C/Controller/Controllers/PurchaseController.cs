using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
namespace Controller.Controllers;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("[controller]")]
public class PurchaseController : ControllerBase{
    
    [Authorize]
    [HttpPost]
    [Route("register")]
    public object makePurchase([FromBody] PurchaseDTO purchase){
        var purchaseModel = Model.Purchase.convertDTOToModel(purchase);
        var id = purchaseModel.save(purchase.client.document, purchase.store.CNPJ, purchase.productsDTO.bar_code, purchase.payment_type);
        return new{
            id = id,
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

    [Authorize]
    [HttpGet]
    [Route("getClient/{document}")]
    public List<object> getClientPurchase(string document){
        var purchase = Model.Purchase.getClientPurchases(document);
        return purchase;
    }

   
    [HttpGet]
    [Route("getPurchase/{id}")]
    public object getPurchase(int id){
        var purchase = Model.Purchase.getPurchase(id);
        return purchase;
    }







    [HttpGet]
    [Route("getStore/{id}")]
    public List<object> getStorePurchase(int id){
        var purchase = Model.Purchase.getStorePurchases(id);
        return purchase;
    }

    [Authorize]
    [HttpDelete]
    [Route("delete/{id}")]
    public object removePurchase(int id){
        try{
            var purchase = Model.Purchase.removePurchase(id);
            return purchase;
        }
        catch(Exception){
            return ("Erro ao deletar");
        }  
    }




}