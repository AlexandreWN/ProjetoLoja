using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.Cors;
namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase{

    [HttpPost]
    [Route("register")]
    public object resgisterClient([FromBody] ClientDTO client){
        var clientModel = Model.Client.convertDTOToModel(client);
        var id = clientModel.save();
        if(id == -1){
            return "usuario ja cadastrado";
        }else{
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
    }

    [HttpGet]
    [Route("get/{document}")]
    public object getInformations(string document){
        var client = Model.Client.find(document);
        return client;
    }
  
    [HttpPost]
    [Route("login")]
    public IActionResult loginClient([FromBody] LoginDTO client){

        Response.Headers.Add("Access-Control-Allow-Origin", "*");
        var clientLogin = Model.Client.loginClient(client.login,client.passwd);

         if (clientLogin != null) 
       {
           var result = new ObjectResult(clientLogin);
           return result;
       }
        return new ObjectResult(new {
            msg = "error"
        });
     
    }
     [HttpDelete]
    [Route("delete/{document}")]
    public object removeClient(string document){
        try{
            var client = Model.Client.removeClient(document);
            return client;
        }
        catch(Exception){
            return ("Erro ao deletar");
        }  
    }
}

