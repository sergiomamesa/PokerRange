using NUnit.Framework;
using Poker.Logic;
using Poker.Model;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Logic.Tests
{
    [TestFixture]
    public class RFIHeroRuleTests
    {
        [Test]
        public void Test_Condition_EmptyList_ReturnsTrue()
        {
            var list = new List<ActionEvent>();
            var rule = new RFIHeroRule();

            var actual = rule.Condition(list, PositionType.BigBlind);

            Assert.AreEqual(true, actual);
        }

        [Test]
        public void Test_Condition_OnlyFolds_ReturnsTrue()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.Button, ActionType.Fold));
            list.Add(new ActionEvent(PositionType.Button, ActionType.Fold));
            list.Add(new ActionEvent(PositionType.Button, ActionType.Fold));
            var rule = new RFIHeroRule();

            var actual = rule.Condition(list, PositionType.BigBlind);

            Assert.AreEqual(true, actual);
        }

        [Test]
        public void Test_Condition_OneRaise_ReturnsFalse()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.Button, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.SmallBlind, ActionType.Fold));
            var rule = new RFIHeroRule();

            var actual = rule.Condition(list, PositionType.BigBlind);

            Assert.AreEqual(false, actual);
        }

        [Test]
        public void Test_Condition_TwoRaises_ReturnsFalse()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.HiJack, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.CutOff, ActionType.Fold));
            list.Add(new ActionEvent(PositionType.Button, ActionType.Fold));
            list.Add(new ActionEvent(PositionType.SmallBlind, ActionType.Raise));
            var rule = new RFIHeroRule();

            var actual = rule.Condition(list, PositionType.BigBlind);

            Assert.AreEqual(false, actual);
        }
    }
}