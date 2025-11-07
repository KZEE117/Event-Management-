using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventManagement.Data;
using EventManagement.Models;

namespace EventManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly EventDbContext _context;

        public RegistrationsController(EventDbContext context)
        {
            _context = context;
        }

        // ✅ GET all admins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admins>>> GetRegistrations()
        {
            return await _context.Admins.ToListAsync();
        }

        // ✅ GET one admin by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Admins>> GetRegistration(int id)
        {
            var registration = await _context.Admins.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }
            return registration;
        }

        // ✅ UPDATE admin info
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistration(int id, Admins registration)
        {
            if (id != registration.RegistrationId) // ✅ fixed field name
            {
                return BadRequest();
            }

            _context.Entry(registration).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // ✅ CREATE new admin
        [HttpPost]
        public async Task<ActionResult<Admins>> PostRegistration(Admins registration)
        {
            _context.Admins.Add(registration);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRegistration), new { id = registration.RegistrationId }, registration); // ✅ fixed field name
        }

        // ✅ DELETE admin
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistration(int id)
        {
            var registration = await _context.Admins.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }

            _context.Admins.Remove(registration);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
