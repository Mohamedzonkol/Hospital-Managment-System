using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class ApplecationUser :IdentityUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; } 
        
        public string Nationality { get; set; }
        public string Adress { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsDoctor { get; set; }
        public string SpecailList { get; set; }
        public string City { get; set; }
        public Department Department { get; set; }
        [NotMapped]
        public  ICollection<Appointment>Appointments { get; set; }
        [NotMapped]
        public ICollection<Payroll>Payrolls { get; set; }



    }
}

namespace Hospital.Models
{
    public enum Gender
    {
        Male,Female,Other
    }
}