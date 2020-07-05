using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ehrmadesimple.Data;
using ehrmadesimple.Models;

namespace ehrmadesimple.Controllers
{
    public class ClientInfoesController : Controller
    {
        private readonly AppDbContext _context;

        public ClientInfoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ClientInfoes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ClientInfoes.Include(c => c.Client);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ClientInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientInfo = await _context.ClientInfoes
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.ClientInfoId == id);
            if (clientInfo == null)
            {
                return NotFound();
            }

            return View(clientInfo);
        }

        // GET: ClientInfoes/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId");
            return View();
        }

        // POST: ClientInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientInfoId,ClientId,ClientEmail,Street,City,State,Zip,BdayMonth,BdayDay,BdayYear,Sex,RelationshipStatus,EmploymentStatus,EmergencyFname,EmergencyLname,EmergencyRelationship,EmergencyEmail,EmergencyPhone")] ClientInfo clientInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", clientInfo.ClientId);
            return View(clientInfo);
        }

        // GET: ClientInfoes/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            var entity = _context.ClientInfoes.FirstOrDefault(e => e.ClientId == id);  
            if (entity == null) {  
                return NotFound();
            }
            return View(entity);
        }

        // POST: ClientInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientInfoId,ClientId,ClientEmail,Street,City,State,Zip,BdayMonth,BdayDay,BdayYear,Sex,RelationshipStatus,EmploymentStatus,EmergencyFname,EmergencyLname,EmergencyRelationship,EmergencyEmail,EmergencyPhone")] ClientInfo clientInfo)
        {
            if (id != clientInfo.ClientInfoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientInfoExists(clientInfo.ClientInfoId))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", clientInfo.ClientId);
            return View(clientInfo);
        }

        // GET: ClientInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientInfo = await _context.ClientInfoes
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.ClientInfoId == id);
            if (clientInfo == null)
            {
                return NotFound();
            }

            return View(clientInfo);
        }

        // POST: ClientInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientInfo = await _context.ClientInfoes.FindAsync(id);
            _context.ClientInfoes.Remove(clientInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientInfoExists(int id)
        {
            return _context.ClientInfoes.Any(e => e.ClientInfoId == id);
        }
    }
}
