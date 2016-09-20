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
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void Test_TableFactory_CreateInstance_DoesNotThrow(int value)
        {
            Assert.DoesNotThrow(() => new TableFactory().CreateInstance((TableType)value));
        }

        [TestCase(3)]
        public void Test_TableFactory_CreateInstance_Throws(int value)
        {
            var exception =  Assert.Throws<Exception>(() => new TableFactory().CreateInstance((TableType)value));
            Assert.AreEqual(exception.Message, "Invalid table type");
        }

        [TestCase(0, 9)]
        [TestCase(1, 6)]
        [TestCase(2, 2)]
        public void Test_TableFactory_CreateInstance_WithProperNumberOfSeats(int value, int expected)
        {
            var table = new TableFactory().CreateInstance((TableType)value);

            var actual = table.Seats.Count;

            Assert.AreEqual(actual, expected);
        }

    }
}