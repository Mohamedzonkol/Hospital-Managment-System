using Hospital.Utilites;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public interface IHospitalServices
    {
        PagedResult<HospetalViewModel> GetAll(int pageNumber,int pageSize);
        HospetalViewModel getById(int hospitalId);
        void Update(HospetalViewModel hospital);
        void Insetrt(HospetalViewModel hospital);
        void Delete(int hospitalId);
    }
}
