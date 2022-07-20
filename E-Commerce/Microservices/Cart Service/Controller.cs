using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Text;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery.Eureka;
using Steeltoe.Discovery;

namespace Controllers
{

    [ApiController]
    [Route("cart")]
    public class Controller : ControllerBase
    {
        private readonly CartDB _cdb;
        //Make in memory database 
        private Cart cart = new Cart();
        public Controller(ILogger<Controller> logger, CartDB cdb)
        {
            _cdb = cdb;
        }

        // [HttpGet]
        // [Route("test")]
        // public void TestEndPoint()
        // {
        //     var db = _redis.GetDatabase();
        //     db.StringSet("mykey", "myvalue123");
        //     string? value = db.StringGet("mykey");
        //     Console.WriteLine("This is the redis value: {0}", value);
        // }

        [HttpGet]
        [Route("/catalogitems")]
        public async Task<HttpResponseMessage> catalogeItems(IDiscoveryClient idc){
            DiscoveryHttpClientHandler _handler = new DiscoveryHttpClientHandler(idc);
            var client = new HttpClient(_handler, false);
            var temp = await client.GetAsync("http://CATALOG-SERVICE/ecommerce/getallitems");
            System.Console.WriteLine("I am Here, and not dead");
            return await client.GetAsync("http://CATALOG-SERVICE/ecommerce/getallitems");
        }

        [HttpPost]
        public async Task<IResult> AddItemToCart(CartItem item){
            _cdb.Cart.Add(item);
            await _cdb.SaveChangesAsync();
            return Results.Created($"/{item.Name}", item);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<CartItem>> GetItemInCart(string name){
            var todo = await _cdb.Cart.Where(m => m.Name  == name).ToListAsync();
            
            if(todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }
        
        [HttpGet]
        [Route("allitems")]
        public async Task<ActionResult<List<CartItem>>> GetAllItemsInCart(){
            return await _cdb.Cart.ToListAsync();
        }

        [HttpDelete]
        [Route("checkout")]
        public void checkout(Account account){

            //call email service
            //call order service

            //empty the cart
            _cdb.Database.EnsureDeleted();
        }
    }
}