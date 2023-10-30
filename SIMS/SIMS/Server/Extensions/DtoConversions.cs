
using SIMS.Server.Entities;
using SIMS.Shared;
using SIMS.Shared.Dtos;

namespace SIMS.API.Extensions
{
    public static class DtoConversions
    {
        // Converts a collection of HOD entities to HOD DTOs.
        public static IEnumerable<HodDto> ConvertToDto(this IEnumerable<HOD> hods,
           IEnumerable<Department> departments)
        {
            return (from hod in hods
                    join department in departments
                    on hod.Dept_Id equals department.Id
                    select new HodDto
                    {
                        Id = hod.Id,
                        Name = hod.Name,
                        ImageURL = hod.ImageURL,
                        Email = hod.Email,
                        Phone = hod.Phone,
                        Dept_Id = hod.Dept_Id,
                        Dept_Name = department.Name
                    }).ToList();
        }
        // Converts a single HOD entity and its associated Department into a HodDto object.
        public static HodDto ConvertToDto(this HOD hod,
           Department department)
        {
            return new HodDto
            {
                Id = hod.Id,
                Name = hod.Name,
                ImageURL = hod.ImageURL,
                Email = hod.Email,
                Phone = hod.Phone,
                Dept_Id = hod.Dept_Id,
                Dept_Name = department.Name
            };
        }
        // Converts a collection of Coordinator entities to Coordinator DTOs.
        public static IEnumerable<CoordinatorDto> ConvertToDto(this IEnumerable<Coordinator> coordinators,
           IEnumerable<Faculty> faculties)
        {
            return (from coordinator in coordinators
                    join faculty in faculties
                    on coordinator.Fac_Id equals faculty.Id
                    select new CoordinatorDto
                    {
                        Id = coordinator.Id,
                        Name = coordinator.Name,
                        ImageURL =coordinator.ImageURL,
                        Email = coordinator.Email,
                        Phone = coordinator.Phone,
                        Fac_Id = coordinator.Fac_Id,
                        Fac_Name = faculty.Name
                    }).ToList();
        }

        // Converts a single Coordinator entity and its associated Department into a CoordinatorDto object.
        public static CoordinatorDto ConvertToDto(this Coordinator coordinator,
           Faculty faculty)
        {
            return new CoordinatorDto
            {
                Id = coordinator.Id,
                Name = coordinator.Name,
                ImageURL = coordinator.ImageURL,
                Email = coordinator.Email,
                Phone = coordinator.Phone,
                Fac_Id = coordinator.Fac_Id,
                Fac_Name = faculty.Name
            };
        }

        public static IEnumerable<FacultyDto> ConvertToDto(this IEnumerable<Faculty> faculties,
           IEnumerable<Department> departments)
        {
            return (from faculty in faculties
                    join department in departments
                    on faculty.Dep_Id equals department.Id
                    select new FacultyDto
                    {
                        Id = faculty.Id,
                        Name = faculty.Name,
                        Status= faculty.Status,
                        Dep_Id = faculty.Dep_Id,
                        Dep_Name = department.Name
                    }).ToList();
        }

        // Converts a single Faculty entity and its associated Department into a FacultyDto object.
        public static FacultyDto ConvertToDto(this Faculty faculty,
           Department department)
        {
            return new FacultyDto
            {
                Id = faculty.Id,
                Name = faculty.Name,
                Status = faculty.Status,
                Dep_Id = faculty.Dep_Id,
                Dep_Name = department.Name
            };
        }
        // Converts a collection of Semester entities to Semester DTOs.
        public static IEnumerable<SemesterDto> ConvertToDto(this IEnumerable<Semester> semesters,
           IEnumerable<Faculty> faculties)
        {
            return (from semester in semesters
                    join faculty in faculties
                    on semester.Fac_Id equals faculty.Id
                    select new SemesterDto
                    {
                        Id = semester.Id,
                        Name = semester.Name,
                        Fac_Id = semester.Fac_Id,
                        Fac_Name = faculty.Name
                    }).ToList();
        }


        // Converts a single Semester entity and its associated Fcaulty into a SemesterDto object.
        public static SemesterDto ConvertToDto(this Semester semester,
           Faculty faculty)
        {
            return new SemesterDto
            {
                Id = semester.Id,
                Name = semester.Name,
                Fac_Id = semester.Fac_Id,
                Fac_Name = faculty.Name
            };
        }

        // Converts a collection of Subject entities to Subject DTOs.
        public static IEnumerable<SubjectDto> ConvertToDto(this IEnumerable<Subject> subjects, IEnumerable<Semester> semesters,
           IEnumerable<Faculty> faculties)
        {
            return (from subject in subjects
                    join semester in semesters
                    on subject.Sem_Id equals semester.Id
                    join faculty in faculties
                    on semester.Fac_Id equals faculty.Id

                    select new SubjectDto
                    {
                        Id = subject.Id,
                        Name = subject.Name,
                        Sem_Id = subject.Sem_Id,
                        Sem_Name = semester.Name,
                        Fac_Id = semester.Fac_Id,
                        Fac_Name = faculty.Name
                    }).ToList();
        }


        // Converts a single Subject entity and its associated Semester, Faculty into a SubjectDto object.
        public static SubjectDto ConvertToDto(this Subject subject, Semester semester, Faculty faculty)
        {
            return new SubjectDto
            {
                Id = subject.Id,
                Name = subject.Name,
                Sem_Id = subject.Sem_Id,
                Sem_Name = semester.Name,
                Fac_Id = semester.Fac_Id,
                Fac_Name = faculty.Name
            };
        }

        // Converts a collection of Student entities to Student DTOs.
        public static IEnumerable<StudentDto> ConvertToDto(this IEnumerable<Student> students, IEnumerable<Semester> semesters,
           IEnumerable<Faculty> faculties)
        {
            return (from student in students
                    join semester in semesters
                    on student.Sem_Id equals semester.Id
                    join faculty in faculties
                    on semester.Fac_Id equals faculty.Id

                    select new StudentDto
                    {
                        Id = student.Id,
                        Name = student.Name,
                        ImageURL = student.ImageURL,
                        Sem_Id = student.Sem_Id,
                        Sem_Name = semester.Name,
                        Fac_Id = semester.Fac_Id,
                        Fac_Name = faculty.Name,
                        Email = student.Email,
                        Phone = student.Phone
                    }).ToList();
        }

        // Converts a single Student entity and its associated Semester, Faculty into a StudentDto object.
        public static StudentDto ConvertToDto(this Student student, Semester semester, Faculty faculty)
        {
            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                ImageURL = student.ImageURL,
                Sem_Id = student.Sem_Id,
                Sem_Name = semester.Name,
                Fac_Id = semester.Fac_Id,
                Fac_Name = faculty.Name,
                Email = student.Email,
                Phone = student.Phone
            };
        }

        // Converts a collection of Mark entities to Mark DTOs.
        public static IEnumerable<MarkDto> ConvertToDto(this IEnumerable<Mark> marks,
           IEnumerable<Student> students,
           IEnumerable<Semester> semesters,
           IEnumerable<Subject> subjects,
           IEnumerable<Faculty> faculties)
        {
            return (from mark in marks
                    join student in students
                    on mark.Std_Id equals student.Id
                    join subject in subjects
                    on mark.Sub_Id equals subject.Id
                    join semester in semesters
                    on subject.Sem_Id equals semester.Id
                    join faculty in faculties
                    on  semester.Fac_Id equals faculty.Id


                    select new MarkDto
                    {
                        Id = mark.Id,
                        Std_Id = mark.Std_Id,
                        Std_Name = student.Name,
                        Sem_Id = subject.Sem_Id,
                        Sem_Name = semester.Name,
                        Sub_Id = mark.Sub_Id,
                        Sub_Name = subject.Name,
                        Fac_Id = semester.Fac_Id,
                        Fac_Name = faculty.Name,
                        Score = mark.Score,
                    }).ToList();
        }

        // Converts a single Mark entity and its associated Student, Semester, Faculty, Subject into a MarkDto object.
        public static MarkDto ConvertToDto(this Mark mark, Student student, Semester semester, Faculty faculty,
           Subject subject)
        {
            return new MarkDto
            {
                Id = mark.Id,
                Std_Id = mark.Std_Id,
                Std_Name = student.Name,
                Sem_Id = subject.Sem_Id,
                Sem_Name = semester.Name,
                Sub_Id = mark.Sub_Id,
                Sub_Name = subject.Name,
                Fac_Id = semester.Fac_Id,
                Fac_Name = faculty.Name,
                Score = mark.Score,
            };
        }
    }
}
