using ECONOMY.API.Database;
using ECONOMY.API.Model;
using ECONOMY.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECONOMY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ServerContext _context;

        public AccountController(IAccountRepository accountRepository, ServerContext context)
        {
            _accountRepository = accountRepository;
            _context = context;
        }
        [HttpGet("{identify}")]
        public async Task<ActionResult<AccountVO>> GetByIdentify(string identify)
        {
            if (ModelState.IsValid)
            {
                var account = await _accountRepository.GetByIdentify(identify);
                return Ok(account);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<AccountVO>> Post([FromBody] AccountVO model)
        {
            if (ModelState.IsValid)
            {
                await _accountRepository.Create(model);
                return CreatedAtAction("GetByIdentify", new { identify = model.Identify }, model);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<AccountVO>> Update([FromBody] AccountVO model)
        {
            if (model == null)
                return BadRequest();

            var handleUpdate = await _accountRepository.Update(model);

            return Ok(handleUpdate);
        }

        [HttpDelete("{identify}")]
        public async Task<ActionResult> Delete(string identify)
        {
            await _accountRepository.Delete(identify);

            return NoContent();
        }
    }
}
