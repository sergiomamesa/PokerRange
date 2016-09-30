using NUnit.Framework;
using Poker.Model;
using Poker.Model.Enums;
using System.Collections.Generic;

namespace Poker.Logic.Tests
{
    [TestFixture]
    public class RFIvs3BetVillainRuleTests
    {
        [Test]
        public void Test_Condition_ThreeRaises_ReturnsTrue()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.CutOff, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.BigBlind, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.CutOff, ActionType.Raise));
            var rule = new RFIvs3BetVillainRule();

            var actual = rule.Condition(list, PositionType.BigBlind);

            Assert.AreEqual(true, actual);
        }

        [Test]
        public void Test_Condition_ThreeRaisesSomeFolds_ReturnsTrue()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.HiJack, ActionType.Fold));
            list.Add(new ActionEvent(PositionType.CutOff, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.BigBlind, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.SmallBlind, ActionType.Fold));
            list.Add(new ActionEvent(PositionType.CutOff, ActionType.Raise));
            var rule = new RFIvs3BetVillainRule();

            var actual = rule.Condition(list, PositionType.BigBlind);

            Assert.AreEqual(true, actual);
        }

        [Test]
        public void Test_Condition_ThreeRaisesSomeActions_ReturnsTrue()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.HiJack, ActionType.Limp));
            list.Add(new ActionEvent(PositionType.CutOff, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.BigBlind, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.SmallBlind, ActionType.Fold));
            list.Add(new ActionEvent(PositionType.CutOff, ActionType.Raise));
            var rule = new RFIvs3BetVillainRule();

            var actual = rule.Condition(list, PositionType.BigBlind);

            Assert.AreEqual(true, actual);
        }

        [Test]
        public void Test_Condition_TwoRaises_ReturnsFalse()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.CutOff, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.BigBlind, ActionType.Raise));
            var rule = new RFIvs3BetVillainRule();

            var actual = rule.Condition(list, PositionType.BigBlind);

            Assert.AreEqual(false, actual);
        }

        [Test]
        public void Test_Condition_ThreeRaisesNoHero_ReturnsFalse()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.CutOff, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.BigBlind, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.CutOff, ActionType.Raise));
            var rule = new RFIvs3BetVillainRule();

            var actual = rule.Condition(list, PositionType.CutOff);

            Assert.AreEqual(false, actual);
        }
    }
}