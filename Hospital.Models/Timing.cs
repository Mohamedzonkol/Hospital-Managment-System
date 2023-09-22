using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Timing
    {
        public int Id { get; set; }
        public ApplecationUser DooctorId { get; set; }
        public DateTime DateTime { get; set; }
        public int MornningShiftStrartingTime { get; set; }
        public int MornningShiftEndingTime { get; set; } 
        public int afternoonShiftStrartingTime { get; set; }
        public int afternoonShiftEndingTime { get; set; }
        public int Duratoin { get; set; }   
        public Status Status { get; set; }
    }
}

namespace Hospital.Models
{
    public enum Status
    {
        Avaliable,Panding,Confirm
    }
}