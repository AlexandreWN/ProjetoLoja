using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class StoreController : ControllerBase{
    [HttpPost]
    [Route("register")]
    public object registerStore([FromBody] StoreDTO obj){
        var storeModel = Model.Store.convertDTOToModel(obj);
        var ownerModel = obj.owner.id;
        storeModel.save(ownerModel);
        return new{
            name = obj.name,
            CNPJ = obj.CNPJ,
            owner  = obj.owner,
            purchase = obj.purchase,
        };
    }

     [HttpGet]
    [Route("get/{id}")]
     public object getStoreInformations(int id){
        var store = Model.Store.find(id);
        return store;
    }

}