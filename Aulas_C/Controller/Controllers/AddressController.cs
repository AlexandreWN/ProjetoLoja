using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("[address]")]
public class AddressController : ControllerBase{
    [HttpPost]
    [Route()]
    public void registerAddress([FromBody] AddressDTO address){

    }
    [HttpDelete]
    [Route()]
    public void removeAddress(AddressDTO address){

    }
    [HttpPut]
    [Route()]
    public void updateAddress(AddressDTO address){

    }
}

