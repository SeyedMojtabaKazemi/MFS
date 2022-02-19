using System;
using System.Collections.Generic;

namespace MFS.xUnitTest.TheoryInlineData
{
    public class CommissionInlineData : IEnumerable<object[]>
    {

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, DateTime.Now.Month, DateTime.Now.Year };
            yield return new object[] { 2, DateTime.Now.Month, DateTime.Now.Year };
            yield return new object[] { 3, DateTime.Now.Month, DateTime.Now.Year };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
