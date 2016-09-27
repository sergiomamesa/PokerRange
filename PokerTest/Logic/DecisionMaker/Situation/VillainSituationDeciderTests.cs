using NUnit.Framework;
using Poker.Logic;
using Poker.Model;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTest.Logic.DecisionMaker.Situation
{
    [TestFixture]
    [Category("SituationDeciderTests")]
    public class VillainSituationDeciderTests
    {
        [Test]
        public void Test_CalculateSituation_LoJack_RaiseVillain_IsRFI()
        {
            var actionEventList = new List<ActionEvent>();
            actionEventList.Add(new ActionEvent(PositionType.UTG, ActionType.Raise));
            var situationDecider = new VillainSituationDecider(actionEventList, PositionType.LoJack);

            var actual = situationDecider.CalculateSituation();

            Assert.AreEqual(SituationType.RaiseFirstIn, actual);
        }

        [Test]
        public void Test_CalculateSituation_Button_FoldRaiseVillain_IsRFI()
        {
            var actionEventList = new List<ActionEvent>();
            actionEventList.Add(new ActionEvent(PositionType.UTG, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.UTGplus1, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.UTGplus2, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.LoJack, ActionType.Raise));
            var situationDecider = new VillainSituationDecider(actionEventList, PositionType.Button);

            var actual = situationDecider.CalculateSituation();

            Assert.AreEqual(SituationType.RaiseFirstIn, actual);
        }

        [Test]
        public void Test_CalculateSituation_Button_FoldRaiseVillainFold_IsRFI()
        {
            var actionEventList = new List<ActionEvent>();
            actionEventList.Add(new ActionEvent(PositionType.UTG, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.UTGplus1, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.UTGplus2, ActionType.Raise));
            actionEventList.Add(new ActionEvent(PositionType.LoJack, ActionType.Fold));
            var situationDecider = new VillainSituationDecider(actionEventList, PositionType.Button);

            var actual = situationDecider.CalculateSituation();

            Assert.AreEqual(SituationType.RaiseFirstIn, actual);
        }
    }
}
