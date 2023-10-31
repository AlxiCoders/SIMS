using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Shared.Dtos
{
    public class MarkDto
    {
        public int Id { get; set; }
        public int Std_Id { get; set; }
        public string Std_Name { get; set; }
        public int Sem_Id { get; set; }
        public string Sem_Name { get; set; }
        public int Fac_Id { get; set; }
        public string Fac_Name { get; set; }
        public string Sub_Id { get; set; }
        public string Sub_Name { get; set; }
        public double Score { get; set; }
    }
}
