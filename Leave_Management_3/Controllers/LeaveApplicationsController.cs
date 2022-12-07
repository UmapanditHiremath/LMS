using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Leave_Management_3.Models;

namespace Leave_Management_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveApplicationsController : ControllerBase
    {
        private readonly Umapandit_LeaveManagmentContext _context;

        public LeaveApplicationsController(Umapandit_LeaveManagmentContext context)
        {
            _context = context;
        }

        // GET: api/LeaveApplications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveApplication>>> GetLeaveApplication()
        {
            return await _context.LeaveApplication.ToListAsync();
        }

        // GET: api/LeaveApplications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveApplication>> GetLeaveApplication(int id)
        {
            var leaveApplication = await _context.LeaveApplication.FindAsync(id);

            if (leaveApplication == null)
            {
                return NotFound();
            }

            return leaveApplication;
        }

        // PUT: api/LeaveApplications/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaveApplication(int id, LeaveApplication leaveApplication)
        {
            if (id != leaveApplication.LeaveId)
            {
                return BadRequest();
            }

            _context.Entry(leaveApplication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveApplicationExists(id))
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

        // POST: api/LeaveApplications
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LeaveApplication>> PostLeaveApplication(LeaveApplication leaveApplication)
        {
            _context.LeaveApplication.Add(leaveApplication);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LeaveApplicationExists(leaveApplication.LeaveId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLeaveApplication", new { id = leaveApplication.LeaveId }, leaveApplication);
        }

        // DELETE: api/LeaveApplications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LeaveApplication>> DeleteLeaveApplication(int id)
        {
            var leaveApplication = await _context.LeaveApplication.FindAsync(id);
            if (leaveApplication == null)
            {
                return NotFound();
            }

            _context.LeaveApplication.Remove(leaveApplication);
            await _context.SaveChangesAsync();

            return leaveApplication;
        }

        private bool LeaveApplicationExists(int id)
        {
            return _context.LeaveApplication.Any(e => e.LeaveId == id);
        }
    }
}
