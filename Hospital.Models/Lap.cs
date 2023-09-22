using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Lap
    {
        public int Id { get; set; }
        public string LapNummber { get; set; }
        public ApplecationUser Patiant { get; set; }
        public string TestType { get; set; }
        public string TestCode { get; set; }
        public int Hight { get; set; }
        public int Wight { get; set; }
        public int BloodPressure { get; set; }
        public int Tempreture { get; set; }
        public string TestResult { get; set; }
    }
}
