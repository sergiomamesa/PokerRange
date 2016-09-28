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
    [Category("VillainSituationDeciderTests")]
    public class VillainSituationDeciderTests
    {
        [Test]
        public void Test_CalculateSituation_LoJack_NoAction_IsRFI()
        {
            var actionEventList = new List<ActionEvent>();
            var situationDecider = new VillainSituationDecider(actionEventList, PositionType.LoJack);

            var actual = situationDecider.CalculateSituation();

            Assert.AreEqual(SituationType.RaiseFirstIn, actual.Situation);
        }

        [Test]
        public void Test_CalculateSituation_HiJack_Folds_IsRFI()
        {
            var actionEventList = new List<ActionEvent>();
            actionEventList.Add(new ActionEvent(PositionType.LoJack, ActionType.Fold));

            var situationDecider = new VillainSituationDecider(actionEventList, PositionType.HiJack);

            var actual = situationDecider.CalculateSituation();

            Assert.AreEqual(SituationType.RaiseFirstIn, actual.Situation);
        }

        [Test]
        public void Test_CalculateSituation_CutOff_Folds_IsRFI()
        {
            var actionEventList = new List<ActionEvent>();
            actionEventList.Add(new ActionEvent(PositionType.LoJack, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.HiJack, ActionType.Fold));

            var situationDecider = new VillainSituationDecider(actionEventList, PositionType.CutOff);

            var actual = situationDecider.CalculateSituation();

            Assert.AreEqual(SituationType.RaiseFirstIn, actual.Situation);
        }

        [Test]
        public void Test_CalculateSituation_Button_Folds_IsRFI()
        {
            var actionEventList = new List<ActionEvent>();
            actionEventList.Add(new ActionEvent(PositionType.LoJack, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.HiJack, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.CutOff, ActionType.Fold));

            var situationDecider = new VillainSituationDecider(actionEventList, PositionType.Button);

            var actual = situationDecider.CalculateSituation();

            Assert.AreEqual(SituationType.RaiseFirstIn, actual.Situation);
        }

        [Test]
        public void Test_CalculateSituation_SmallBlind_Folds_IsRFI()
        {
            var actionEventList = new List<ActionEvent>();
            actionEventList.Add(new ActionEvent(PositionType.LoJack, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.HiJack, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.CutOff, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.Button, ActionType.Fold));

            var situationDecider = new VillainSituationDecider(actionEventList, PositionType.SmallBlind);

            var actual = situationDecider.CalculateSituation();

            Assert.AreEqual(SituationType.RaiseFirstIn, actual.Situation);
        }

        [Test]
        public void Test_CalculateSituation_HeroLoJackRaise_HiJack3Bet_IsRFIvs3Bet()
        {
            var actionEventList = new List<ActionEvent>();
            actionEventList.Add(new ActionEvent(PositionType.LoJack, ActionType.Raise));
            actionEventList.Add(new ActionEvent(PositionType.HiJack, ActionType.Raise));
            actionEventList.Add(new ActionEvent(PositionType.CutOff, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.Button, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.SmallBlind, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.BigBlind, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.LoJack, ActionType.Raise));
            var situationDecider = new VillainSituationDecider(actionEventList, PositionType.HiJack);

            var actual = situationDecider.CalculateSituation();

            Assert.AreEqual(SituationType.RFIvs3Bet, actual.Situation);
        }

        [Test]
        public void Test_CalculateSituation_HeroSmallBlindRaise_BigBlind3Bet_IsRFIvs3Bet()
        {
            var actionEventList = new List<ActionEvent>();
            actionEventList.Add(new ActionEvent(PositionType.LoJack, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.HiJack, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.CutOff, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.Button, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.SmallBlind, ActionType.Raise));
            actionEventList.Add(new ActionEvent(PositionType.BigBlind, ActionType.Raise));
            actionEventList.Add(new ActionEvent(PositionType.SmallBlind, ActionType.Raise));
            var situationDecider = new VillainSituationDecider(actionEventList, PositionType.BigBlind);

            var actual = situationDecider.CalculateSituation();

            Assert.AreEqual(SituationType.RFIvs3Bet, actual.Situation);
        }

        [Test]
        public void Test_CalculateSituation_HeroCutOffRaise_SmallBlind3Bet_IsRFIvs3Bet()
        {
            var actionEventList = new List<ActionEvent>();
            actionEventList.Add(new ActionEvent(PositionType.LoJack, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.HiJack, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.CutOff, ActionType.Raise));
            actionEventList.Add(new ActionEvent(PositionType.Button, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.SmallBlind, ActionType.Fold));
            actionEventList.Add(new ActionEvent(PositionType.BigBlind, ActionType.Raise));
            actionEventList.Add(new ActionEvent(PositionType.CutOff, ActionType.Raise));
            var situationDecider = new VillainSituationDecider(actionEventList, PositionType.BigBlind);

            var actual = situationDecider.CalculateSituation();

            Assert.AreEqual(SituationType.RFIvs3Bet, actual.Situation);
        }
    }
}
