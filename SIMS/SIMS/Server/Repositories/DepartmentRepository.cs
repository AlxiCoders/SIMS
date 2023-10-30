using Microsoft.EntityFrameworkCore;
using SIMS.Server.Data;
using SIMS.Server.Repositories.Contracts;
using SIMS.Shared;

namespace SIMS.Server.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly StudentDbContext studentDbContext;
        public DepartmentRepository(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            //Extracting the whole departments list from Departments table
            var departments = await this.studentDbContext.Departments.ToListAsync();
            return departments;
        }
        public async Task<Department> GetDepartment(int id)
        {
            var category = await studentDbContext.Departments.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }
    }
}
