using Bill_Tracker.Data;
using Bill_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bill_Tracker.Controllers
{
    [Route("api/bills")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Bill>> GetBillsAsync()
        {
            return await _context.bills.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bill>> GetBillAsync(int id)
        {
            var bill = await _context.bills.FirstOrDefaultAsync(i => i.Id == id);
            if(bill == null)
            {
                return NotFound();
            }
            return bill;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBill(Bill bill)
        {
            if(bill == null)
            {
                return BadRequest();
            }

            _context.bills.Add(bill);
            await _context.SaveChangesAsync();

            return StatusCode(201, bill);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBill(int id)
        {
            var bill = await _context.bills.FirstOrDefaultAsync(i => i.Id == id);
            if(bill == null)
            {
                return NotFound();
            }

            _context.bills.Remove(bill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BillExists(int id)
        {
            return _context.bills.Any(b => b.Id == id);
        }
    }
}
