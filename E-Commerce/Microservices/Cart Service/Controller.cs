using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System;
namespace Controllers
{

    [ApiController]
    [Route("cart")]
    public class Controller : ControllerBase
    {
        private readonly IConnectionMultiplexer _redis;
        private Cart cart = new Cart();
        public Controller(ILogger<Controller> logger, IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        [HttpGet]
        [Route("test")]
        public void TestEndPoint()
        {
            var db = _redis.GetDatabase();
            db.StringSet("mykey", "myvalue123");
            string? value = db.StringGet("mykey");
            Console.WriteLine("This is the redis value: {0}", value);
        }

        [HttpPost]
        public string AddItemToCart(Item item){
            var db = _redis.GetDatabase();
            db.StringSet(item.Name, item.Quantity);
            cart.allItemsInCart.Add(item);
            return item.Name + " Added to Cart";
        }

        [HttpGet("{name}")]
        public void GetItemInCart(string name){
            var db = _redis.GetDatabase();
            string? value = db.StringGet(name);
            Console.WriteLine(value);
        }
        
        [HttpGet]
        [Route("allitems")]
        public void GetAllItemsInCart(){
            var db = _redis.GetDatabase();
            foreach(Item item in cart.allItemsInCart){
                string? value = db.StringGet(item.Name);
                System.Console.WriteLine(item.Name + ": " + Int32.Parse(value) * item.UnitPrice);
            }
        }

    }
}