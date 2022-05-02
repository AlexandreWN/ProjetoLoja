using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase{
    [HttpPost]
    [Route("register")]
    public object createProduct([FromBody] ProductDTO product){
        return new{
            name = product.name,
            bar_code = product.bar_code,
        };
    }
}

