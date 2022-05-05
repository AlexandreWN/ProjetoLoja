using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase{

    [HttpPost]
    [Route("register")]
    public object resgisterClient([FromBody] ClientDTO client){
        var clientModel = Model.Client.convertDTOToModel(client);
        var id = clientModel.save();
        return new {
            id = id,
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

    [HttpGet]
    [Route("get/{document}")]
    public object getInformations(string document){
        var client = Model.Client.find(document);
        return client;
    }



     [HttpDelete]
    [Route("delete/{document}")]
    public object removeClient(string document){
      //  try{
            var client = Model.Client.removeClient(document);
            return client;
       // }
       // catch(Exception){
      //      return ("Erro ao deletar");
       // }  
    }
}

