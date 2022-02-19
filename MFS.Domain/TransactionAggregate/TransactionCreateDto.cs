using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFS.Domain.TransactionAggregate
{
    public class TransactionCreateDto
    {
        public int MerchantId { get; set; }
        public int Price { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
    }
}