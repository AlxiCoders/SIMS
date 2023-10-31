using Microsoft.AspNetCore.Mvc;
using SIMS.API.Extensions;
using SIMS.Server.Repositories.Contracts;
using SIMS.Shared.Dtos;

namespace SIMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordinatorController : ControllerBase
    {
        //Dependency injection of interface by creating instance of it
        private readonly ICoordinatorRepository coordinatorRepository;
        public CoordinatorController(ICoordinatorRepository coordinatorRepository)
        { 
            this.coordinatorRepository = coordinatorRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoordinatorDto>>> GetCoordinators()
        {
            try
            {
                //Calling the function of the repository class
                var coordinators = await this.coordinatorRepository.GetCoordinators();
                var faculties = await this.coordinatorRepository.GetFaculties();

                if (coordinators == null || faculties == null)
                {
                    return NotFound();
                }
                else
                {
                    // Convert the list of coordinators and faculties to a DTO (Data Transfer Object)
                    var coordinatorDto = coordinators.ConvertToDto(faculties);
                    // Return a 200 OK response with the coordinatorDto in the response body.
                    return Ok(coordinatorDto);
                }

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CoordinatorDto>> GetCoordinator(int id)
        {
            try
            {
                var coordinator = await this.coordinatorRepository.GetCoordinator(id);

                if (coordinator == null)
                {
                    return BadRequest();
                }
                else
                {
                    // Fetch faculty information based on the provided 'Fac_Id'
                    var faculty = await this.coordinatorRepository.GetFaculty(coordinator.Fac_Id);
                    var coordinatorDto = coordinator.ConvertToDto(faculty);
                    return Ok(coordinatorDto);
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
