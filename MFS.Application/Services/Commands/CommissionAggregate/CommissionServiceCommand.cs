using AutoMapper;
using MFS.Contract;
using MFS.Contract.CommssionAggregate;
using MFS.Domain.CommissionAggregate;
using MFS.Domain.MerchantAggregate;
using MFS.Domain.TransactionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFS.Application.Services.Commands.CommissionAggregate
{
    public class CommissionServiceCommand : ICommissionServiceCommand
    {
        private readonly IRepository<Commission> _commissionRepository;
        private readonly IRepository<Transaction> _transactionRepository;
        private readonly IRepository<Merchant> _merchantRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommissionServiceCommand(IRepository<Commission> commissionRepository,
                                        IRepository<Transaction> transactionRepository,
                                        IRepository<Merchant> merchantRepository,
                                        IUnitOfWork unitOfWork,
                                        IMapper mapper)
        {
            _commissionRepository = commissionRepository;
            _transactionRepository = transactionRepository;
            _merchantRepository = merchantRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public CommissionDto SubmitMerchantCommission(CommissionDto commissionDto)
        {
            var DuplicateCommission = _commissionRepository.GetExpression(q => q.MerchantId == commissionDto.MerchantId &&
                                                                             q.PeriodNo == commissionDto.PeriodNo &&
                                                                             q.Year == commissionDto.Year).FirstOrDefault();

            if (DuplicateCommission != null)
                throw new("Commission for this merchant previously defined");


            // Saturday & Sunday don't have any Commission
            var MerchantTransactions = _transactionRepository.GetExpression(q => q.MerchantId == commissionDto.MerchantId &&
                                                                                q.CreateDate.Month == commissionDto.PeriodNo &&
                                                                                q.CreateDate.Year == commissionDto.Year &&
                                                                                q.DayOfWeek != DayOfWeek.Saturday &&
                                                                                q.DayOfWeek != DayOfWeek.Sunday).ToList();

            double CommissionPrice = 0;

            Merchant MerchantEntity = null;

            if (MerchantTransactions != null)
            {

                CommissionPrice = MerchantTransactions.Sum(q => q.Price) * 0.01;

                MerchantEntity = _merchantRepository.GetExpression(q => q.Id == commissionDto.MerchantId).FirstOrDefault();

                if (MerchantEntity.MerchantDiscount.DiscountPercent > 0)
                    CommissionPrice -= CommissionPrice * MerchantEntity.MerchantDiscount.DiscountPercent / 100;


                // Over 20 Transactions, 10% Discount
                if (MerchantTransactions.Count > 20)
                    CommissionPrice -= CommissionPrice * 0.1;
            }

            var com = new CommissionCreateDto
            {
                Year = commissionDto.Year,
                PeriodNo = commissionDto.PeriodNo,
                MerchantId = commissionDto.MerchantId,
                Amount = Convert.ToInt32(CommissionPrice)
            };

            var CommissionEntity = Commission.Create(com);

            var Commissiondto = _mapper.Map<CommissionDto>(CommissionEntity);
            Commissiondto.MerchantFullName = MerchantEntity.FirstName + " " + MerchantEntity.LastName;

            _commissionRepository.Insert(CommissionEntity);
            _unitOfWork.SaveChanges();

            return Commissiondto;
        }
    }
}
