using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeStaff_WebAPI.Data;
using OfficeStaff_WebAPI.Models;

namespace OfficeStaff_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeStaffsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OfficeStaffsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/OfficeStaffs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficeStaff>>> GetOfficeStaffs()
        {
            return await _context.OfficeStaffs.ToListAsync();
        }

        // GET: api/OfficeStaffs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfficeStaff>> GetOfficeStaff(int id)
        {
            var officeStaff = await _context.OfficeStaffs.FindAsync(id);

            if (officeStaff == null)
            {
                return NotFound();
            }

            return officeStaff;
        }

        // PUT: api/OfficeStaffs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfficeStaff(int id, OfficeStaff officeStaff)
        {
            if (id != officeStaff.ID)
            {
                officeStaff.ID=id;
            }

            _context.Entry(officeStaff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeStaffExists(id))
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

        // POST: api/OfficeStaffs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OfficeStaff>> PostOfficeStaff(OfficeStaff officeStaff)
        {
            _context.OfficeStaffs.Add(officeStaff);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfficeStaff", new { id = officeStaff.ID }, officeStaff);
        }

        // DELETE: api/OfficeStaffs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OfficeStaff>> DeleteOfficeStaff(int id)
        {
            var officeStaff = await _context.OfficeStaffs.FindAsync(id);
            if (officeStaff == null)
            {
                return NotFound();
            }

            _context.OfficeStaffs.Remove(officeStaff);
            await _context.SaveChangesAsync();

            return officeStaff;
        }

        private bool OfficeStaffExists(int id)
        {
            return _context.OfficeStaffs.Any(e => e.ID == id);
        }
    }
}
