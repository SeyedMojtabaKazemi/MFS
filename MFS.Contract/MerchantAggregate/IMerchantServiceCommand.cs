using MFS.Domain.MerchantAggregate;

namespace MFS.Contract.MerchantAggregate
{
    public interface IMerchantServiceCommand
    {
        MerchantDto CreateMerchant(MerchantCreateDto merchant);
        MerchantDto UpdateMerchant(MerchantDto merchant);
        MerchantDto RemoveMerchant(int MerchantId);
    }
}
