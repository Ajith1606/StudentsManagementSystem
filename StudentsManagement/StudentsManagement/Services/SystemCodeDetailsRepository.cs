using Microsoft.EntityFrameworkCore;
using StudentsManagement.Data;
using StudentsManagement.Shared.Models;
using StudentsManagement.Shared.StudentRepository;

namespace StudentsManagement.Services
{
    public class SystemCodeDetailsRepository : ISystemCodeDetailsRepository
    {
        private readonly ApplicationDbContext _context;
        public SystemCodeDetailsRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<SystemCodeDetails> AddAsync(SystemCodeDetails systemcodedetails)
        {
            if (systemcodedetails == null) return null;

            var newsystemcodedetails = _context.SystemCodeDetails.Add(systemcodedetails).Entity;
            await _context.SaveChangesAsync();
            return systemcodedetails;
        }

        public async Task<SystemCodeDetails> DeleteAsync(int systemcodedetailsId)
        {
            var systemcodedetails = await _context.SystemCodeDetails.Where(x => x.Id == systemcodedetailsId).FirstOrDefaultAsync();
            if (systemcodedetails == null) return null;
            _context.SystemCodeDetails.Remove(systemcodedetails);
            await _context.SaveChangesAsync();

            return systemcodedetails;
        }

        public async Task<List<SystemCodeDetails>> GetAllAsync()
        {
            var SystemCodeDetails = await _context.SystemCodeDetails.Include(x => x.SystemCode).ToListAsync();
            return SystemCodeDetails;
        }

        public async Task<SystemCodeDetails> GetByIdAsync(int systemcodedetailsId)
        {
            var systemcodedetails = await _context.SystemCodeDetails.Where(x => x.Id == systemcodedetailsId).FirstOrDefaultAsync();
            if (systemcodedetails == null) return null;

            return systemcodedetails;
        }

        public async Task<SystemCodeDetails> UpdateAsync(SystemCodeDetails systemcodedetails)
        {
            if (systemcodedetails == null) return null;

            var newsystemcodedetails = _context.SystemCodeDetails.Update(systemcodedetails).Entity;
            await _context.SaveChangesAsync();
            return newsystemcodedetails;
        }
    }
}
