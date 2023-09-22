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
    public class ApleacationUserServices : IAppllecationUserServices
    {
        private readonly IUnitOfWork unit;

        public ApleacationUserServices(IUnitOfWork _unit)
        {
            unit = _unit;
        }
        public PagedResult<ApplecationUserViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new ApplecationUserViewModel();
            int totalCount;
            List<ApplecationUserViewModel> vmList = new List<ApplecationUserViewModel>();
            try
            {
                int excuteRecords = (pageSize * pageNumber) - pageSize;
                var modelList = unit.genericRepositonries < ApplecationUser>().GetAll()
                    .Skip(excuteRecords).Take(pageSize).ToList();
                totalCount = unit.genericRepositonries<ApplecationUser>().GetAll().ToList().Count();
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            PagedResult < ApplecationUserViewModel> result = new PagedResult<ApplecationUserViewModel>
            {
                Data = vmList,
                TotalItem = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        public PagedResult<ApplecationUserViewModel> GetAllDoctor(int pageNumber, int pageSize)
        {
            var vm = new ApplecationUserViewModel();
            int totalCount;
            List<ApplecationUserViewModel> vmList = new List<ApplecationUserViewModel>();
            try
            {
                int excuteRecords = (pageSize * pageNumber) - pageSize;
                var modelList = unit.genericRepositonries<ApplecationUser>().GetAll(x=>x.IsDoctor==true)
                    .Skip(excuteRecords).Take(pageSize).ToList();
                totalCount = unit.genericRepositonries<ApplecationUser>().GetAll(x => x.IsDoctor == true).ToList().Count();
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            PagedResult<ApplecationUserViewModel> result = new PagedResult<ApplecationUserViewModel>
            {
                Data = vmList,
                TotalItem = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        public PagedResult<ApplecationUserViewModel> GetAllPatiant(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public PagedResult<ApplecationUserViewModel> Search(int pageNumber, int pageSize, string spicitly = null)
        {
            throw new NotImplementedException();
        }
        private List<ApplecationUserViewModel> ConvertModelToViewModelList(List<ApplecationUser> modelList)
        {
            return modelList.Select(x => new ApplecationUserViewModel(x)).ToList();
        }
    }
}
