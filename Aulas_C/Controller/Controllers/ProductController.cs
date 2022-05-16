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
            description = product.description,
            image = product.image
        };
    }

    [HttpGet]
    [Route("getAll")]
    public IActionResult getAllProducts(){
        var prod = Model.Product.getAllProducts();
        var result = new ObjectResult(prod);
         Response.Headers.Add("Access-Control-Allow-Origin", "*");
        return result;
    }
    [HttpGet]
    [Route("get/{id}")]
    public IActionResult getProductById(int id){
        var prod = Model.Product.find(id);
         var result = new ObjectResult(prod);
         Response.Headers.Add("Access-Control-Allow-Origin", "*");
        return result;
    }
    

    [HttpPut]
    [Route("update")]
    public object updateProduct([FromBody] ProductDTO product){
        var productModel =  Model.Product.convertDTOToModel(product); 
        
        productModel.update(product);
        return new { status = "sucess"};
    }
     [HttpDelete]
    [Route("delete/{id}")]
    public object removeProduct(int id){
        try{
            var product = Model.Product.removeProduct(id);
            return product;
        }
            catch(Exception){
            return ("Erro ao deletar");
       }  
    }
}

