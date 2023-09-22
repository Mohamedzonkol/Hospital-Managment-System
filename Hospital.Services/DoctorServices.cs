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
    public class DoctorServices : IDoctorServices
    {
        private readonly IUnitOfWork unit;

        public DoctorServices(IUnitOfWork _unit)
        {
            unit = _unit;
        }
        public void Delete(int TiimingId)
        {
            var vm = unit.genericRepositonries<Timing>().GetById(TiimingId);
            unit.genericRepositonries<Timing>().Delete(vm);
            unit.Save();

        }

        public PagedResult<TimmingViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new TimmingViewModel();
            int totalCount;
            List<TimmingViewModel> vmList = new List<TimmingViewModel>();
            try
            {
                int excuteRecords = (pageSize * pageNumber) - pageSize;
                var modelList = unit.genericRepositonries<Timing>().GetAll()
                    .Skip(excuteRecords).Take(pageSize).ToList();
                totalCount = unit.genericRepositonries<Timing>().GetAll().ToList().Count();
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            PagedResult<TimmingViewModel> result = new PagedResult<TimmingViewModel>
            {
                Data = vmList,
                TotalItem = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        public IEnumerable<TimmingViewModel> GetAll()
        {
          var model =  unit.genericRepositonries<Timing>().GetAll().ToList();
          var vm = ConvertModelToViewModelList(model);
          return vm;
        }

        public TimmingViewModel getById(int TiimingId)
        {
            var Time = unit.genericRepositonries<Timing>().GetById(TiimingId);
            var vm = new TimmingViewModel(Time);
            return vm;
        }

        public void Insetrt(TimmingViewModel Tiiming)
        {
            var vm = new TimmingViewModel().ConvertViewModel(Tiiming);
            unit.genericRepositonries<Timing>().Add(vm);
            unit.Save();
        }

        public void Update(TimmingViewModel Tiiming)
        {
            var vm = new TimmingViewModel().ConvertViewModel(Tiiming);
            var modelByIDd = unit.genericRepositonries<Timing>().GetById(vm.Id);
            modelByIDd.Id = Tiiming.Id;
            modelByIDd.Status = Tiiming.Status;
            modelByIDd.DooctorId = Tiiming.DooctorId;
            modelByIDd.Duratoin = Tiiming.Duratoin;
            modelByIDd.MornningShiftStrartingTime = Tiiming.MornningShiftStrartingTime;
            modelByIDd.MornningShiftEndingTime = Tiiming.MornningShiftEndingTime;
            modelByIDd.afternoonShiftEndingTime = Tiiming.afternoonShiftEndingTime;
            modelByIDd.afternoonShiftStrartingTime = Tiiming.afternoonShiftStrartingTime;
            unit.genericRepositonries<Timing>().Update(modelByIDd);
            unit.Save();
        }
        private List<TimmingViewModel> ConvertModelToViewModelList(List<Timing> modelList)
        {
            return modelList.Select(x => new TimmingViewModel(x)).ToList();
        }
    }
}
