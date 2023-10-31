using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Shared.Dtos
{
    public class HodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Dept_Id { get; set; }
        public string Dept_Name { get; set; }
    }
}
