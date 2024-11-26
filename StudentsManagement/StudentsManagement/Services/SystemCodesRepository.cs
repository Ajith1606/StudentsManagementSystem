using Microsoft.EntityFrameworkCore;
using StudentsManagement.Data;
using StudentsManagement.Shared.Models;
using StudentsManagement.Shared.StudentRepository;

namespace StudentsManagement.Services
{
    public class SystemCodesRepository : ISystemCodeRepository
    {
        private readonly ApplicationDbContext _context;
        public SystemCodesRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<SystemCode> AddAsync(SystemCode systemcode)
        {
            if (systemcode == null) return null;

            var newsystemcode = _context.SystemCodes.Add(systemcode).Entity;
            await _context.SaveChangesAsync();
            return newsystemcode;
        }

        public async Task<SystemCode> DeleteAsync(int systemcodeId)
        {
            var systemcode = await _context.SystemCodes.Where(x => x.Id == systemcodeId).FirstOrDefaultAsync();
            if (systemcode == null) return null;
            _context.SystemCodes.Remove(systemcode);
            await _context.SaveChangesAsync();

            return systemcode;
        }
        public async Task<List<SystemCode>> GetAllAsync()
        {
            var systemcodes = await _context.SystemCodes.ToListAsync();
            return systemcodes;
        }

        public async Task<SystemCode> GetByIdAsync(int systemcodeId)
        {
            var singlesystemcode = await _context.SystemCodes.Where(x => x.Id == systemcodeId).FirstOrDefaultAsync();
            if (singlesystemcode == null) return null;

            return singlesystemcode;
        }

        public async Task<SystemCode> UpdateAsync(SystemCode systemcode)
        {
            if (systemcode == null) return null;

            var newsystemcode = _context.SystemCodes.Update(systemcode).Entity;
            await _context.SaveChangesAsync();
            return newsystemcode;
        }
    }
}
