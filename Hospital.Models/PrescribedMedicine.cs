using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class PrescribedMedicine
    {
        public int Id { get; set; }
        public Medicine Medicine { get; set; }
        public PataintReport pataintReport { get; set; }
    }
}
