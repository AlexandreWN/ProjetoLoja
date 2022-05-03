using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase{

    [HttpPost]
    [Route("register")]
    public object resgisterClient([FromBody] ClientDTO client){
        return new {
            id = client.id,
            name = client.name,
            date_of_birth = client.date_of_birth,
            document = client.document,
            email = client.email,
            phone = client.phone,
            login = client.login,
            passwd = client.passwd,
            address = client.address
        };
    }

    [HttpPost]
    [Route("get/{id}")]
    public object getInformation(int id){
        var client = Model.Client.find(id);
    }
}

