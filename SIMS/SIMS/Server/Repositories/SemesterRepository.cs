using SIMS.Server.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using SIMS.Server.Data;
using SIMS.Server.Entities;

namespace SIMS.Server.Repositories
{
    public class SemesterRepository:ISemesterRepository
    {
        private readonly StudentDbContext studentDbContext;
        public SemesterRepository(StudentDbContext studentDbContext)
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
            var semester = await studentDbContext.Semesters.FindAsync(id);
            return semester;
        }
    }
}
