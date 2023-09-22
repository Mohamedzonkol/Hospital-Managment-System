using Hospital.Utilites;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public interface IRoomServices
    {
        PagedResult<RoomViewModel> GetAll(int pageNumber,int pageSize);
        RoomViewModel getRoomById(int roomId);
        void Update(RoomViewModel room);
        void Insetrt(RoomViewModel room);
        void Delete(int roomId);
    }
}
