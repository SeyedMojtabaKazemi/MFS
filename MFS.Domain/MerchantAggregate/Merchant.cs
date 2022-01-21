using MFS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFS.Domain.MerchantAggregate
{
    public class Merchant : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }



        public static Merchant Create(MerchantCommand merchant) => new()
        {
            Id = merchant.Id,
            FirstName = merchant.FirstName,
            LastName = merchant.LastName,
            Email = merchant.Email,
            PhoneNo = merchant.PhoneNo,
            CreateDate = merchant.CreateDate,
            IsDeleted = false
        };


        public static Merchant Update(MerchantCommand merchant) => new()
        {
            Id = merchant.Id,
            FirstName = merchant.FirstName,
            LastName = merchant.LastName,
            Email = merchant.Email,
            PhoneNo = merchant.PhoneNo,
            CreateDate = merchant.CreateDate,
            ModifyDate = merchant.ModifyDate,
            IsDeleted = merchant.IsDeleted
        };

    }
}
