using Microsoft.AspNetCore.Mvc;
using StudentsManagement.Shared.Models;
using StudentsManagement.Shared.StudentRepository;

namespace StudentsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
                this._studentRepository = studentRepository;
        }

        [HttpGet("All-Students")]
        public async Task<ActionResult<List<Student>>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllStudentAsync();
            return Ok(students);
        }

        [HttpGet("Single-Students/{id}")]
        public async Task<ActionResult<Student>> GetSingleStudentAsync(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            return Ok(student);
        }

        [HttpPost("Add-Student")]
        public async Task<ActionResult<Student>> AddNewStudentsAsync(Student student)
        {
            var newstudent = await _studentRepository.AddStudentAsync(student);
            return Ok(newstudent);
        }


        [HttpPost("Delete-Student/{id}")]
        public async Task<ActionResult<Student>> DeleteStudentsAsync(int id)
        {
            var deletestudent = await _studentRepository.DeleteStudentAsync(id);
            return Ok(deletestudent);
        }

        [HttpPost("Update-Student")]
        public async Task<ActionResult<Student>> UpdateStudentsAsync(Student student)
        {
            var updatestudent = await _studentRepository.UpdateStudentAsync(student);
            return Ok(updatestudent);
        }
    }
}
