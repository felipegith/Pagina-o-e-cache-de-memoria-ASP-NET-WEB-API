using ECONOMY.API.Model;
using ECONOMY.API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECONOMY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceRepository _balanceRepository;
       
       
        public BalanceController(IBalanceRepository balanceRepository, IMemoryCache memoryCache)
        {
            _balanceRepository = balanceRepository;
            
   
        }

        [HttpGet("macaddress/{macaddress}/skip/{skip:int}/take/{take:int}")]
        public async Task<ActionResult<List<AccountVO>>> GetAll(string macaddress, int skip = 0, int take = 25)
        {
            if (ModelState.IsValid)
            {
                var getAll = await _balanceRepository.GetAll(macaddress, skip, take);
                                      

                if (getAll != null)
                    return Ok(new { data = getAll });
            }

            return NotFound();
        }

        [HttpPost("balance")]
        public async Task<ActionResult<BalanceVO>> Post([FromBody] BalanceVO model)
        {
            if (ModelState.IsValid)
            {
                var handleBalance = await _balanceRepository.CreateBalance(model);
                return Ok(handleBalance);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BalanceVO>> Update([FromBody] BalanceVO value, long id)
        {
            if (ModelState.IsValid)
            {
                var handleUpdate = await _balanceRepository.Update(value, id);

                return Ok(handleUpdate);
            }

            return BadRequest();
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<AccountVO>> GetById(long id)
        {
            if (ModelState.IsValid)
            {
                var identifyBy = await _balanceRepository.GetById(id);

                if (identifyBy != null)
                    return Ok(identifyBy);
            }

            return NotFound();
        }
    }
}
