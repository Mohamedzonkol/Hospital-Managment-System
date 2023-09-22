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
    public class RoomServices : IRoomServices
    {
        private readonly IUnitOfWork unit;

        public RoomServices(IUnitOfWork _unit)
        {
            unit = _unit;
        }
        public void Delete(int roomId)
        {
          Room model =  unit.genericRepositonries<Room>().GetById(roomId);
          unit.genericRepositonries<Room>().Delete(model);
          unit.Save();
        }

        public PagedResult<RoomViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new RoomViewModel();
            int totalCount;
            List<RoomViewModel> vmList = new List<RoomViewModel>();
            try
            {
                int excuteRecords = (pageSize * pageNumber) - pageSize;
                var modelList = unit.genericRepositonries<Room>().GetAll(includeProperties: "Hospital")
                 .Skip(excuteRecords).Take(pageSize).ToList();
                totalCount = unit.genericRepositonries<Room>().GetAll().ToList().Count();
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            PagedResult<RoomViewModel> result = new PagedResult<RoomViewModel>
            {
                Data = vmList,
                TotalItem = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }
        public RoomViewModel getRoomById(int id)
        {
            var room = unit.genericRepositonries<Room>().GetById(id);
            var vm = new RoomViewModel(room);
            return vm;

        } 
      
        public void Insetrt(RoomViewModel room)
        {
            var vm =new RoomViewModel().ConvertViewModel(room);
            unit.genericRepositonries<Room>().Add(vm);
            unit.Save();
        }

        public void Update(RoomViewModel room)
        {
            var vm = new RoomViewModel().ConvertViewModel(room);
            var modelByIDd =unit.genericRepositonries<Room>().GetById(vm.Id);
            modelByIDd.RoomNumber = room.RoomNumber;
            modelByIDd.Status= room.Status;
            modelByIDd.Type= room.Type;
            modelByIDd.HospitalId = room.HospitalId;  
            unit.genericRepositonries<Room>().Update(modelByIDd);
            unit.Save();
        }
        private List<RoomViewModel> ConvertModelToViewModelList(List<Room> modelList)
        {
            return modelList.Select(x => new RoomViewModel(x)).ToList();
        }
    }
}
