using Hospital.Models;
using Hospital.Repositonries.Interfaces;
using Hospital.Utilites;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class Contactservices : IContactServiceses
    {
        private readonly IUnitOfWork unit;

        public Contactservices(IUnitOfWork _unit)
        {
            unit = _unit;
        }
        public void Delete(int Id)
        {
            Contact model = unit.genericRepositonries<Contact>().GetById(Id);
            unit.genericRepositonries<Contact>().Delete(model);
            unit.Save();
        }

        public PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new ContactViewModel();
            int totalCount;
            List<ContactViewModel> vmList = new List<ContactViewModel>();
            try
            {
                int excuteRecords = (pageSize * pageNumber) - pageSize;
                var modelList = unit.genericRepositonries<Contact>().GetAll(includeProperties: "Hospital")
                 .Skip(excuteRecords).Take(pageSize).ToList();
                totalCount = unit.genericRepositonries<Contact>().GetAll().ToList().Count();
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            PagedResult<ContactViewModel> result = new PagedResult<ContactViewModel>
            {
                Data = vmList,
                TotalItem = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }
        public ContactViewModel getContactById(int id)
        {
            var contact = unit.genericRepositonries<Contact>().GetById(id);
            var vm = new ContactViewModel(contact);
            return vm;

        }

        public void Insetrt(ContactViewModel contact)
        {
            var vm = new ContactViewModel().ConvertViewModel(contact);
            unit.genericRepositonries<Contact>().Add(vm);
            unit.Save();
        }

        public void Update(ContactViewModel contant)
        {
            var vm = new ContactViewModel().ConvertViewModel(contant);
            var modelByID = unit.genericRepositonries<Contact>().GetById(vm.Id);
            modelByID.Phone = contant.Phone;
            modelByID.Email= contant.Email;
            modelByID.HospitalId = contant.hospitalId;
            unit.genericRepositonries<Contact>().Update(modelByID);
            unit.Save();
        }
        private List<ContactViewModel> ConvertModelToViewModelList(List<Contact> modelList)
        {
            return modelList.Select(x => new ContactViewModel(x)).ToList();
        }
    }
}
