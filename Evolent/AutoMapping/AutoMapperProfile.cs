using AutoMapper;
using Evolent.Domain.DataModel;
using Evolent.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evolent.AutoMapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ContactInfoViewModel, ContactInfo>();
            CreateMap<ContactInfo, ContactInfoViewModel>();
        }
    }
}
