﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Medallion.OData.Tests
{
    public class NumberHelperTest
    {
        [Test]
        public void TestConvertChecked()
        {
            NumberHelper.CheckedConvert<double>(20L).ShouldEqual(20.0);
            NumberHelper.CheckedConvert<int?>(10M).ShouldEqual(10);
            NumberHelper.CheckedConvert<decimal>(1.3f).ShouldEqual(1.3M);
            NumberHelper.CheckedConvert<int>((long)int.MaxValue).ShouldEqual(int.MaxValue);
            NumberHelper.CheckedConvert<int?>(null).ShouldEqual(null);

            UnitTestHelpers.AssertThrows<InvalidCastException>(() => NumberHelper.CheckedConvert<int>(1.5));
            UnitTestHelpers.AssertThrows<InvalidCastException>(() => NumberHelper.CheckedConvert<int>(1.111111e5f));
            UnitTestHelpers.AssertThrows<InvalidCastException>(() => NumberHelper.CheckedConvert<int>(-.1M));
            UnitTestHelpers.AssertThrows<InvalidCastException>(() => NumberHelper.CheckedConvert<int>(1.5)); 
            UnitTestHelpers.AssertThrows<OverflowException>(() => NumberHelper.CheckedConvert<byte>(-1L));
            UnitTestHelpers.AssertThrows<OverflowException>(() => NumberHelper.CheckedConvert<int?>(2.0 * int.MaxValue));
            UnitTestHelpers.AssertThrows<InvalidCastException>(() => NumberHelper.CheckedConvert<int>(null));
        }
    }
}
