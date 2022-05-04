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
    public object registerStore([FromBody] StoreDTO store){
        var storeModel = Model.Store.convertDTOToModel(store);
        var id = storeModel.save(Owner.findId(storeModel.getOwner().getDocument()));
        return new{
            id = id,
            name = store.name,
            CNPJ = store.CNPJ,
            owner  = store.owner,
            purchase = store.purchase,
        };
    }

     [HttpGet]
    [Route("get/{id}")]
     public object getStoreInformations(int id){
        var store = Model.Store.find(id);
        return store;
    }

}