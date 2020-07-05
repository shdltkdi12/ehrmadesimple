using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ehrmadesimple.Data;
using ehrmadesimple.Models;

namespace ehrmadesimple.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialQuestionAnswersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InitialQuestionAnswersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/InitialQuestionAnswers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InitialQuestionAnswer>>> GetInitialQuestionAnswers()
        {
            return await _context.InitialQuestionAnswers.ToListAsync();
        }

        // GET: api/InitialQuestionAnswers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InitialQuestionAnswer>> GetInitialQuestionAnswer(int id)
        {
            var initialQuestionAnswer = await _context.InitialQuestionAnswers.FindAsync(id);

            if (initialQuestionAnswer == null)
            {
                return NotFound();
            }

            return initialQuestionAnswer;
        }

        // PUT: api/InitialQuestionAnswers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInitialQuestionAnswer(int id, InitialQuestionAnswer initialQuestionAnswer)
        {
            if (id != initialQuestionAnswer.RowNumber)
            {
                return BadRequest();
            }

            _context.Entry(initialQuestionAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InitialQuestionAnswerExists(id))
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

        // POST: api/InitialQuestionAnswers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<InitialQuestionAnswer>> PostInitialQuestionAnswer(InitialQuestionAnswer initialQuestionAnswer)
        {
            _context.InitialQuestionAnswers.Add(initialQuestionAnswer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInitialQuestionAnswer", new { id = initialQuestionAnswer.RowNumber }, initialQuestionAnswer);
        }

        // DELETE: api/InitialQuestionAnswers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InitialQuestionAnswer>> DeleteInitialQuestionAnswer(int id)
        {
            var initialQuestionAnswer = await _context.InitialQuestionAnswers.FindAsync(id);
            if (initialQuestionAnswer == null)
            {
                return NotFound();
            }

            _context.InitialQuestionAnswers.Remove(initialQuestionAnswer);
            await _context.SaveChangesAsync();

            return initialQuestionAnswer;
        }

        private bool InitialQuestionAnswerExists(int id)
        {
            return _context.InitialQuestionAnswers.Any(e => e.RowNumber == id);
        }
    }
}
