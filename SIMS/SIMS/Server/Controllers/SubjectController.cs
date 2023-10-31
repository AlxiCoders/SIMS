using Microsoft.AspNetCore.Mvc;
using SIMS.API.Extensions;
using SIMS.Server.Repositories.Contracts;
using SIMS.Shared.Dtos;

namespace SIMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        //Dependency injection of interface by creating instance of it
        private readonly ISubjectRepository SubjectRepository;
        public SubjectController(ISubjectRepository SubjectRepository)
        {
            this.SubjectRepository = SubjectRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetSubjects()
        {
            try
            {
                //Calling the function of the repository class
                var faculties = await this.SubjectRepository.GetFaculties();
                var semesters = await this.SubjectRepository.GetSemesters();
                var subjects = await this.SubjectRepository.GetSubjects();

                if (faculties == null || semesters == null || subjects == null)
                {
                    return NotFound();
                }
                else
                {
                    // Convert the list of subjects and (semesters, faculties) to a DTO (Data Transfer Object)
                    var subjectDto = subjects.ConvertToDto(semesters, faculties);
                    return Ok(subjectDto);
                }

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SubjectDto>> GetSubject(string id)
        {
            try
            {
                var subject = await this.SubjectRepository.GetSubject(id);

                if (subject == null)
                {
                    return BadRequest();
                }
                else
                {
                    var semester = await this.SubjectRepository.GetSemester(subject.Sem_Id);
                    var faculty = await this.SubjectRepository.GetFaculty(semester.Fac_Id);

                    var subjectDto = subject.ConvertToDto(semester, faculty);
                    return Ok(subjectDto);
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

