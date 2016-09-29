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
    [Category("RFIvs3BetHeroRuleTests")]
    public class RFIvs3BetHeroRuleTests
    {
        [Test]
        public void Test_Condition_TwoRaises_ReturnsTrue()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.CutOff, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.Button, ActionType.Raise));
            var rule = new RFIvs3BetHeroRule();

            var actual = rule.Condition(list, PositionType.CutOff);

            Assert.AreEqual(true, actual);
        }

        [Test]
        public void Test_Condition_TwoRaisesSomeActions_ReturnsTrue()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.LoJack, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.HiJack, ActionType.Call));
            list.Add(new ActionEvent(PositionType.Button, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.BigBlind, ActionType.Fold));
            var rule = new RFIvs3BetHeroRule();

            var actual = rule.Condition(list, PositionType.LoJack);

            Assert.AreEqual(true, actual);
        }

        [Test]
        public void Test_Condition_TwoRaisesSomeActionsNoHero_ReturnsFalse()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.LoJack, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.HiJack, ActionType.Call));
            list.Add(new ActionEvent(PositionType.Button, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.BigBlind, ActionType.Fold));
            var rule = new RFIvs3BetHeroRule();

            var actual = rule.Condition(list, PositionType.Button);

            Assert.AreEqual(false, actual);
        }

        [Test]
        public void Test_Condition_TwoRaisesSomeFolds_ReturnsTrue()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.CutOff, ActionType.Fold));
            list.Add(new ActionEvent(PositionType.Button, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.SmallBlind, ActionType.Fold));
            list.Add(new ActionEvent(PositionType.BigBlind, ActionType.Raise));
            var rule = new RFIvs3BetHeroRule();

            var actual = rule.Condition(list, PositionType.Button);

            Assert.AreEqual(true, actual);
        }

        [Test]
        public void Test_Condition_OneRaise_ReturnsFalse()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.CutOff, ActionType.Raise));
            var rule = new RFIvs3BetHeroRule();

            var actual = rule.Condition(list, PositionType.CutOff);

            Assert.AreEqual(false, actual);
        }

        [Test]
        public void Test_Condition_OneRaiseseveralActions_ReturnsFalse()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.LoJack, ActionType.Raise));
            list.Add(new ActionEvent(PositionType.HiJack, ActionType.Call));
            list.Add(new ActionEvent(PositionType.CutOff, ActionType.Fold));
            list.Add(new ActionEvent(PositionType.BigBlind, ActionType.Limp));

            var rule = new RFIvs3BetHeroRule();

            var actual = rule.Condition(list, PositionType.BigBlind);

            Assert.AreEqual(false, actual);
        }

        [Test]
        public void Test_Condition_NoRaiseSeveralFolds_ReturnsFalse()
        {
            var list = new List<ActionEvent>();
            list.Add(new ActionEvent(PositionType.CutOff, ActionType.Fold));
            list.Add(new ActionEvent(PositionType.SmallBlind, ActionType.Fold));
            
            var rule = new RFIvs3BetHeroRule();

            var actual = rule.Condition(list, PositionType.Button);

            Assert.AreEqual(false, actual);
        }
    }
}