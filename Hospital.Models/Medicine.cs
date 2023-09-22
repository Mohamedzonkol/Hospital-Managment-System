using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public ICollection<MedicineReport> Report { get; set; }
        public ICollection<PrescribedMedicine> prescribedMedicines { get; set; }
    }
}
