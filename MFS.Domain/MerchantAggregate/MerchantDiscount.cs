using MFS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFS.Domain.MerchantAggregate
{
    public class MerchantDiscount : BaseEntity
    {
        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; }
        public int DiscountPercent { get; set; }
    }
}