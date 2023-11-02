using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIMS.Server.Repositories.Contracts;
using SIMS.Shared;
using SIMS.Shared.Dtos;

namespace SIMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            try
            {
                //Calling the function of the repository class
                var departments = await this.departmentRepository.GetDepartments();

                if (departments == null)
                {
                    return NotFound();
                }
                else
                {
                    return departments.ToList();
                }

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDept(int id)
        {
            await this.departmentRepository.DeleteDepartment(id);
            return NoContent();

        }

        [HttpPost]
        public async Task<ActionResult>AddDept(Department department)
        {
            try
            {
                if (department == null)
                {
                    return BadRequest();
                }
                else
                {
                    await this.departmentRepository.AddDepartment(department);
                    return NoContent();
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpPut]
        public async Task<ActionResult>UpdateDepart(Department department)
        {
            try
            {
                if (department == null)
                {
                    return BadRequest();
                }
                else
                {
                    await this.departmentRepository.UpdateDepartment(department);
                    return NoContent();
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
