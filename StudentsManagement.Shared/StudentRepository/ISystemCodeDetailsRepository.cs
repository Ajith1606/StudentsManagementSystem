using StudentsManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagement.Shared.StudentRepository
{
    public interface ISystemCodeDetailsRepository
    {
        Task<SystemCodeDetails> AddAsync(SystemCodeDetails systemcodedetails);
        Task<SystemCodeDetails> UpdateAsync(SystemCodeDetails systemcodedetails);
        Task<SystemCodeDetails> DeleteAsync(int systemcodedetailsId);
        Task<List<SystemCodeDetails>> GetAllAsync();
        Task<SystemCodeDetails> GetByIdAsync(int systemcodedetailsId);
    }
}
