using NUnit.Framework;
using Poker.Logic;
using Poker.Model;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Model.Tests
{
    [TestFixture()]
    public class TableTests
    {
        [TestCase(TableType.FullRing)]
        [TestCase(TableType.SixMax)]
        [TestCase(TableType.HeadsUp)]
        public void Test_TableFactory_CreateInstance_DoesNotThrow(TableType value)
        {
            Assert.DoesNotThrow(() => new TableFactory().CreateInstance(value));
        }

        [TestCase(3)]
        public void Test_TableFactory_CreateInstance_Throws(int value)
        {
            var exception = Assert.Throws<Exception>(() => new TableFactory().CreateInstance((TableType)value));
            Assert.AreEqual(exception.Message, "Invalid table type");
        }

        [TestCase(TableType.FullRing, 9)]
        [TestCase(TableType.SixMax, 6)]
        [TestCase(TableType.HeadsUp, 2)]
        public void Test_TableFactory_CreateInstance_WithProperNumberOfSeats(TableType value, int expected)
        {
            var table = new TableFactory().CreateInstance(value);

            var actual = table.Seats.Count;

            Assert.AreEqual(actual, expected);
        }

    }
}