using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeStaff_WebAPI.Data;
using OfficeStaff_WebAPI.Models;

namespace OfficeStaff_WebAPI.Controllers
{
    public class OfficeClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OfficeClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OfficeClients
        public async Task<IActionResult> Index()
        {
            return View(await _context.OfficeClients.ToListAsync());
        }

        // GET: OfficeClients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeClients = await _context.OfficeClients
                .FirstOrDefaultAsync(m => m.ID == id);
            if (officeClients == null)
            {
                return NotFound();
            }

            return View(officeClients);
        }

        // GET: OfficeClients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OfficeClients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Mobile,Email,City")] OfficeClients officeClients)
        {
            if (ModelState.IsValid)
            {
                _context.Add(officeClients);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(officeClients);
        }

        // GET: OfficeClients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeClients = await _context.OfficeClients.FindAsync(id);
            if (officeClients == null)
            {
                return NotFound();
            }
            return View(officeClients);
        }

        // POST: OfficeClients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Mobile,Email,City")] OfficeClients officeClients)
        {
            if (id != officeClients.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(officeClients);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfficeClientsExists(officeClients.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(officeClients);
        }

        // GET: OfficeClients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeClients = await _context.OfficeClients
                .FirstOrDefaultAsync(m => m.ID == id);
            if (officeClients == null)
            {
                return NotFound();
            }

            return View(officeClients);
        }

        // POST: OfficeClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var officeClients = await _context.OfficeClients.FindAsync(id);
            _context.OfficeClients.Remove(officeClients);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfficeClientsExists(int id)
        {
            return _context.OfficeClients.Any(e => e.ID == id);
        }
    }
}
