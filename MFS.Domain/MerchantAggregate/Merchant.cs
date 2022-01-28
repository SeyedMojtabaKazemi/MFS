﻿using MFS.Domain.Common;
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
        public string NationalCode { get; set; }
        public MerchantDiscount MerchantDiscount { get; set; }


        public static Merchant Create(MerchantCreateDto merchant) => new()
        {
            FirstName = merchant.FirstName,
            LastName = merchant.LastName,
            Email = merchant.Email,
            PhoneNo = merchant.PhoneNo,
            NationalCode = merchant.NationalCode,
            IsDeleted = false,
            MerchantDiscount = new MerchantDiscount
            {
                DiscountPercent = merchant.MerchantDiscount
            }
        };


        public Merchant Update(MerchantDto merchant)
        {
            FirstName = merchant.FirstName;
            LastName = merchant.LastName;
            Email = merchant.Email;
            PhoneNo = merchant.PhoneNo;
            NationalCode = merchant.NationalCode;
            MerchantDiscount.DiscountPercent = merchant.MerchantDiscount;

            return this;
        }
    }
}
