using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//"docker_db1": "Server=localhost,1433;database=apidb;User ID= SA;password=abc123!!@;"

namespace Controllers
{
    [ApiController]
    [Route("account")]
    public class Controller : ControllerBase
    {
        private readonly AccountDB _ACDB;
        
        public Controller(ILogger<Controller> logger, AccountDB acdb)
        {            
            _ACDB = acdb;
        }

        [HttpGet]
        [Route("test")]
        public ActionResult<String> TestEndPoint(){
            return "Test Succesful";
        }

        [HttpPost]
        public async Task<IResult> PostAccount(Account account)
        {
            _ACDB.Accounts.Add(account);
            await _ACDB.SaveChangesAsync();
            return Results.Created($"/{account.Email}", account);
        }

        [HttpGet]
        [Route("allitems")]
        public async Task<ActionResult<List<Account>>> GetAllItems()
        {
            return await _ACDB.Accounts.ToListAsync();
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<Account>> GetTodoItem(string email)
        {
            var account = await _ACDB.Accounts.Where(m => m.Email  == email).ToListAsync();
            
            if(account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        [HttpPut]
        public async Task<IResult> PutTodo(Account acc1)
        {
            var acc2 = await _ACDB.Accounts.FindAsync(acc1.AccountId);

            if(acc2 == null)
            {
                return Results.NotFound();
            }

            //Update Values
            acc2.Email = acc1.Email;
            acc2.FirstName = acc1.FirstName;
            acc2.LastName = acc1.LastName;
            acc2.Password = acc1.Password;

            acc2.CardNum = acc1.CardNum;
            acc2.ExpDate = acc1.ExpDate;
            acc2.SecurityNum = acc1.SecurityNum;
            acc2.NameOnCard = acc1.NameOnCard;

            acc2.Street = acc1.Street;
            acc2.Apartment = acc1.Apartment;
            acc2.City = acc1.City;
            acc2.State = acc1.State;
            acc2.ZipCode = acc1.ZipCode;
            //acc2.ShipAddress = acc1.ShipAddress;

            await _ACDB.SaveChangesAsync();

            return Results.NoContent();
        } 

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteTodo(int id)
        {
            if(await _ACDB.Accounts.FindAsync(id) is Account account)
            {
                _ACDB.Accounts.Remove(account);
                await _ACDB.SaveChangesAsync();
                return Results.Ok(account);
            }
            
            return Results.NotFound();

        }
    }
}