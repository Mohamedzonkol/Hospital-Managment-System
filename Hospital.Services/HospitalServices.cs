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
    public class HospitalServices : IHospitalServices
    {
        private readonly IUnitOfWork unit;

        public HospitalServices(IUnitOfWork _unit)
        {
            unit = _unit;
        }

        public void Delete(int hospitalId)
        {
            var vm =unit.genericRepositonries<HospetalViewModel>().GetById(hospitalId);
            unit.genericRepositonries<HospetalViewModel>().Delete(vm);
            unit.Save();

        }

        public PagedResult<HospetalViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm =new HospetalViewModel();
            int totalCount;
            List<HospetalViewModel> vmList = new List<HospetalViewModel>();
            try
            {
                int excuteRecords = (pageSize * pageNumber) - pageSize;
                var modelList = unit.genericRepositonries<HospitalInfo>().GetAll()
                    .Skip(excuteRecords).Take(pageSize).ToList();
                totalCount = unit.genericRepositonries<HospitalInfo>().GetAll().ToList().Count();
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            PagedResult<HospetalViewModel> result = new PagedResult<HospetalViewModel>
            {
                Data = vmList,
                TotalItem = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        public HospetalViewModel getById(int hospitalId)
        {
            var model = unit.genericRepositonries<HospitalInfo>().GetById(hospitalId);
            var vm = new HospetalViewModel(model);
            return vm;
        }

        public void Insetrt(HospetalViewModel hospital)
        {
            var vm = new HospetalViewModel().ConvertViewModel(hospital);
            unit.genericRepositonries<HospitalInfo>().Add(vm);
            unit.Save();
        } 


        public void Update(HospetalViewModel hospital)
        {
            var vm = new HospetalViewModel().ConvertViewModel(hospital);
            var modelById = unit.genericRepositonries<HospitalInfo>().GetById(vm.Id);
            modelById.PinCode = vm.PinCode;
            modelById.Name = vm.Name;
            modelById.City = vm.City;
            modelById.Country = vm.Country;
            unit.genericRepositonries<HospitalInfo>().Update(modelById);
            unit.Save();
        }

        private List<HospetalViewModel> ConvertModelToViewModelList(List<HospitalInfo> modelList)
        {
            return modelList.Select(x => new HospetalViewModel(x)).ToList();
        }
    }
}
