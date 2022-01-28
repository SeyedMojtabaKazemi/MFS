using MFS.Contract;
using MFS.Contract.MerchantAggregate;
using MFS.Domain.MerchantAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MFS.Application.Services.Commands.MerchantAggregate
{
    public class MerchantServiceCommand : IMerchantServiceCommand
    {

        private readonly IRepository<Merchant> _MerchantRepository;
        private readonly IRepository<MerchantDiscount> _MerchantDiscountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MerchantServiceCommand(IRepository<Merchant> MerchantRepository,
                                        IRepository<MerchantDiscount> MerchantDiscountRepository,
                                        IUnitOfWork unitOfWork)
        {
            _MerchantRepository = MerchantRepository;
            _MerchantDiscountRepository = MerchantDiscountRepository;
            _unitOfWork = unitOfWork;
        }

        public int CreateMerchant(MerchantCreateDto merchant)
        {
            var MerchantInfo = Merchant.Create(merchant);

            var MerchantEntity = _MerchantRepository.GetExpression(q => q.NationalCode == MerchantInfo.NationalCode).FirstOrDefault();

            if (MerchantEntity != null)
                throw new Exception("National Code Is Exists");

            _MerchantRepository.Insert(MerchantInfo);
            _unitOfWork.SaveChange();

            return MerchantInfo.Id;
        }

        public void RemoveMerchant(int MerchantId)
        {
            var MerchantEntity = _MerchantRepository.GetExpression(q => q.Id == MerchantId).FirstOrDefault();
            var MerchantDiscountEntity = _MerchantDiscountRepository.GetExpression(q => q.MerchantId == MerchantId).FirstOrDefault();

            if (MerchantEntity == null)
                throw new Exception("Merchant Not Exists");

            _MerchantRepository.Remove(MerchantEntity);

            if (MerchantDiscountEntity != null)
                _MerchantDiscountRepository.Remove(MerchantDiscountEntity);

            _unitOfWork.SaveChange();

        }

        public void UpdateMerchant(MerchantDto merchant)
        {
            var MerchantEntity = _MerchantRepository.GetExpression(q => q.Id == merchant.Id, "MerchantDiscount").FirstOrDefault();

            if (MerchantEntity == null)
                throw new Exception("Merchant Not Exists");

            var MerchantInfo = MerchantEntity.Update(merchant);

            _MerchantRepository.Update(MerchantInfo);
            _unitOfWork.SaveChange();
        }
    }
}
