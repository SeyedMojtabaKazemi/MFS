using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MFS.Domain.MerchantAggregate;
using MFS.Domain.TransactionAggregate;

namespace MFS.Endpoint.WebAPI.Extensions
{
    public class MFSProfile : Profile
    {
        public MFSProfile()
        {
            CreateMap<Transaction, TransactionDto>()
                .ForMember(dest => dest.MerchantFullName, opt => opt.MapFrom(src => src.Merchant.FirstName + " " + src.Merchant.LastName))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.CreateDate));

            CreateMap<Merchant, MerchantDto>()
                .ForMember(dest => dest.MerchantDiscount, opt => opt.MapFrom(src => src.MerchantDiscount.DiscountPercent));

        }
    }
}
