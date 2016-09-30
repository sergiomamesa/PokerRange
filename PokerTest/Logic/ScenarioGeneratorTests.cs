using System;
using NUnit.Framework;
using Poker.Logic;
using Poker.Model.Enums;

namespace PokerTest.Logic
{
    [TestFixture]
    public class ScenarioGeneratorTests
    {
        [TestCase(0, PositionType.BigBlind)]
        [TestCase(1, PositionType.SmallBlind)]
        [TestCase(2, PositionType.Button)]
        [TestCase(4, PositionType.CutOff)]
        [TestCase(5, PositionType.HiJack)]
        public void Test_RemovePlayer_6MaxRemoveCutOff_ExpectsSpecificSeats(int seatIndex, PositionType position)
        {
            var scenario = new ScenarioGenerator(TableType.SixMax);
            scenario.RemovePlayer(PositionType.CutOff);

            var actual = scenario.Table.Seats[seatIndex].PositionType;

            Assert.AreEqual(position, actual);
        }

        [TestCase(1, PositionType.BigBlind)]
        [TestCase(2, PositionType.SmallBlind)]
        [TestCase(3, PositionType.Button)]
        [TestCase(4, PositionType.CutOff)]
        [TestCase(5, PositionType.HiJack)]
        public void Test_RemovePlayer_6MaxRemoveBigBlind_ExpectsSpecificSeats(int seatIndex, PositionType position)
        {
            var scenario = new ScenarioGenerator(TableType.SixMax);
            scenario.RemovePlayer(PositionType.BigBlind);

            var actual = scenario.Table.Seats[seatIndex].PositionType;

            Assert.AreEqual(position, actual);
        }

        [TestCase(0, PositionType.BigBlind)]
        [TestCase(1, PositionType.SmallBlind)]
        [TestCase(3, PositionType.Button)]
        [TestCase(5, PositionType.CutOff)]
        public void Test_RemovePlayer_6MaxRemoveButtonAndHijack_ExpectsSpecificSeats(int seatIndex, PositionType position)
        {
            var scenario = new ScenarioGenerator(TableType.SixMax);
            scenario.RemovePlayer(PositionType.HiJack);
            scenario.RemovePlayer(PositionType.Button);

            var actual = scenario.Table.Seats[seatIndex].PositionType;

            Assert.AreEqual(position, actual);
        }

        [Test]
        public void Test_RemovePlayer_6MaxRemoveUTG_ExpectsException()
        {
            var scenario = new ScenarioGenerator(TableType.SixMax);
            
            var exception = Assert.Throws<Exception>(() => scenario.RemovePlayer(PositionType.UTG));

            Assert.AreEqual("Not valid seat position for this table.", exception.Message);
        }
    }
}
