using Microsoft.AspNetCore.Mvc;
using SIMS.API.Extensions;
using SIMS.Server.Repositories.Contracts;
using SIMS.Shared.Dtos;

namespace SIMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //Dependency injection of interface by creating instance of it
        public readonly IStudentRepository studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            try
            {
                //Calling the function of the repository class
                var faculties = await this.studentRepository.GetFaculties();
                var semesters = await this.studentRepository.GetSemesters();
                var students = await this.studentRepository.GetStudents();

                if (faculties == null || semesters == null || students == null)
                {
                    return NotFound();
                }
                else
                {
                    // Convert the list of students and (semesters,faculties) to a DTO (Data Transfer Object)
                    var studentDto = students.ConvertToDto(semesters, faculties);
                    return Ok(studentDto);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            try
            {
                var student = await this.studentRepository.GetStudent(id);


                if (student == null)
                {
                    return BadRequest();
                }
                else
                {
                    var semester = await this.studentRepository.GetSemester(student.Sem_Id);
                    var faculty = await this.studentRepository.GetFaculty(semester.Fac_Id);

                    var studentDto = student.ConvertToDto(semester, faculty);
                    return Ok(studentDto);
                }

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }
    }
}
