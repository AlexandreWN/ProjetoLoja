using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase {
    [Authorize]
    [HttpPost]
    [Route("register")]
    public object registerAddress([FromBody] AddressDTO address){
        Response.Headers.Add("Access-Control-Allow-Origin", "*");
        var addressModel = Model.Address.convertDTOToModel(address);
        var id = addressModel.save();
        return new {
            id = id,
            street = address.street,
            state = address.state,
            city = address.city,
            country = address.country,
            postal_code = address.postal_code
        };
    }

    [Authorize]
    [HttpDelete]
    [Route("delete/{id}")]
    public object removeAdress(int id){

            var address = Model.Address.removeAdress(id);
            return address;

    }

    [Authorize]
    [HttpPost]
    [Route("update")]
    public object updateAddress([FromBody] AddressDTO obj){
        var addressModel = Model.Address.convertDTOToModel(obj);
        var id = addressModel.save();
        return new {
            id = id,
            street = obj.street,
            state = obj.state,
            city = obj.city,
            country = obj.country,
            postal_code = obj.postal_code
        };
    }
    
    [Authorize]
    [HttpGet]
    [Route("getAll")]
    public IActionResult getAllAddress(){
        var allAddress = Model.Address.getAllAddress();
        var result = new ObjectResult(allAddress);
         Response.Headers.Add("Access-Control-Allow-Origin", "*");
        return result;
    }
}



