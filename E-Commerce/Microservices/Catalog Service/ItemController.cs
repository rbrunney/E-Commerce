using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    [ApiController]
    [Route("ecommerce")]

    public class MyController : ControllerBase
    {
        private readonly ItemDb _db;

        public MyController(ILogger<MyController> logger, ItemDb db)
        {            
            _db = db;
        }

        [HttpPost]
        [Route("makeitem")]
        public async Task<IResult> MakeItem(Item item)
        {
            Item TempItem = await _db.Items.Where(i => i.Name == item.Name).FirstAsync();

            if(TempItem.Name == null)
            {
                if(!item.Name.Equals(""))
                {
                    if(!item.Description.Equals(""))
                    {
                        if(item.UnitPrice != 0.0d)
                        {
                            _db.Items.Add(item);
                            await _db.SaveChangesAsync();
                            return Results.Created($"/{item.Name}", item);
                        }
                    }
                }                
            }
            
            return Results.Conflict();
        }

        
    }
}