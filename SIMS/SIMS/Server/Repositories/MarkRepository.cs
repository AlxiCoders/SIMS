using SIMS.Server.Data;
using SIMS.Server.Entities;
using SIMS.Server.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace SIMS.Server.Repositories
{
    public class MarkRepository:IMarkRepository
    {
        public readonly StudentDbContext studentDbContext;
        public MarkRepository(StudentDbContext studentDbContext)
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


        public async Task<IEnumerable<Mark>> GetMarks()
        {
            var marks = await this.studentDbContext.Marks.ToListAsync();
            return marks;
        }

        public async Task<Mark> GetMark(int id)
        {
            var mark = await studentDbContext.Marks.FindAsync(id);
            return mark;
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
            var student = await studentDbContext.Students.SingleOrDefaultAsync(s => s.Id == id);
            return student;
        }
        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            //Extracting the whole subjects list from Subjects table
            var subjects = await this.studentDbContext.Subjects.ToListAsync();
            return subjects;
        }

        public async Task<Subject> GetSubject(string id)
        {
            //Fetching the particular subject from Subjects Table
            var subject = await studentDbContext.Subjects.SingleOrDefaultAsync(su => su.Id == id);
            return subject;
        }
    }
}
