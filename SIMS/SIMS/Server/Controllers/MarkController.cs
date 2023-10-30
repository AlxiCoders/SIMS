using Microsoft.AspNetCore.Mvc;
using SIMS.API.Extensions;
using SIMS.Server.Repositories.Contracts;
using SIMS.Shared.Dtos;

namespace SIMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        //Dependency injection of interface by creating instance of it
        public readonly IMarkRepository markRepository;
        public MarkController(IMarkRepository markRepository)
        {
            this.markRepository = markRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarkDto>>> GetMarks()
        {
            try
            {
                //Calling the function of the repository class
                var faculties = await this.markRepository.GetFaculties();
                var students = await this.markRepository.GetStudents();
                var semesters = await this.markRepository.GetSemesters();
                var subjects = await this.markRepository.GetSubjects();
                var marks = await this.markRepository.GetMarks();

                if (students == null || semesters == null || subjects == null || marks==null || faculties==null)
                {
                    return NotFound();
                }
                else
                {
                    // Convert the list of marks and (students, semesters, subjects, faculties) to a DTO (Data Transfer Object)
                    var markDto = marks.ConvertToDto(students,semesters, subjects,faculties);
                    return Ok(markDto);
                }

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MarkDto>> GetMark(int id)
        {
            try
            {
                var mark = await this.markRepository.GetMark(id);

                if (mark == null)
                {
                    return BadRequest();
                }
                else
                {
                    var subject = await this.markRepository.GetSubject(mark.Sub_Id);
                    var semester = await this.markRepository.GetSemester(subject.Sem_Id);
                    var faculty = await this.markRepository.GetFaculty(semester.Fac_Id);
                    var student = await this.markRepository.GetStudent(mark.Std_Id);

                    var markDto = mark.ConvertToDto(student, semester, faculty, subject);
                    return Ok(markDto);
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
