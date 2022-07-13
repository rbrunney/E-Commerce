using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//"docker_db1": "Server=localhost,1433;database=apidb;User ID= SA;password=abc123!!@;"

namespace Controllers
{
    [ApiController]
    [Route("cart")]
    public class Controller : ControllerBase
    {
        private readonly CartDB _CDB;
        
        public Controller(ILogger<Controller> logger, CartDB cdb)
        {            
            _CDB = cdb;
        }

        [HttpGet]
        [Route("test")]
        public ActionResult<String> TestEndPoint(){
            return "Test Succesful";
        }

    }
}