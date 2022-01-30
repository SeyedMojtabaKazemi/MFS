using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFS.Domain.TransactionAggregate
{
    public class TransactionSearchDto
    {
        public int TransactionId { get; set; }
        public int MerchantId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
