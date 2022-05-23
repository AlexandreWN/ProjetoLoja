using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
namespace Controller.Controllers;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("[controller]")]
public class OwnerController : ControllerBase{
    
    [HttpPost]
    [Route("register")]
    public object registerOwner([FromBody] OwnerDTO owner){
        var ownerModel = Model.Owner.convertDTOToModel(owner);
        var id = ownerModel.save();
        if(id == -1){
            return "usuario ja cadastrado";
        }else{
            return new {
                id = id,
                name = owner.name,
                date_of_birth = owner.date_of_birth,
                document = owner.document,
                email = owner.email,
                phone = owner.phone,
                login = owner.login,
                passwd = owner.passwd,
                address = owner.address
            };
        }

    }

    [Authorize]
    [HttpGet]
    [Route("get/{document}")]
    public object getInformations(string document){
        var owner = Model.Owner.find(document);
        return owner;
    }

    [Authorize]
    [HttpDelete]
    [Route("delete/{document}")]
    public object removeOwner(string document){
        try{
            var owner = Model.Owner.removeOwner(document);
            return owner;
        }
            catch(Exception){
            return ("Erro ao deletar");
       }  
    }
}