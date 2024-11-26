using StudentsManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagement.Shared.StudentRepository
{
    public interface IParentRepository
    {
        Task<Parent> AddAsync(Parent mod);
        Task<Parent> UpdateAsync(Parent mod);
        Task<Parent> DeleteAsync(int id);
        Task<List<Parent>> GetAllAsync();
        Task<Parent> GetByIdAsync(int id);
    }
}
