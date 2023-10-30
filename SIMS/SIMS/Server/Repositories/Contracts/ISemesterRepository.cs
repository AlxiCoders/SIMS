using SIMS.Server.Entities;

namespace SIMS.Server.Repositories.Contracts
{
    public interface ISemesterRepository
    {
        Task<IEnumerable<Faculty>> GetFaculties();
        Task<IEnumerable<Semester>> GetSemesters();
        Task<Faculty> GetFaculty(int id);
        Task<Semester> GetSemester(int id);
    }
}
