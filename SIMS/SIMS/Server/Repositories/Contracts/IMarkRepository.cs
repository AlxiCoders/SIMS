using SIMS.Server.Entities;

namespace SIMS.Server.Repositories.Contracts
{
    public interface IMarkRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<IEnumerable<Semester>> GetSemesters();
        Task<IEnumerable<Subject>> GetSubjects();
        Task<IEnumerable<Mark>> GetMarks();
        Task<IEnumerable<Faculty>> GetFaculties();

        Task<Student> GetStudent(int id);
        Task<Semester> GetSemester(int id);
        Task<Subject> GetSubject(string id);
        Task<Mark> GetMark(int id);
        Task<Faculty> GetFaculty(int id);
    }
}
