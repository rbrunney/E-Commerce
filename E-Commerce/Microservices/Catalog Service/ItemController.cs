using Microsoft.AspNetCore.Mvc;
using Ser;

namespace Controllers
{
    [ApiController]
    [Route("ecommerce")]
    
    public class MyController : ControllerBase
    {
        private readonly ItemService2 _item;
        public MyController(ItemService2 itemService)
        {
            _item = itemService;
        }

//////////////////////// All Gets //////////////////////////////////////

        //Get all items
        [HttpGet]
        [Route("getallitems")]
        public async Task<List<Item>> GetAllItems() =>
            await _item.GetAsync();

        //Get by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetById(long id)
        {
            var TempItem = await _item.GetAsync(id);

            if(TempItem is null)
            {
                return NotFound();
            }
            return TempItem;
        }

        //Get by name
        [HttpGet("{name}")]
        public async Task<ActionResult<Item>> GetByName(string name)
        {
            var DatabaseItem = await _item.GetAsync(name);

            if(DatabaseItem is not null)
            {
                return DatabaseItem;
            }
            return NotFound();
        }

///////////////////////////////// All Posts /////////////////////////////

        //Make item
        [HttpPost]
        [Route("makeitem")]
        public async Task<IResult> MakeItem(Item item)
        {
            Item TempItem = await _item.GetAsync(item.Id);

            if(TempItem?.Name is null)
            {
                if(!item.Name.Equals(""))
                {
                    if(!item.Description.Equals(""))
                    {
                        if(item.UnitPrice != 0.0d)
                        {
                            _item.CreateAsync(item);
                            return Results.Created($"/{item.Id}", item);
                        }
                    }
                }                
            }
            
            return Results.Conflict();
        }

/////////////////////////////// All Updates /////////////////////////////

        //Update by id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(long id, Item item)
        {
            var DatabaseItem = await _item.GetAsync(id);

            if(DatabaseItem is not null)
            {
                item.Id = DatabaseItem.Id;
                await _item.UpdateAsync(id, item);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

////////////////////////////// All Deletes //////////////////////////////

        //Delete by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(long id)
        {
            var DatabaseItem = await _item.GetAsync(id);

            if(DatabaseItem is not null)
            {
                await _item.RemoveAsync(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }        
    }
}