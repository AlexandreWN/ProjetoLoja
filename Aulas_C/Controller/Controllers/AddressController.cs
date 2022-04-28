using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase{
    [HttpPost]
    [Route()]
    public void registerAddress(AddressDTO address){

    }
    [HttpDelete]
    [Route()]
    public void removeAddress(AddressDTO address){

    }
    [HttpPut]
    [Route()]
    public void updateAddress(AddressDTO address){

    }
}

