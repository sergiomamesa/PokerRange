using NUnit.Framework;
using Poker.Logic;
using Poker.Model.Enums;
using System;

namespace PokerTest.Model
{
    [TestFixture()]
    [Category("TableTests")]
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