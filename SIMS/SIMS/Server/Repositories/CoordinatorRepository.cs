using Microsoft.EntityFrameworkCore;
using SIMS.Server.Data;
using SIMS.Server.Entities;
using SIMS.Server.Repositories.Contracts;
using SIMS.Shared.Dtos;

namespace SIMS.Server.Repositories
{
    public class CoordinatorRepository : ICoordinatorRepository
    {
        private readonly StudentDbContext studentDbContext;
        public CoordinatorRepository(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }
        public async Task<Coordinator> GetCoordinator(int Id)
        {
            //Fetching the particular coordinator from Coordinators Table
            var coordinator = await studentDbContext.Coordinators.FindAsync(Id);
            return coordinator;
        }

        public async Task<IEnumerable<Coordinator>> GetCoordinators()
        {
            //Extracting the whole coordinators list from Coordinators table 
            var coordinators = await this.studentDbContext.Coordinators.ToListAsync();
            return coordinators;
        }

        public async Task<IEnumerable<Faculty>> GetFaculties()
        {
            //Extracting the whole faculties list from Faculties table 
            var faculties = await this.studentDbContext.Faculties.ToArrayAsync();
            return faculties;
        }
        public async Task<Faculty> GetFaculty(int Id)
        {
            //Fetching the particular faculty from Faculties Table
            var faculty = await studentDbContext.Faculties.SingleOrDefaultAsync(f => f.Id == Id);
            return faculty;
        }

    }
}
