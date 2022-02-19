using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFS.Domain.CommissionAggregate
{
    public class CommissionDto
    {
        public int MerchantId { get; set; }
        public string MerchantFullName { get; set; }
        public int PeriodNo { get; set; }
        public int Year { get; set; }
        public int Amount { get; set; }

    }
}
