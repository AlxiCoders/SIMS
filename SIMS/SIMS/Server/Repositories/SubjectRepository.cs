using SIMS.Server.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using SIMS.Server.Data;
using SIMS.Server.Entities;

namespace SIMS.Server.Repositories
{
    public class SubjectRepository:ISubjectRepository
    {
        private readonly StudentDbContext studentDbContext;
        public SubjectRepository(StudentDbContext studentDbContext)
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

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            var subjects = await this.studentDbContext.Subjects.ToListAsync();
            return subjects;
        }
        public async Task<Subject> GetSubject(string id)
        {
            //Fetching the particular subject from Subjects Table
            var subject = await studentDbContext.Subjects.FindAsync(id);
            return subject;
        }
    }
}
