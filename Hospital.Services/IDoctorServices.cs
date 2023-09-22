using Hospital.Utilites;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public interface IDoctorServices
    {
        PagedResult<TimmingViewModel> GetAll(int pageNumber, int pageSize);
        IEnumerable<TimmingViewModel> GetAll();
        TimmingViewModel getById(int TiimingId);
        void Update(TimmingViewModel TiimingId);
        void Insetrt(TimmingViewModel Tiiming);
        void Delete(int TiimingId);
    }
}
