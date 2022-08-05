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
    public IConfiguration _configuration;
    public OwnerController(IConfiguration config){
        _configuration = config;
    }
    
    [HttpPost]
    [Route("login")]
    public IActionResult loginOwner([FromBody] LoginDTO owner){
        
        if(owner != null && owner.login != null && owner.passwd != null){
            var ownerLogin = Model.Owner.loginOwner(owner.login,owner.passwd);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            if (ownerLogin != null) 
            {
                var claims = new [] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", ownerLogin.id.ToString()),
                    new Claim("name", ownerLogin.name),
                    new Claim("Email", ownerLogin.email),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(1000),
                    signingCredentials: signIn);
                var ownerResponse = new{
                    id = ownerLogin.id,
                    document = ownerLogin.document,
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                };
                return Ok(ownerResponse);
            }
            else{
                return BadRequest("Invalid credentials");
            }
        }
        else{
            return BadRequest("Invalid credentials");
        }
    }
}

