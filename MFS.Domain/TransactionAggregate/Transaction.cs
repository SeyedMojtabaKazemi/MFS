using MFS.Domain.Common;
using MFS.Domain.MerchantAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFS.Domain.TransactionAggregate
{
    public class Transaction : BaseEntity
    {
        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; }
        public int Price { get; set; }
        public DayOfWeek DayOfWeek { get; set; }


        public static Transaction Create(TransactionCreateDto createDto) => new()
        {
            DayOfWeek = createDto.DayOfWeek ?? DateTime.Now.DayOfWeek,
            MerchantId = createDto.MerchantId,
            Price = createDto.Price
        };
    }
}
