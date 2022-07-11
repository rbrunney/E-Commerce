using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    [ApiController]
    [Route("account")]
    public class Controller : ControllerBase
    {
        private readonly AccountDB _ACDB;
        // private readonly AddressDB _ADDB;
        // private readonly CreditCardDB _CDB;
        
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
            var todo = await _ACDB.Accounts.FindAsync(email);
            
            if(todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        [HttpPut]
        public async Task<IResult> PutTodo(Account acc1)
        {
            var acc2 = await _ACDB.Accounts.FindAsync(acc1.Email);

            if(acc2 == null)
            {
                return Results.NotFound();
            }

            //Update Values
            acc2.Email = acc1.Email;
            acc2.FirstName = acc1.FirstName;
            acc2.LastName = acc1.LastName;
            acc2.Password = acc1.Password;
            acc2.PaymentInfo = acc1.PaymentInfo;
            acc2.ShipAddress = acc1.ShipAddress;

            await _ACDB.SaveChangesAsync();

            return Results.NoContent();
        } 

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteTodo(long id)
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