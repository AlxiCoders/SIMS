using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Shared.Dtos
{
    public class FacultyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public int Dep_Id { get; set; }
        public string Dep_Name { get; set; }
    }
}
