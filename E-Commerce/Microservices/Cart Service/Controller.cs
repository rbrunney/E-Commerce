using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Text;
namespace Controllers
{

    [ApiController]
    [Route("cart")]
    public class Controller : ControllerBase
    {
        private readonly IConnectionMultiplexer _redis;
        //Make in memory database 
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
        public ActionResult<String> AddItemToCart(CartItem item){
            cart.ItemsInCart.Add(item);
            return item.Name + " Added to Cart";
        }

        [HttpGet("{name}")]
        public ActionResult<String> GetItemInCart(string name){
            string toReturn = "";
            foreach(CartItem item in cart.ItemsInCart){
                if(item.Name.Equals(name)){
                    toReturn = item.ToString();
                    System.Console.WriteLine(item.ToString());
                }
                else{
                    toReturn = "Item Name Not Found";
                }
            }
            System.Console.WriteLine("End Getting");
            return toReturn;
        }
        
        [HttpGet]
        [Route("allitems")]
        public ActionResult<String> GetAllItemsInCart(){
            StringBuilder sb = new StringBuilder();
            foreach(CartItem item in cart.ItemsInCart)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
            }
        }
    }
