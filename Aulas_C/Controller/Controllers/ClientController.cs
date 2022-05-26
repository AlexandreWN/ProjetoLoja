using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.Cors;
namespace Controller.Controllers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

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

    [Authorize]
    [HttpGet]
    [Route("get/{document}")]
    public object getInformations(string document){
        var client = Model.Client.find(document);
        return client;
    }
    
    public IConfiguration _configuration;
    public ClientController(IConfiguration config){
        _configuration = config;
    }

    [HttpPost]
    [Route("login")]
    public IActionResult loginClient([FromBody] LoginDTO client){
        
        if(client != null && client.login != null && client.passwd != null){
            var clientLogin = Model.Client.loginClient(client.login,client.passwd);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            if (clientLogin != null) 
            {
                var claims = new [] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", clientLogin.id.ToString()),
                    new Claim("name", clientLogin.name),
                    new Claim("Email", clientLogin.email),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);
                var clientResponse = new{
                    id = clientLogin.id,
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                };
                return Ok(clientResponse);
            }
            else{
                return BadRequest("Invalid credentials");
            }
        }
        else{
            return BadRequest("Invalid credentials");
        }
    }

    [Authorize]
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

