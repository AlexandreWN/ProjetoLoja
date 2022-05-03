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
        return new{
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