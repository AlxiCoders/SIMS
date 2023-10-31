using Microsoft.AspNetCore.Mvc;
using SIMS.API.Extensions;
using SIMS.Server.Repositories.Contracts;
using SIMS.Shared.Dtos;

namespace SIMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        //Dependency injection of interface by creating instance of it
        private readonly ISemesterRepository SemesterRepository;
        public SemesterController(ISemesterRepository SemesterRepository)
        {
            this.SemesterRepository= SemesterRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SemesterDto>>> GetSemesters()
        {
            try
            {
                //Calling the function of the repository class
                var faculties = await this.SemesterRepository.GetFaculties();
                var semesters = await this.SemesterRepository.GetSemesters();

                if (faculties == null || semesters == null)
                {
                    return NotFound();
                }
                else
                {
                    // Convert the list of semesters and faculties to a DTO (Data Transfer Object)
                    var semesterDto = semesters.ConvertToDto(faculties);
                    return Ok(semesterDto);
                }

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SemesterDto>> GetSemester(int id)
        {
            try
            {
                var semester = await this.SemesterRepository.GetSemester(id);

                if (semester == null)
                {
                    return BadRequest();
                }
                else
                {
                    var faculty = await this.SemesterRepository.GetFaculty(semester.Fac_Id);

                    var semesterDto = semester.ConvertToDto(faculty);
                    return Ok(semesterDto);
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
