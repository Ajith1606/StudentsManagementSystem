using StudentsManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagement.Shared.StudentRepository
{
    public interface ISystemCodeRepository
    {
        Task<SystemCode> AddAsync(SystemCode systemcode);
        Task<SystemCode> UpdateAsync(SystemCode systemcode);
        Task<SystemCode> DeleteAsync(int systemcodeId);
        Task<List<SystemCode>> GetAllAsync();
        Task<SystemCode> GetByIdAsync(int systemcodeId);
    }
}
