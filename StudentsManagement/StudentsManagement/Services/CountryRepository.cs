using Microsoft.EntityFrameworkCore;
using StudentsManagement.Data;
using StudentsManagement.Shared.Models;
using StudentsManagement.Shared.StudentRepository;

namespace StudentsManagement.Services
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;
        public CountryRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public  async Task<Country> AddAsync(Country mod)
        {
            if (mod == null) return null;

            var newcountry = _context.Countries.Add(mod).Entity;
            await _context.SaveChangesAsync();
            return newcountry;
        }

        public async Task<Country> DeleteAsync(int id)
        {
            var country = await _context.Countries.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (country == null) return null;
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return country;
        }

        public async Task<List<Country>> GetAllAsync()
        {
            var country = await _context.Countries.ToListAsync();
            return country;
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            var singlecountry = await _context.Countries.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (singlecountry == null) return null;

            return singlecountry;
        }

        public async Task<Country> UpdateAsync(Country mod)
        {
            if (mod == null) return null;

            var newcountry = _context.Countries.Update(mod).Entity;
            await _context.SaveChangesAsync();
            return newcountry;
        }
    }
}
