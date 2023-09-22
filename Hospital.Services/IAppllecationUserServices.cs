using Hospital.Utilites;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public  interface IAppllecationUserServices
    {
        PagedResult<ApplecationUserViewModel> GetAll(int pageNumber, int pageSize);
        PagedResult<ApplecationUserViewModel> GetAllDoctor(int pageNumber, int pageSize);
        PagedResult<ApplecationUserViewModel> GetAllPatiant(int pageNumber, int pageSize);
        PagedResult<ApplecationUserViewModel> Search(int pageNumber, int pageSize,string spicitly=null);
   
    }
}
