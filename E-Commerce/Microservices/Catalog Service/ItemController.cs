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
        public async Task<ActionResult<Item>> GetById(string id)
        {
            var TempItem = await _item.GetIdAsync(id);

            if(TempItem is null)
            {
                return NotFound();
            }
            return TempItem;
        }

        //Get by name
        [HttpGet]
        [Route("getbyname/{name}")]
        public async Task<ActionResult<Item>> GetByName(string name)
        {
            List<Item> Items = await _item.GetAsync();

            for(int i = 0; i < Items.Count(); i++)
            {
                if(Items[i].Name == name)
                {
                    return Items[i];
                }
            }
            return NotFound();
        }

///////////////////////////////// All Posts /////////////////////////////

        //Make item
        [HttpPost]
        [Route("makeitem")]
        public async Task<IActionResult> MakeItem(Item item)
        {          
            if(item.Name is not null && item.Description is not null)
            {
                if(!item.Name.Equals(""))
                {
                    if(!item.Description.Equals(""))
                    {
                        if(item.UnitPrice != 0.0d)
                        {
                            await _item.CreateAsync(item);
                            return CreatedAtAction(nameof(GetAllItems), new {id = item.Id}, item);
                        }
                    }
                }               
            }
            
            return Conflict();
        }

/////////////////////////////// All Updates /////////////////////////////

        //Update by id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(string id, Item item)
        {
            var DatabaseItem = await _item.GetIdAsync(id);

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
        public async Task<IActionResult> DeleteItem(string id)
        {
            var DatabaseItem = await _item.GetIdAsync(id);

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

        [HttpGet]
        [Route("test")]
        public ActionResult<String> abc()
        {
            return "Hello";
        }       
    }
}