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
        var productModel = Model.Product.convertDTOToModel(product);
        var id = productModel.save();
        return new{
            id = id,
            name = product.name,
            bar_code = product.bar_code,
        };
    }

    [HttpGet]
    [Route("getAll")]
    public object getAllProducts(){
        var prod = Model.Product.getAllProducts();
        return prod;
    }
}

