using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModel
{
    public class ApplecationUserViewModel
    {
        public List<ApplecationUser> Doctors { get; set; }=new List<ApplecationUser>();
        public string Name { get; set; }
        public string City { get; set; }
        public Gender Gender { get; set; }
        public bool IsDoctor { get; set; }
        public string specailLIst { get; set; }
        public ApplecationUserViewModel()
        {
            
        }
        public ApplecationUserViewModel(ApplecationUser user)
        {
            Name = user.Name;
            City=user.City; 
            Gender=user.Gender; 
            IsDoctor = user.IsDoctor;
            specailLIst = user.SpecailList;
        }
        public ApplecationUser ConvertViewModel(ApplecationUserViewModel model)
        {
            return new  ApplecationUser{
                Name = model.Name,
                City = model.City,
                Gender = model.Gender,
                IsDoctor = model.IsDoctor,
                SpecailList = model.specailLIst
                };
              
            } }
    }

