using SIMS.Server.Entities;
using SIMS.Shared.Dtos;

namespace SIMS.Server.Repositories.Contracts
{
    public interface ICoordinatorRepository
    {
        Task<IEnumerable<Faculty>> GetFaculties();
        Task<IEnumerable<Coordinator>> GetCoordinators();
        Task<Faculty> GetFaculty(int Id);
        Task<Coordinator> GetCoordinator(int Id);
    }
}