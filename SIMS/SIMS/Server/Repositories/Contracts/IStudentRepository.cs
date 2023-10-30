using SIMS.Server.Entities;

namespace SIMS.Server.Repositories.Contracts
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Faculty>> GetFaculties();
        Task<IEnumerable<Semester>> GetSemesters();
        Task<IEnumerable<Student>> GetStudents();
        Task<Faculty> GetFaculty(int id);
        Task<Semester> GetSemester(int id);
        Task<Student> GetStudent(int id);
    }
}
