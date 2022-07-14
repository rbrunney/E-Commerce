using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace Controllers
{

    [ApiController]
    [Route("cart")]
    public class Controller : ControllerBase
    {
        private readonly CartDB _CDB;
        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(new ConfigurationOptions{EndPoints = {"localhost:6379"}});
        
        public Controller(ILogger<Controller> logger, CartDB cdb)
        {            
            _CDB = cdb;
        }

        [HttpGet]
        [Route("test")]
        public async Task<String> TestEndPoint(){
            var db = redis.GetDatabase();
            var pong = await db.PingAsync();
            Console.WriteLine(pong);
            return "Test Succesful";
        }

        // [HttpPost]
        // [Route("addItem")]
        // public ActionResult<Item> AddItemToCart(){
        //     //Get Item name and Amount
        //     //Add them to redis as a KEY:VALUE
        //     //Save Redis
        //     //Return result
        // }

    }
}