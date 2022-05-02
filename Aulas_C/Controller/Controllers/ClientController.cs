using Microsoft.AspNetCore.Mvc;
namespace Controller.Controllers;
[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase{

    [HttpPost]
    [Route("register")]
    public object resgisterClient([FromBody] ClinentDTO clinent){
        return new {
            id = clinent.id,
            name = clinent.name,
            date_of_birth = clinent.date_of_birth,
            document = clinent.document,
            email = clinent.email,
            phone = clinent.phone,
            login = clinent.login,
            passwd = clinent.passwd,
            address = clinent.address
        };
    }
}