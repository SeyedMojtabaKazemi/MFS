using MFS.Domain.MerchantAggregate;
using MFS.Domain.TransactionAggregate;
using MFS.Infrastructure.Persistence;
using MFS.xUnitTest.Initialize;
using MFS.xUnitTest.TheoryInlineData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MFS.xUnitTest
{
    public class CommissionTest : DatabaseTestBase
    {

        private readonly Repository<Transaction> _TransactionRepository;
        private readonly Repository<Merchant> _MerchantRepository;


        public CommissionTest()
        {
            _TransactionRepository = new Repository<Transaction>(context);
            _MerchantRepository = new Repository<Merchant>(context);
        }




        [Theory]
        [ClassData(typeof(CommissionInlineData))]
        public void Calculate_Commission_Of_Merchants(int MerchantId, int PeriodNo, int Year)
        {
            var MerchantTransactions = _TransactionRepository.GetExpression(q => q.MerchantId == MerchantId &&
                                                                    q.CreateDate.Month == PeriodNo &&
                                                                    q.CreateDate.Year == Year &&
                                                                    q.DayOfWeek != DayOfWeek.Saturday &&
                                                                    q.DayOfWeek != DayOfWeek.Sunday).ToList();

            double CommissionPrice = 0;

            Merchant MerchantEntity = null;

            CommissionPrice = MerchantTransactions.Sum(q => q.Price) * 0.01;

            MerchantEntity = _MerchantRepository.GetExpression(q => q.Id == MerchantId).FirstOrDefault();

            if (MerchantEntity.MerchantDiscount.DiscountPercent > 0)
                CommissionPrice -= CommissionPrice * MerchantEntity.MerchantDiscount.DiscountPercent / 100;


            // Over 20 Transactions, 10% Discount
            if (MerchantTransactions.Count > 20)
                CommissionPrice -= CommissionPrice * 0.1;

            Assert.True(CommissionPrice > 0);
        }
    }
}
