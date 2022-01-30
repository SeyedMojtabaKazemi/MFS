using MFS.Domain.Common;
using MFS.Domain.MerchantAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFS.Domain.CommissionAggregate
{
    public class Commission : BaseEntity
    {
        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; }
        public int Amount { get; set; }
        public int PeriodNo { get; set; }
        public int Year { get; set; }

        public static Commission Create(CommissionCreateDto createDto) => new()
        {
            Amount = createDto.Amount,
            MerchantId = createDto.MerchantId,
            PeriodNo = createDto.PeriodNo,
            Year = createDto.Year
        };
    }
}