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
            var TempItem = await _item.GetNameAsync(name);

            if(TempItem is not null)
            {
                return TempItem;
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
        [HttpPut]
        [Route("{name}")]
        public async Task<IActionResult> UpdateItem(string name, Item item)
        {
            //var TempItem = await _item.GetIdAsync(id);
            var TempItem = await _item.GetNameAsync(name);

            if(TempItem!.Id is not null)
            {
                item.Id = TempItem.Id;
                await _item.UpdateAsync(item.Id, item);
                return NoContent();
            }         
            return NotFound();
        }

////////////////////////////// All Deletes //////////////////////////////

        //Delete by id
        [HttpDelete]
        [Route("{name}")]
        public async Task<IActionResult> DeleteItem(string name)
        {
            //var DatabaseItem = await _item.GetIdAsync(id);
            var TempItem = await _item.GetNameAsync(name);

            if(TempItem is not null)
            {
                await _item.RemoveAsync(TempItem.Name);
                return NoContent();
            }
            return NotFound();
        } 
    }
}