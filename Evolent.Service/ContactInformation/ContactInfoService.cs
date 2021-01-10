using Evolent.Domain.DataModel;
using Evolent.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.Service.ContactInformation
{
    public class ContactInfoService : IContactInfoService
    {
        private IRepository<ContactInfo> contactInfoRepository;

        public ContactInfoService(IRepository<ContactInfo> _contactInfoRepository)
        {
            this.contactInfoRepository = _contactInfoRepository;
        }
        public async Task<List<ContactInfo>> GetContactInfoList()
        {
            return await contactInfoRepository.FindAllAsync();
        }
        public async Task<long> DeleteContactInfo(long id)
        {
            ContactInfo contactInfo = null;
            try
            {
                if (id > 0)
                {
                    contactInfo = await contactInfoRepository.FindAsync(x => x.Id == id);
                    if (contactInfo != null)
                    {
                        await contactInfoRepository.DeleteAsync(contactInfo);
                    }
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
                return 0;
            }
            return contactInfo.Id;
        }
        public async Task<long> AddOrUpdateContactInfo(ContactInfo info)
        {
            ContactInfo contactInfo = null;
            try
            {
                if (info.Id > 0)
                {
                    contactInfo = await contactInfoRepository.FindAsync(x => x.Id == info.Id);
                    contactInfo.FirstName = info.FirstName;
                    contactInfo.LastName = info.LastName;
                    contactInfo.Email = info.Email;
                    contactInfo.PhoneNumber = info.PhoneNumber;
                    contactInfo.Status = info.Status;

                    contactInfo = await contactInfoRepository.UpdateAsync(contactInfo);
                }
                else
                {
                    contactInfo = await contactInfoRepository.InsertAsync(info);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return 0;
            }
            return contactInfo.Id;
        }

    }
}
