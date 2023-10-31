using SIMS.Server.Data;
using SIMS.Server.Entities;
using SIMS.Server.Repositories.Contracts;
using SIMS.Shared;
using Microsoft.EntityFrameworkCore;

namespace SIMS.Server.Repositories
{
    public class HodRepository:IHodRepository
    {
        private readonly StudentDbContext studentDbContext;

        public HodRepository(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }
        public async Task<Department> GetDepartment(int id)
        {
            var category = await studentDbContext.Departments.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            var departments = await this.studentDbContext.Departments.ToListAsync();
            return departments;
        }

        public async Task<HOD> GetHod(int id)
        {
            var hod = await studentDbContext.HODs.FindAsync(id);
            return hod;
        }

        public async Task<IEnumerable<HOD>> GetHods()
        {
            var hods = await this.studentDbContext.HODs.ToListAsync();
            return hods;
        }
    }
}
