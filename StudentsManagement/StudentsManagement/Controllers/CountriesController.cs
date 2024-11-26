using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsManagement.Data;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CountriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Countries
        [HttpGet("All-Countries")]
        public async Task<ActionResult<IEnumerable<Country>>> GetAllCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        // GET: api/Countries/5
        [HttpGet("Single-Country/{id}")]
        public async Task<ActionResult<Country>> GetSingleCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Update-Country")]
        public async Task<ActionResult<Country>> UpdateStudentsAsync(Country country)
        {
            _context.Update(country);
           await _context.SaveChangesAsync();
            return Ok(country);
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add-Country")]
        public async Task<ActionResult<Country>> AddNewCountry(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("Delete-Country/{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}
