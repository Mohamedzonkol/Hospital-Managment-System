using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModel
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int hospitalId { get; set; }
        public HospitalInfo hospital { get; set; }

        public ContactViewModel()
        {
            
        }
        public ContactViewModel(Contact model)
        {
            Id = model.Id;
            Email=model.Email;
            Phone=model.Phone;
            hospitalId=model.HospitalId;
            hospital = model.Hospital;
        }
        public Contact ConvertViewModel(ContactViewModel model)
        {
            return new Contact
            {
              Id = model.Id,
              Email= model.Email,
              Phone=model.Phone,
              HospitalId=model.hospitalId,
              Hospital=model.hospital
              
            };

        }
    }
}
