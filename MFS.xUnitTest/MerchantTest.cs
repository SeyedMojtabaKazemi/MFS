using MFS.Domain.MerchantAggregate;
using MFS.Infrastructure.Persistence;
using MFS.xUnitTest.Initialize;
using MFS.xUnitTest.TheoryInlineData;
using System.Collections.Generic;
using Xunit;

namespace MFS.xUnitTest
{
    public class MerchantTest : DatabaseTestBase
    {
        private readonly Repository<Merchant> _MerchantRepository;

        public MerchantTest()
        {
            _MerchantRepository = new Repository<Merchant>(context);
        }



        [Fact]
        public void Add_New_Merchant()
        {
            var merchant = Merchant.Create(new MerchantCreateDto
            {
                FirstName = "Ahmad",
                LastName = "Abbasi",
                Email = "Ahmad@yahoo.com",
                MerchantDiscount = 5,
                NationalCode = "0000000000",
                PhoneNo = "000"
            });

            var result = _MerchantRepository.Insert(merchant);
            unitOfWork.SaveChanges();

            Assert.IsType<Merchant>(result);
            Assert.True(result.Id > 0);
        }


        [Theory]
        [ClassData(typeof(MerchantInlineData))]
        public void Update_Merchant(MerchantDto merchantDto)
        {
            //var merchantdto = new MerchantDto
            //{
            //    Id = merchantId,
            //    FirstName = "Helma",
            //    LastName = "Ahmadi",
            //    Email = "Helma@yahoo.com",
            //    MerchantDiscount = 12,
            //    NationalCode = "7777777777",
            //    PhoneNo = "777"
            //};

            var merchant = _MerchantRepository.GetExpression(q => q.Id == merchantDto.Id);

            using (IEnumerator<Merchant> iterator = merchant.GetEnumerator())
            {

                Assert.True(iterator.MoveNext());

                var result = iterator.Current.Update(merchantDto);
                unitOfWork.SaveChanges();

                Assert.NotNull(result);
                Assert.IsType<Merchant>(result);
            }


        }

        [Theory]
        [InlineData("1111111111")]
        public void Merchant_Should_Available(string NationalCode)
        {
            var merchant = _MerchantRepository.GetExpression(q => q.NationalCode == NationalCode);

            Assert.NotNull(merchant);
        }

        [Theory]
        [InlineData(3)]
        public void Merchant_Remove(int MerchantId)
        {
            var merchant = _MerchantRepository.GetExpression(q => q.Id == MerchantId);

            using (IEnumerator<Merchant> iterator = merchant.GetEnumerator())
            {

                Assert.True(iterator.MoveNext());

                var result = _MerchantRepository.Remove(iterator.Current);
                unitOfWork.SaveChanges();

                Assert.IsType<Merchant>(result);
                Assert.True(result.IsDeleted);
            }
        }
    }
}
