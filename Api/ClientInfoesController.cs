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
    public class ClientInfoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientInfoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ClientInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientInfo>>> GetClientInfos()
        {
            return await _context.ClientInfoes.ToListAsync();
        }

        // GET: api/ClientInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientInfo>> GetClientInfo(string id)
        {
            var entity = _context.ClientInfoes.FirstOrDefault(e => e.ClientId == id);  
            if (entity == null) {  
                return NotFound();
            } 
            else {
                return Ok(entity);  
            }
        }

        // PUT: api/ClientInfoes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientInfo(string id, [FromBody]ClientInfo body)
        {
            var entity = _context.ClientInfoes.FirstOrDefault(e => e.ClientId == id);  
            if (entity == null) {  
                return NotFound();
            } 
            else {
                _context.Entry(entity).State = EntityState.Modified;  
                _context.ClientInfoes.Remove(entity);
                _context.ClientInfoes.Add(body);
                _context.SaveChanges();  
                return Ok(entity);  
            }
            return NoContent();
        }

        // POST: api/ClientInfoes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ClientInfo>> PostClientInfo(ClientInfo clientInfo)
        {
            _context.ClientInfoes.Add(clientInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientInfo", new { id = clientInfo.ClientInfoId }, clientInfo);
        }

        // DELETE: api/ClientInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientInfo>> DeleteClientInfo(int id)
        {
            var clientInfo = await _context.ClientInfoes.FindAsync(id);
            if (clientInfo == null)
            {
                return NotFound();
            }

            _context.ClientInfoes.Remove(clientInfo);
            await _context.SaveChangesAsync();

            return clientInfo;
        }

        private bool ClientInfoExists(int id)
        {
            return _context.ClientInfoes.Any(e => e.ClientInfoId == id);
        }
    }
}
