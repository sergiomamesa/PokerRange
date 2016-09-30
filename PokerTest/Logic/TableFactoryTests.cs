using NUnit.Framework;
using Poker.Logic;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Logic.Tests
{
    [TestFixture]
    public class TableFactoryTests
    {
        [Test]
        public void Test_CreateInstance_SixMax_Has6Seats()
        {
            var factory = new TableFactory();

            var actual = factory.CreateInstance(TableType.SixMax).Seats;

            Assert.AreEqual(6, actual.Count);
        }

        [Test]
        public void Test_CreateInstance_FullRing_Has9Seats()
        {
            var factory = new TableFactory();

            var actual = factory.CreateInstance(TableType.FullRing).Seats;

            Assert.AreEqual(9, actual.Count);
        }

        [Test]
        public void Test_CreateInstance_HeadsUp_Has2Seats()
        {
            var factory = new TableFactory();

            var actual = factory.CreateInstance(TableType.HeadsUp).Seats;

            Assert.AreEqual(2, actual.Count);
        }
    }
}