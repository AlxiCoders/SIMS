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

        public async Task DeleteDepartment(int id)
        {
            var item = await studentDbContext.Departments.FindAsync(id);
            studentDbContext.Departments.Remove(item);
            await this.studentDbContext.SaveChangesAsync();
        }

        public async Task AddDepartment(Department department)
        {
            studentDbContext.Departments.Add(department);
            await this.studentDbContext.SaveChangesAsync();
        }

        public async Task UpdateDepartment(Department department)
        {
            studentDbContext.Departments.Update(department);
            await this.studentDbContext.SaveChangesAsync();
        }
    }
}
