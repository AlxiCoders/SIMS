using SIMS.Shared;

namespace SIMS.Server.Repositories.Contracts
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int id);
    }
}
