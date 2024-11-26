using Microsoft.EntityFrameworkCore;
using StudentsManagement.Data;
using StudentsManagement.Shared.Models;
using StudentsManagement.Shared.StudentRepository;

namespace StudentsManagement.Services
{
    public class ParentRepository : IParentRepository
    {
        private readonly ApplicationDbContext _context;
        public ParentRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Parent> AddAsync(Parent mod)
        {
            if (mod == null) return null;

            var newparent = _context.Parents.Add(mod).Entity;
            await _context.SaveChangesAsync();
            return newparent;
        }

        public async Task<Parent> DeleteAsync(int id)
        {
            var parent = await _context.Parents.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (parent == null) return null;
            _context.Parents.Remove(parent);
            await _context.SaveChangesAsync();

            return parent;
        }

        public async Task<List<Parent>> GetAllAsync()
        {
            var parent = await _context.Parents.ToListAsync();
            return parent;
        }

        public async Task<Parent> GetByIdAsync(int id)
        {
            var singleparent = await _context.Parents.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (singleparent == null) return null;

            return singleparent;
        }

        public async Task<Parent> UpdateAsync(Parent mod)
        {
            if (mod == null) return null;

            var newparent = _context.Parents.Update(mod).Entity;
            await _context.SaveChangesAsync();
            return newparent;
        }
    }
}
