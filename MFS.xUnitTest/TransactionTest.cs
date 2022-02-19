using MFS.Domain.MerchantAggregate;
using MFS.Domain.TransactionAggregate;
using MFS.Infrastructure.Persistence;
using MFS.xUnitTest.Initialize;
using System;
using System.Collections.Generic;
using Xunit;

namespace MFS.xUnitTest
{
    public class TransactionTest : DatabaseTestBase
    {
        private readonly Repository<Transaction> _TransactionRepository;
        private readonly Repository<Merchant> _MerchantRepository;


        public TransactionTest()
        {
            _MerchantRepository = new Repository<Merchant>(context);
            _TransactionRepository = new Repository<Transaction>(context);
        }

        [Theory]
        [InlineData(3)]
        public void Add_New_Transaction_For_Merchant(int MerchantId)
        {
            var merchant = _MerchantRepository.GetExpression(q => q.Id == MerchantId);

            var transaction = Transaction.Create(new TransactionCreateDto
            {
                MerchantId = MerchantId,
                Price = 250
            });

            var result = _TransactionRepository.Insert(transaction);
            unitOfWork.SaveChanges();

            Assert.IsType<Transaction>(result);
            Assert.True(result.Id > 0);
        }

        [Fact]
        public void Transaction_Should_Available()
        {
            var transaction = _TransactionRepository.GetExpression(q => q.DayOfWeek == DateTime.Now.DayOfWeek);

            Assert.NotNull(transaction);

            using (IEnumerator<Transaction> iterator = transaction.GetEnumerator())
            {
                Assert.True(iterator.MoveNext());
            }
        }

        [Theory]
        [InlineData(1)]
        public void Transaction_Remove(int TransactionId)
        {
            var transaction = _TransactionRepository.GetExpression(q => q.Id == TransactionId);

            using (IEnumerator<Transaction> iterator = transaction.GetEnumerator())
            {

                Assert.True(iterator.MoveNext());

                var result = _TransactionRepository.Remove(iterator.Current);
                unitOfWork.SaveChanges();

                Assert.IsType<Transaction>(result);
                Assert.True(result.IsDeleted);
            }
        }
    }
}
