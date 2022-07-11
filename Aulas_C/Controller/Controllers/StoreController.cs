using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
namespace Controller.Controllers;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("[controller]")]
public class StoreController : ControllerBase{
    
    [Authorize]
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

    [HttpGet]
    [Route("getAll")]
    public object getAllStore(){
        var stor = Model.Store.getAllStore();
        return stor;
    }



    [HttpGet]
    [Route("getOwnerStore/{document}")]
    public object getAllStore(string document){
        var stores = Model.Store.getOwnerStore(document);
        return stores;
    }
}