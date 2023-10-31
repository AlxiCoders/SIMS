using SIMS.Server.Data;
using SIMS.Server.Entities;
using SIMS.Server.Repositories.Contracts;
using SIMS.Shared;
using Microsoft.EntityFrameworkCore;

namespace SIMS.Server.Repositories
{
    public class FacultyRepository:IFacultyRepository
    {
        private readonly StudentDbContext studentDbContext;
        public FacultyRepository(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            //Extracting the whole departments list from Departments table
            var departments = await this.studentDbContext.Departments.ToListAsync();
            return departments;
        }
        public async Task<Department> GetDepartment(int Id)
        {
            //Fetching the particular department from Departments Table
            var department = await studentDbContext.Departments.SingleOrDefaultAsync(d => d.Id == Id);
            return department;
        }
        public async Task<IEnumerable<Faculty>> GetFaculties()
        {
            //Extracting the whole faculties list from Faculties table 
            var faculties = await this.studentDbContext.Faculties.ToListAsync();
            return faculties;
        }

        public async Task<Faculty> GetFaculty(int Id)
        {
            //Fetching the particular faculty from Faculties Table
            var faculty = await studentDbContext.Faculties.FindAsync(Id);
            return faculty;
        }
    }
}
