using SIMS.Server.Entities;
using SIMS.Shared;
using SIMS.Shared.Dtos;

namespace SIMS.Server.Repositories.Contracts
{
    public interface IFacultyRepository
    {
        Task<IEnumerable<Faculty>> GetFaculties();
        Task<IEnumerable<Department>> GetDepartments();
        Task<Faculty> GetFaculty(int Id);
        Task<Department> GetDepartment(int Id);
    }
}
