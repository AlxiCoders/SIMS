using Microsoft.AspNetCore.Mvc;
using SIMS.API.Extensions;
using SIMS.Server.Repositories.Contracts;
using SIMS.Shared.Dtos;


namespace SIMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HodController : ControllerBase
    {
        //Dependency injection of interface by creating instance of it
        private readonly IHodRepository hodRepository;
        public HodController(IHodRepository hodRepository)
        {
            this.hodRepository = hodRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HodDto>>> GetHods()
        {
            try
            {
                //Calling the function of the repository class
                var hods = await this.hodRepository.GetHods();
                var departments = await this.hodRepository.GetDepartments();

                if (hods == null || departments == null)
                {
                    return NotFound();
                }
                else
                {
                    // Convert the list of hods and departments to a DTO (Data Transfer Object)
                    var hodDto = hods.ConvertToDto(departments);
                    // Return a 200 OK response with the hodDto in the response body.
                    return Ok(hodDto);
                }
                
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<HodDto>> GetHod(int id)
        {
            try
            {
                var hod = await this.hodRepository.GetHod(id);
                
                if (hod == null)
                {
                    return BadRequest();
                }
                else
                {
                    var department = await this.hodRepository.GetDepartment(hod.Dept_Id);

                    var hodDto = hod.ConvertToDto(department);
                    return Ok(hodDto);
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
