using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModel
{
    public class HospetalViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string Country { get; set; }
        public HospetalViewModel()
        {
            
        }
        public HospetalViewModel(HospitalInfo model)
        {
            Id=model.Id;
            Name = model.Name;
            Type = model.Type;
            City = model.City;
            PinCode = model.PinCode;
            Country = model.Country;

        }
        public HospitalInfo ConvertViewModel(HospetalViewModel model)
        {
            return new HospitalInfo
            {
                Id = model.Id,
                Name = model.Name,
                Type = model.Type,
                City = model.City,
                PinCode = model.PinCode,
                Country = model.Country
            };

        }
    }
}
