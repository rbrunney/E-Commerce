using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    [ApiController]
    [Route("api1")]
    public class Controller : ControllerBase
    {
        private readonly AccountDB _ACDB;
        private readonly AddressDB _ADDB;
        private readonly CreditCardDB _CDB;
        
        public Controller(ILogger<Controller> logger, AccountDB adb)
        {            
            _ACDB = adb;
        }

        [HttpPost]
        public async Task<IResult> PostAccount(Account account)
        {
            _ACDB.Accounts.Add(account);
            await _ACDB.SaveChangesAsync();
            return Results.Created($"/{account.Email}", _ACDB);
        }

    }

}