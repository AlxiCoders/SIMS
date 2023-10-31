using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Shared.Dtos
{
    public class SemesterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Fac_Id { get; set; }
        public string Fac_Name { get; set; }
    }
}
