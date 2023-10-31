using Microsoft.AspNetCore.Mvc;
using SIMS.API.Extensions;
using SIMS.Server.Repositories.Contracts;
using SIMS.Shared.Dtos;

namespace SIMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        //Dependency injection of interface by creating instance of it
        private readonly IFacultyRepository facultyRepository;
        public FacultyController(IFacultyRepository facultyRepository)
        {
            this.facultyRepository = facultyRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacultyDto>>> GetFaculties()
        {
            try
            {
                //Calling the function of the repository class
                var faculties = await this.facultyRepository.GetFaculties();
                var departments = await this.facultyRepository.GetDepartments();

                if (faculties == null || departments == null)
                {
                    return NotFound();
                }
                else
                {
                    // Convert the list of faculties and departments to a DTO (Data Transfer Object)
                    var facultyDto = faculties.ConvertToDto(departments);
                    return Ok(facultyDto);
                }

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FacultyDto>> GetFaculty(int id)
        {
            try
            {
                var faculty = await this.facultyRepository.GetFaculty(id);

                if (faculty == null)
                {
                    return BadRequest();
                }
                else
                {
                    var department = await this.facultyRepository.GetDepartment(faculty.Dep_Id);

                    var facultyDto = faculty.ConvertToDto(department);
                    return Ok(facultyDto);
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
