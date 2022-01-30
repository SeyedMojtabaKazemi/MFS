using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MFS.Domain.TransactionAggregate;

namespace MFS.Endpoint.WebAPI.Extensions
{
    public class MFSProfile : Profile
    {
        public MFSProfile()
        {
            CreateMap<Transaction, TransactionDto>()
                .ForMember(dest => dest.DayOfWeek,
                            opt => opt.MapFrom(src => src.DayOfWeek))
                .ForMember(dest => dest.MerchantId,
                            opt => opt.MapFrom(src => src.MerchantId))
                .ForMember(dest => dest.Price,
                            opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.MerchantFullName,
                            opt => opt.MapFrom(src => src.Merchant.FirstName + " " + src.Merchant.LastName));


        }
    }
}
