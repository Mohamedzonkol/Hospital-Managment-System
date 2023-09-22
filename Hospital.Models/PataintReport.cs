using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class PataintReport
    {
        public int Id{ get; set; }
        public string Diagnose { get; set; } //التشخيص
        public ApplecationUser Dector { get; set; }
        public ApplecationUser Patiant { get; set; }
        public ICollection<PrescribedMedicine> PrescribedMedicines { get; set; }
    }
}
