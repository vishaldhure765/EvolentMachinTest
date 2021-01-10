using Evolent.Domain.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.Service.ContactInformation
{
    public interface IContactInfoService
    {
        Task<List<ContactInfo>> GetContactInfoList();
        Task<long> DeleteContactInfo(long id);
        Task<long> AddOrUpdateContactInfo(ContactInfo info);
    }
}
