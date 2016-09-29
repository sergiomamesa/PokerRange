using NUnit.Framework;
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
    [Category("FacingRaiseHeroRule")]
    public class FacingRaiseHeroRuleTests
    {
        [Test]
        public void Test_Condition_OneRaise_ReturnsTrue()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.Button, ActionType.Raise));
            var rule = new FacingRaiseHeroRule();

            var actual = rule.Condition(list, PositionType.BigBlind);

            Assert.AreEqual(true, actual);
        }

        [Test]
        public void Test_Condition_SeveralActionsOneRaise_ReturnsTrue()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.Button, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.Button, ActionType.Fold));
            list.Add(new ActionEvent(PositionType.Button, ActionType.Limp));
            var rule = new FacingRaiseHeroRule();

            var actual = rule.Condition(list, PositionType.BigBlind);

            Assert.AreEqual(true, actual);
        }

        [Test]
        public void Test_Condition_TwoRaises_ReturnsFalse()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.Button, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.SmallBlind, ActionType.Raise));
            var rule = new FacingRaiseHeroRule();

            var actual = rule.Condition(list, PositionType.BigBlind);

            Assert.AreEqual(false, actual);
        }

        [Test]
        public void Test_Condition_SeveralActionsTwoRaises_ReturnsFalse()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.HiJack, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.CutOff, ActionType.Fold));
            list.Add(new ActionEvent(PositionType.Button, ActionType.Fold));
            list.Add(new ActionEvent(PositionType.SmallBlind, ActionType.Raise));
            var rule = new FacingRaiseHeroRule();

            var actual = rule.Condition(list, PositionType.BigBlind);

            Assert.AreEqual(false, actual);
        }
    }
}