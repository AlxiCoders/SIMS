using SIMS.Shared;

namespace SIMS.Client.Services.Contracts
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task Create_Department(Department department);
        Task EditDept(Department department);
        Task Delete_Department(int id);
    }
}
