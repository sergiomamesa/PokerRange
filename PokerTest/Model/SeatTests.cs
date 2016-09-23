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
    [Category("SeatTests")]
    public class SeatTests
    {
        [TestCase(TableType.FullRing)]
        [TestCase(TableType.SixMax)]
        [TestCase(TableType.HeadsUp)]
        public void Test_Seats_NewTable_HasNoEmptySeats(TableType value)
        {
            var table = new TableFactory().CreateInstance(value);

            var actual = table.Seats.Any(s => s == null);

            Assert.AreEqual(false, actual);
        }

        [TestCase(0, PositionType.BigBlind)]
        [TestCase(1, PositionType.SmallBlind)]
        [TestCase(2, PositionType.Button)]
        [TestCase(3, PositionType.CutOff)]
        [TestCase(4, PositionType.HiJack)]
        [TestCase(5, PositionType.LoJack)]
        [TestCase(6, PositionType.UTGplus2)]
        [TestCase(7, PositionType.UTGplus1)]
        [TestCase(8, PositionType.UTG)]
        public void Test_Seats_NewTableFullRing_SeatsAreInAProperPosition(int index, PositionType expected)
        {
            var table = new TableFactory().CreateInstance(TableType.FullRing);

            var actual = table.Seats[index].PositionType;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, PositionType.BigBlind)]
        [TestCase(1, PositionType.SmallBlind)]
        [TestCase(2, PositionType.Button)]
        [TestCase(3, PositionType.CutOff)]
        [TestCase(4, PositionType.HiJack)]
        [TestCase(5, PositionType.LoJack)]
        public void Test_Seats_NewTable6Max_SeatsAreInAProperPosition(int index, PositionType expected)
        {
            var table = new TableFactory().CreateInstance(TableType.SixMax);

            var actual = table.Seats[index].PositionType;

            Assert.AreEqual(expected, actual);
        }


        [TestCase(0, PositionType.BigBlind)]
        [TestCase(1, PositionType.SmallBlind)]
        public void Test_Seats_NewTableHeadsUp_SeatsAreInAProperPosition(int index, PositionType expected)
        {
            var table = new TableFactory().CreateInstance(TableType.HeadsUp);

            var actual = table.Seats[index].PositionType;

            Assert.AreEqual(expected, actual);
        }
    }
}