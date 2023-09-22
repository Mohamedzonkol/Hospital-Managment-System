using Hospital.Utilites;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public interface IContactServiceses
    {
        PagedResult<ContactViewModel> GetAll(int pageNumber,int pageSize);
        ContactViewModel getContactById(int ContactId);
        void Update(ContactViewModel contact);
        void Insetrt(ContactViewModel Ccontact);
        void Delete(int Id);
    }
}
