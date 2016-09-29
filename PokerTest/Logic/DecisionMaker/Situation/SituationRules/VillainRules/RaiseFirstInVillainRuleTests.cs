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
    public class RaiseFirstInVillainRuleTests
    {
        [Test]
        public void Test_Condition_OneRaise_ReturnsTrue()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.CutOff, ActionType.Raise));
            var rule = new RaiseFirstInVillainRule();

            var actual = rule.Condition(list, PositionType.Button);

            Assert.AreEqual(true, actual);
        }

        [Test]
        public void Test_Condition_OneRaiseSomeFold_ReturnsTrue()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.LoJack, ActionType.Fold));
            list.Add(new ActionEvent(PositionType.CutOff, ActionType.Raise));
            var rule = new RaiseFirstInVillainRule();

            var actual = rule.Condition(list, PositionType.Button);

            Assert.AreEqual(true, actual);
        }

        [Test]
        public void Test_Condition_OneRaiseSomeActions_ReturnsTrue()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.LoJack, ActionType.Fold));
            list.Add(new ActionEvent(PositionType.HiJack, ActionType.Limp));
            list.Add(new ActionEvent(PositionType.CutOff, ActionType.Raise));
            var rule = new RaiseFirstInVillainRule();

            var actual = rule.Condition(list, PositionType.Button);

            Assert.AreEqual(true, actual);
        }

        [Test]
        public void Test_Condition_TwoRaises_ReturnsFalse()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.HiJack, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.CutOff, ActionType.Raise));
            var rule = new RaiseFirstInVillainRule();

            var actual = rule.Condition(list, PositionType.HiJack);

            Assert.AreEqual(false, actual);
        }

        [Test]
        public void Test_Condition_ThreeRaises_ReturnsFalse()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.HiJack, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.CutOff, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.Button, ActionType.Raise));
            var rule = new RaiseFirstInVillainRule();

            var actual = rule.Condition(list, PositionType.SmallBlind);

            Assert.AreEqual(false, actual);
        }
    }
}