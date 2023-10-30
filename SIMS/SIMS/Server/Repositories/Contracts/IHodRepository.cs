using SIMS.Server.Entities;
using SIMS.Shared;

namespace SIMS.Server.Repositories.Contracts
{
    public interface IHodRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<IEnumerable<HOD>> GetHods();
        Task<Department> GetDepartment(int id);
        Task<HOD> GetHod(int id);

    }
}
