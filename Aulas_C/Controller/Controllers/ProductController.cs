using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase{
    [HttpGet]
    [Route()]
    public void allProducts(){

    }
    [HttpPost]
    [Route()]
    public void createProduct(ProductDTO product){

    }
    [HttpDelete]
    [Route()]
    public void deleteProduct(ProductDTO product){

    }
    [HttpPut]
    [Route()]
    public void updateProduct(ProductDTO product){

    }

}