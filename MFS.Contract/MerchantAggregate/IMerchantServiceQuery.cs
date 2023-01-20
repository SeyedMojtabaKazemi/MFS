using MFS.Domain.MerchantAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFS.Contract.MerchantAggregate
{
    public interface IMerchantServiceQuery
    {
        List<Merchant> GetMerchantList(MerchantDto merchant);
        List<Merchant> GetAllMerchantList();
    }
}
