using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoraOnlineAPI.Models;

namespace KoraOnlineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PunishmentsController : ControllerBase
    {
        private readonly KoraOnline _context;

        public PunishmentsController(KoraOnline context)
        {
            _context = context;
        }

        // GET: api/Punishments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Punishment>>> GetPunishments()
        {
            return await _context.Punishments.ToListAsync();
        }

        // GET: api/Punishments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Punishment>> GetPunishment(int id)
        {
            var punishment = await _context.Punishments.FindAsync(id);

            if (punishment == null)
            {
                return NotFound();
            }

            return punishment;
        }

        // PUT: api/Punishments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPunishment(int id, Punishment punishment)
        {
            if (id != punishment.PunishId)
            {
                return BadRequest();
            }

            _context.Entry(punishment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PunishmentExists(id))
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

        // POST: api/Punishments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Punishment>> PostPunishment(Punishment punishment)
        {
            _context.Punishments.Add(punishment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PunishmentExists(punishment.PunishId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPunishment", new { id = punishment.PunishId }, punishment);
        }

        // DELETE: api/Punishments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePunishment(int id)
        {
            var punishment = await _context.Punishments.FindAsync(id);
            if (punishment == null)
            {
                return NotFound();
            }

            _context.Punishments.Remove(punishment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PunishmentExists(int id)
        {
            return _context.Punishments.Any(e => e.PunishId == id);
        }
    }
}
