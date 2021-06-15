using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBAAccountAPI.Models;

namespace SBAAccountAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SBAAccountsController : ControllerBase
    {
        private readonly SBAAccountDBContext _context;

        public SBAAccountsController(SBAAccountDBContext context)
        {
            _context = context;
        }

        // GET: api/SBAAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SBAAccount>>> Getaccounts()
        {
            return await _context.accounts.ToListAsync();
        }

        // GET: api/SBAAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SBAAccount>> GetSBAAccount(int id)
        {
            var sBAAccount = await _context.accounts.FindAsync(id);

            if (sBAAccount == null)
            {
                return NotFound();
            }

            return sBAAccount;
        }

        // PUT: api/SBAAccounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSBAAccount(int id, SBAAccount sBAAccount)
        {
            if (id != sBAAccount.accountNumber)
            {
                return BadRequest();
            }

            _context.Entry(sBAAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SBAAccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SBAAccounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SBAAccount>> PostSBAAccount(SBAAccount sBAAccount)
        {
            _context.accounts.Add(sBAAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSBAAccount", new { id = sBAAccount.accountNumber }, sBAAccount);
        }

        // DELETE: api/SBAAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSBAAccount(int id)
        {
            var sBAAccount = await _context.accounts.FindAsync(id);
            if (sBAAccount == null)
            {
                return NotFound();
            }

            _context.accounts.Remove(sBAAccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SBAAccountExists(int id)
        {
            return _context.accounts.Any(e => e.accountNumber == id);
        }
    }
}
