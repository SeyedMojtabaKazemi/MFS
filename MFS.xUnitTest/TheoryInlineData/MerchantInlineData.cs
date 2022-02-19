using MFS.Domain.MerchantAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFS.xUnitTest.TheoryInlineData
{
    public class MerchantInlineData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new MerchantDto
                {
                    Id = 2,
                    FirstName = "Helma",
                    LastName = "Ahmadi",
                    Email = "Helma@yahoo.com",
                    MerchantDiscount = 12,
                    NationalCode = "7777777777",
                    PhoneNo = "777"
                }
            };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
