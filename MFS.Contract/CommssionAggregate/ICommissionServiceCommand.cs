using MFS.Domain.CommissionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFS.Contract.CommssionAggregate
{
    public interface ICommissionServiceCommand
    {
        CommissionDto SubmitMerchantCommission(CommissionDto commissionDto);
    }
}
