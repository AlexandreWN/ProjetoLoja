using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("Address")]
public class AddressController : ControllerBase {
    [HttpPost]
    [Route("register")]
    public object registerAddress([FromBody] AddressDTO address){
        return new {
            street = address.street,
            state = address.state
        };
    }
}

