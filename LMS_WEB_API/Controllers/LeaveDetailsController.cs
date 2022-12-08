using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LMS_WEB_API.Models;

namespace LMS_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveDetailsController : ControllerBase
    {
        private readonly LMSDbContext _context;

        public LeaveDetailsController(LMSDbContext context)
        {
            _context = context;
        }

        // GET: api/LeaveDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveDetails>>> GetLeaveDetails()
        {
            return await _context.LeaveDetails.ToListAsync();
        }

        // GET: api/LeaveDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveDetails>> GetLeaveDetails(int id)
        {
            var leaveDetails = await _context.LeaveDetails.FindAsync(id);

            if (leaveDetails == null)
            {
                return NotFound();
            }

            return leaveDetails;
        }

        // PUT: api/LeaveDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaveDetails(int id, LeaveDetails leaveDetails)
        {
            if (id != leaveDetails.LeaveDetailsId)
            {
                return BadRequest();
            }

            _context.Entry(leaveDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveDetailsExists(id))
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

        // POST: api/LeaveDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LeaveDetails>> PostLeaveDetails(LeaveDetails leaveDetails)
        {
            _context.LeaveDetails.Add(leaveDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeaveDetails", new { id = leaveDetails.LeaveDetailsId }, leaveDetails);
        }

        // DELETE: api/LeaveDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LeaveDetails>> DeleteLeaveDetails(int id)
        {
            var leaveDetails = await _context.LeaveDetails.FindAsync(id);
            if (leaveDetails == null)
            {
                return NotFound();
            }

            _context.LeaveDetails.Remove(leaveDetails);
            await _context.SaveChangesAsync();

            return leaveDetails;
        }

        private bool LeaveDetailsExists(int id)
        {
            return _context.LeaveDetails.Any(e => e.LeaveDetailsId == id);
        }
    }
}
