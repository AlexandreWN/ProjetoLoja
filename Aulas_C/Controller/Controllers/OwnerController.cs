using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
namespace Controller.Controllers;

[ApiController]
[Route("Owner")]
public class OwnerController : ControllerBase{
    
    [HttpPost]
    [Route("register")]
    public object registerOwner([FromBody] OwnerDTO owner){
        return new {
            id = owner.id,
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