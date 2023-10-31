using SIMS.Server.Entities;

namespace SIMS.Server.Repositories.Contracts
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Faculty>> GetFaculties();
        Task<IEnumerable<Semester>> GetSemesters();
        Task<IEnumerable<Subject>> GetSubjects();
        Task<Faculty> GetFaculty(int id);
        Task<Semester> GetSemester(int id);
        Task<Subject> GetSubject(string id);
    }
}
