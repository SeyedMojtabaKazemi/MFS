﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFS.Domain.MerchantAggregate
{
    public class MerchantCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string NationalCode { get; set; }
        public int MerchantDiscount { get; set; }
    }
}
