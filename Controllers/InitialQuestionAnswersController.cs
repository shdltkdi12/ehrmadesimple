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
    public class InitialQuestionAnswersController : Controller
    {
        private readonly AppDbContext _context;

        public InitialQuestionAnswersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: InitialQuestionAnswers
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.InitialQuestionAnswers.Include(i => i.Client);
            return View(await appDbContext.ToListAsync());
        }

        // GET: InitialQuestionAnswers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var initialQuestionAnswer = await _context.InitialQuestionAnswers
                .Include(i => i.Client)
                .FirstOrDefaultAsync(m => m.RowNumber == id);
            if (initialQuestionAnswer == null)
            {
                return NotFound();
            }

            return View(initialQuestionAnswer);
        }

        // GET: InitialQuestionAnswers/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId");
            return View();
        }

        // POST: InitialQuestionAnswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RowNumber,ClientId,Email,InitialDetails,isConsultedBefore,MedicationDetails,PrescribingMdDetails,PrimaryPhysicianDetails,isAlcohol,isDrug,isSuicidal,isAttemptedSuicide,isHarmOthers,isHospitalized,isFamilyMemberIll,RelationshipDetails,LivingStatus,OccupationDetails,PastMonthSymptoms,GeneralSymptoms,Extra")] InitialQuestionAnswer initialQuestionAnswer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(initialQuestionAnswer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", initialQuestionAnswer.ClientId);
            return View(initialQuestionAnswer);
        }

        // GET: InitialQuestionAnswers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var initialQuestionAnswer = await _context.InitialQuestionAnswers.FindAsync(id);
            if (initialQuestionAnswer == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", initialQuestionAnswer.ClientId);
            return View(initialQuestionAnswer);
        }

        // POST: InitialQuestionAnswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RowNumber,ClientId,Email,InitialDetails,isConsultedBefore,MedicationDetails,PrescribingMdDetails,PrimaryPhysicianDetails,isAlcohol,isDrug,isSuicidal,isAttemptedSuicide,isHarmOthers,isHospitalized,isFamilyMemberIll,RelationshipDetails,LivingStatus,OccupationDetails,PastMonthSymptoms,GeneralSymptoms,Extra")] InitialQuestionAnswer initialQuestionAnswer)
        {
            if (id != initialQuestionAnswer.RowNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(initialQuestionAnswer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InitialQuestionAnswerExists(initialQuestionAnswer.RowNumber))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", initialQuestionAnswer.ClientId);
            return View(initialQuestionAnswer);
        }

        // GET: InitialQuestionAnswers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var initialQuestionAnswer = await _context.InitialQuestionAnswers
                .Include(i => i.Client)
                .FirstOrDefaultAsync(m => m.RowNumber == id);
            if (initialQuestionAnswer == null)
            {
                return NotFound();
            }

            return View(initialQuestionAnswer);
        }

        // POST: InitialQuestionAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var initialQuestionAnswer = await _context.InitialQuestionAnswers.FindAsync(id);
            _context.InitialQuestionAnswers.Remove(initialQuestionAnswer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InitialQuestionAnswerExists(int id)
        {
            return _context.InitialQuestionAnswers.Any(e => e.RowNumber == id);
        }
    }
}
