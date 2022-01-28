using MFS.Domain.MerchantAggregate;

namespace MFS.Contract.MerchantAggregate
{
    public interface IMerchantServiceCommand
    {
        int CreateMerchant(MerchantCreateDto merchant);
        void UpdateMerchant(MerchantDto merchant);
        void RemoveMerchant(int MerchantId);
    }
}
