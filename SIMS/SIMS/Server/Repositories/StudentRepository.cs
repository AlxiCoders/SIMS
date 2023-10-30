using SIMS.Server.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using SIMS.Server.Data;
using SIMS.Server.Entities;

namespace SIMS.Server.Repositories
{
    public class StudentRepository:IStudentRepository
    {
        private readonly StudentDbContext studentDbContext;
        public StudentRepository(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;

        }
        public async Task<IEnumerable<Faculty>> GetFaculties()
        {
            var faculties = await this.studentDbContext.Faculties.ToListAsync();
            return faculties;
        }

        public async Task<Faculty> GetFaculty(int id)
        {
            //Fetching the particular faculty from Faculties Table
            var faculty = await studentDbContext.Faculties.SingleOrDefaultAsync(f => f.Id == id);
            return faculty;
        }



        public async Task<IEnumerable<Semester>> GetSemesters()
        {
            var semesters = await this.studentDbContext.Semesters.ToListAsync();
            return semesters;
        }

        public async Task<Semester> GetSemester(int id)
        {
            //Fetching the particular semester from Semesters Table
            var semester = await studentDbContext.Semesters.SingleOrDefaultAsync(s => s.Id == id);
            return semester;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            var students = await this.studentDbContext.Students.ToListAsync();
            return students;
        }
        public async Task<Student> GetStudent(int id)
        {
            //Fetching the particular student from Students Table
            var student = await studentDbContext.Students.FindAsync(id);
            return student;
        }
    }
}
