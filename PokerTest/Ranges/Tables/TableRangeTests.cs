using NUnit.Framework;
using Poker.Model;
using Poker.Model.Enums;
using Poker.Ranges.Parser;
using Poker.Ranges.Reader;

namespace PokerTest.Ranges
{
    [TestFixture()]
    [Category("TableRangeTests")]
    public class TableRangeTests
    {

        [TestCase(RankType.Two, SuitType.Clubs, RankType.Two, SuitType.Spades)]
        [TestCase(RankType.Ace, SuitType.Clubs, RankType.Jack, SuitType.Spades)]
        [TestCase(RankType.Queen, SuitType.Clubs, RankType.Eight, SuitType.Clubs)]
        [TestCase(RankType.King, SuitType.Clubs, RankType.Two, SuitType.Clubs)]
        [TestCase(RankType.Seven, SuitType.Clubs, RankType.Eight, SuitType.Spades)]
        public void Test_TableRange_GetAction_Specifichand_UTG_RaiseFirstIn_IsFold(RankType leftRank, SuitType leftSuit, RankType rightType, SuitType rightSuit)
        {
            var parameters = new FileReaderFactoryParams() { Situation = SituationType.RaiseFirstIn, HeroPosition = PositionType.UTG };
            var ranges = new FileReaderFactory().CreateInstance(parameters).GetRange(new ActionParser()); ;
            var hand = new Hand(new Card(leftSuit, leftRank), new Card(rightSuit, rightType));

            var actual = ranges.GetAction(hand);

            Assert.AreEqual(ActionType.Fold, actual);
        }

        [TestCase(RankType.Ace, SuitType.Clubs, RankType.Two, SuitType.Clubs)]
        [TestCase(RankType.Ace, SuitType.Clubs, RankType.Three, SuitType.Clubs)]
        [TestCase(RankType.King, SuitType.Spades, RankType.Nine, SuitType.Spades)]
        [TestCase(RankType.Queen, SuitType.Spades, RankType.Nine, SuitType.Spades)]
        [TestCase(RankType.Six, SuitType.Hearts, RankType.Five, SuitType.Hearts)]
        public void Test_TableRange_GetAction_Specifichand_UTG_RaiseFirstIn_IsLimp(RankType leftRank, SuitType leftSuit, RankType rightType, SuitType rightSuit)
        {
            var parameters = new FileReaderFactoryParams() { Situation = SituationType.RaiseFirstIn, HeroPosition = PositionType.UTG };
            var ranges = new FileReaderFactory().CreateInstance(parameters).GetRange(new ActionParser()); ;
            var hand = new Hand(new Card(leftSuit, leftRank), new Card(rightSuit, rightType));

            var actual = ranges.GetAction(hand);

            Assert.AreEqual(ActionType.Limp, actual);
        }

        [TestCase(RankType.Ace, SuitType.Clubs, RankType.Ace, SuitType.Spades)]
        [TestCase(RankType.Queen, SuitType.Clubs, RankType.Jack, SuitType.Clubs)]
        [TestCase(RankType.Ace, SuitType.Spades, RankType.Queen, SuitType.Hearts)]
        [TestCase(RankType.Nine, SuitType.Spades, RankType.Nine, SuitType.Clubs)]
        [TestCase(RankType.Eight, SuitType.Diamonds, RankType.Nine, SuitType.Diamonds)]
        public void Test_TableRange_GetAction_Specifichand_UTG_RaiseFirstIn_IsRaise(RankType leftRank, SuitType leftSuit, RankType rightType, SuitType rightSuit)
        {
            var parameters = new FileReaderFactoryParams() { Situation = SituationType.RaiseFirstIn, HeroPosition = PositionType.UTG };
            var ranges = new FileReaderFactory().CreateInstance(parameters).GetRange(new ActionParser()); ;
            var hand = new Hand(new Card(leftSuit, leftRank), new Card(rightSuit, rightType));

            var actual = ranges.GetAction(hand);

            Assert.AreEqual(ActionType.Raise, actual);
        }

        [TestCase(RankType.Ace, SuitType.Diamonds, RankType.Ace, SuitType.Hearts)]
        [TestCase(RankType.Ace, SuitType.Diamonds, RankType.Queen, SuitType.Diamonds)]
        [TestCase(RankType.Eight, SuitType.Diamonds, RankType.Six, SuitType.Diamonds)]
        [TestCase(RankType.Five, SuitType.Diamonds, RankType.Three, SuitType.Diamonds)]
        [TestCase(RankType.Six, SuitType.Diamonds, RankType.Four, SuitType.Diamonds)]
        public void Test_TableRange_GetAction_Specifichand_BigBlind_FacingRaise_UTGplus2_IsRaise(RankType leftRank, SuitType leftSuit, RankType rightType, SuitType rightSuit)
        {
            var parameters = new FileReaderFactoryParams() { Situation = SituationType.FacingRaise, HeroPosition = PositionType.BigBlind, VillainPosition = PositionType.UTGplus2 };
            var ranges = new FileReaderFactory().CreateInstance(parameters).GetRange(new ActionParser()); ;
            var hand = new Hand(new Card(leftSuit, leftRank), new Card(rightSuit, rightType));

            var actual = ranges.GetAction(hand);

            Assert.AreEqual(ActionType.Raise, actual);
        }

        [TestCase(RankType.Ace, SuitType.Diamonds, RankType.King, SuitType.Hearts)]
        [TestCase(RankType.Queen, SuitType.Diamonds, RankType.King, SuitType.Diamonds)]
        [TestCase(RankType.Ace, SuitType.Diamonds, RankType.Jack, SuitType.Diamonds)]
        [TestCase(RankType.Queen, SuitType.Diamonds, RankType.Queen, SuitType.Spades)]
        [TestCase(RankType.Jack, SuitType.Diamonds, RankType.Jack, SuitType.Spades)]
        public void Test_TableRange_GetAction_Specifichand_BigBlind_FacingRaise_UTGplus2_IsRaiseCall(RankType leftRank, SuitType leftSuit, RankType rightType, SuitType rightSuit)
        {
            var parameters = new FileReaderFactoryParams() { Situation = SituationType.FacingRaise, HeroPosition = PositionType.BigBlind, VillainPosition = PositionType.UTGplus2 };
            var ranges = new FileReaderFactory().CreateInstance(parameters).GetRange(new ActionParser()); ;
            var hand = new Hand(new Card(leftSuit, leftRank), new Card(rightSuit, rightType));

            var actual = ranges.GetAction(hand);

            Assert.AreEqual(ActionType.RaiseOrCall, actual);
        }

        [TestCase(RankType.Queen, SuitType.Diamonds, RankType.Nine, SuitType.Diamonds)]
        [TestCase(RankType.Ace, SuitType.Diamonds, RankType.Jack, SuitType.Hearts)]
        [TestCase(RankType.Jack, SuitType.Diamonds, RankType.Ten, SuitType.Spades)]
        [TestCase(RankType.Seven, SuitType.Diamonds, RankType.Seven, SuitType.Hearts)]
        [TestCase(RankType.Two, SuitType.Diamonds, RankType.Two, SuitType.Hearts)]
        public void Test_TableRange_GetAction_Specifichand_BigBlind_FacingRaise_UTGplus2_IsCall(RankType leftRank, SuitType leftSuit, RankType rightType, SuitType rightSuit)
        {
            var parameters = new FileReaderFactoryParams() { Situation = SituationType.FacingRaise, HeroPosition = PositionType.BigBlind, VillainPosition = PositionType.UTGplus2 };
            var ranges = new FileReaderFactory().CreateInstance(parameters).GetRange(new ActionParser()); ;
            var hand = new Hand(new Card(leftSuit, leftRank), new Card(rightSuit, rightType));

            var actual = ranges.GetAction(hand);

            Assert.AreEqual(ActionType.Call, actual);
        }

        [TestCase(RankType.Seven, SuitType.Diamonds, RankType.Four, SuitType.Diamonds)]
        [TestCase(RankType.Six, SuitType.Spades, RankType.Three, SuitType.Spades)]
        [TestCase(RankType.Four, SuitType.Diamonds, RankType.Two, SuitType.Diamonds)]
        [TestCase(RankType.Three, SuitType.Diamonds, RankType.Two, SuitType.Diamonds)]
        public void Test_TableRange_GetAction_Specifichand_BigBlind_FacingRaise_UTGplus2_IsRaiseFold(RankType leftRank, SuitType leftSuit, RankType rightType, SuitType rightSuit)
        {
            var parameters = new FileReaderFactoryParams() { Situation = SituationType.FacingRaise, HeroPosition = PositionType.BigBlind, VillainPosition = PositionType.UTGplus2 };
            var ranges = new FileReaderFactory().CreateInstance(parameters).GetRange(new ActionParser()); ;
            var hand = new Hand(new Card(leftSuit, leftRank), new Card(rightSuit, rightType));

            var actual = ranges.GetAction(hand);

            Assert.AreEqual(ActionType.RaiseOrFold, actual);
        }

        [TestCase(RankType.King, SuitType.Diamonds, RankType.Two, SuitType.Diamonds)]
        [TestCase(RankType.Nine, SuitType.Diamonds, RankType.Two, SuitType.Diamonds)]
        [TestCase(RankType.Jack, SuitType.Diamonds, RankType.Five, SuitType.Hearts)]
        [TestCase(RankType.Seven, SuitType.Diamonds, RankType.Three, SuitType.Hearts)]
        [TestCase(RankType.Ace, SuitType.Diamonds, RankType.Nine, SuitType.Hearts)]
        public void Test_TableRange_GetAction_Specifichand_BigBlind_FacingRaise_UTGplus2_IsFold(RankType leftRank, SuitType leftSuit, RankType rightType, SuitType rightSuit)
        {
            var parameters = new FileReaderFactoryParams() { Situation = SituationType.FacingRaise, HeroPosition = PositionType.BigBlind, VillainPosition = PositionType.UTGplus2 };
            var ranges = new FileReaderFactory().CreateInstance(parameters).GetRange(new ActionParser()); ;
            var hand = new Hand(new Card(leftSuit, leftRank), new Card(rightSuit, rightType));

            var actual = ranges.GetAction(hand);

            Assert.AreEqual(ActionType.Fold, actual);
        }


        [TestCase(RankType.Ace, SuitType.Diamonds, RankType.Ace, SuitType.Hearts)]
        [TestCase(RankType.Ace, SuitType.Diamonds, RankType.King, SuitType.Diamonds)]
        [TestCase(RankType.Ace, SuitType.Diamonds, RankType.Five, SuitType.Diamonds)]
        [TestCase(RankType.Queen, SuitType.Diamonds, RankType.Queen, SuitType.Hearts)]
        [TestCase(RankType.Ace, SuitType.Diamonds, RankType.King, SuitType.Hearts)]
        public void Test_TableRange_GetAction_Specifichand_LoJack_RFIvs3Bet_HiJack_IsRaise(RankType leftRank, SuitType leftSuit, RankType rightType, SuitType rightSuit)
        {
            var parameters = new FileReaderFactoryParams() { Situation = SituationType.RFIvs3Bet, HeroPosition = PositionType.HiJack, VillainPosition = PositionType.LoJack };
            var ranges = new FileReaderFactory().CreateInstance(parameters).GetRange(new ActionParser()); ;
            var hand = new Hand(new Card(leftSuit, leftRank), new Card(rightSuit, rightType));

            var actual = ranges.GetAction(hand);

            Assert.AreEqual(ActionType.Raise, actual);
        }

        [TestCase(RankType.Jack, SuitType.Diamonds, RankType.Jack, SuitType.Hearts)]
        public void Test_TableRange_GetAction_Specifichand_LoJack_RFIvs3Bet_HiJack_IsRaiseCall(RankType leftRank, SuitType leftSuit, RankType rightType, SuitType rightSuit)
        {
            var parameters = new FileReaderFactoryParams() { Situation = SituationType.RFIvs3Bet, HeroPosition = PositionType.HiJack, VillainPosition = PositionType.LoJack };
            var ranges = new FileReaderFactory().CreateInstance(parameters).GetRange(new ActionParser()); ;
            var hand = new Hand(new Card(leftSuit, leftRank), new Card(rightSuit, rightType));

            var actual = ranges.GetAction(hand);

            Assert.AreEqual(ActionType.RaiseOrCall, actual);
        }

        [TestCase(RankType.Ten, SuitType.Diamonds, RankType.Ten, SuitType.Hearts)]
        [TestCase(RankType.Seven, SuitType.Diamonds, RankType.Seven, SuitType.Hearts)]
        [TestCase(RankType.Ace, SuitType.Diamonds, RankType.Ten, SuitType.Diamonds)]
        [TestCase(RankType.Nine, SuitType.Diamonds, RankType.Eight, SuitType.Diamonds)]
        [TestCase(RankType.Jack, SuitType.Diamonds, RankType.Ten, SuitType.Diamonds)]
        public void Test_TableRange_GetAction_Specifichand_LoJack_RFIvs3Bet_HiJack_IsCall(RankType leftRank, SuitType leftSuit, RankType rightType, SuitType rightSuit)
        {
            var parameters = new FileReaderFactoryParams() { Situation = SituationType.RFIvs3Bet, HeroPosition = PositionType.HiJack, VillainPosition = PositionType.LoJack };
            var ranges = new FileReaderFactory().CreateInstance(parameters).GetRange(new ActionParser()); ;
            var hand = new Hand(new Card(leftSuit, leftRank), new Card(rightSuit, rightType));

            var actual = ranges.GetAction(hand);

            Assert.AreEqual(ActionType.Call, actual);
        }

        [TestCase(RankType.Ace, SuitType.Diamonds, RankType.Jack, SuitType.Hearts)]
        [TestCase(RankType.Ace, SuitType.Diamonds, RankType.Nine, SuitType.Diamonds)]
        public void Test_TableRange_GetAction_Specifichand_LoJack_RFIvs3Bet_HiJack_IsRaiseFold(RankType leftRank, SuitType leftSuit, RankType rightType, SuitType rightSuit)
        {
            var parameters = new FileReaderFactoryParams() { Situation = SituationType.RFIvs3Bet, HeroPosition = PositionType.HiJack, VillainPosition = PositionType.LoJack };
            var ranges = new FileReaderFactory().CreateInstance(parameters).GetRange(new ActionParser()); ;
            var hand = new Hand(new Card(leftSuit, leftRank), new Card(rightSuit, rightType));

            var actual = ranges.GetAction(hand);

            Assert.AreEqual(ActionType.RaiseOrFold, actual);
        }

        [TestCase(RankType.King, SuitType.Diamonds, RankType.Ten, SuitType.Diamonds)]
        [TestCase(RankType.Queen, SuitType.Diamonds, RankType.Ten, SuitType.Diamonds)]
        public void Test_TableRange_GetAction_Specifichand_LoJack_RFIvs3Bet_HiJack_IsCallFold(RankType leftRank, SuitType leftSuit, RankType rightType, SuitType rightSuit)
        {
            var parameters = new FileReaderFactoryParams() { Situation = SituationType.RFIvs3Bet, HeroPosition = PositionType.HiJack, VillainPosition = PositionType.LoJack };
            var ranges = new FileReaderFactory().CreateInstance(parameters).GetRange(new ActionParser()); ;
            var hand = new Hand(new Card(leftSuit, leftRank), new Card(rightSuit, rightType));

            var actual = ranges.GetAction(hand);

            Assert.AreEqual(ActionType.CallOrFold, actual);
        }

        [TestCase(RankType.Ace, SuitType.Diamonds, RankType.Seven, SuitType.Diamonds)]
        [TestCase(RankType.Queen, SuitType.Diamonds, RankType.Nine, SuitType.Diamonds)]
        [TestCase(RankType.King, SuitType.Diamonds, RankType.Ten, SuitType.Hearts)]
        [TestCase(RankType.King, SuitType.Diamonds, RankType.Queen, SuitType.Hearts)]
        [TestCase(RankType.Ten, SuitType.Diamonds, RankType.Nine, SuitType.Hearts)]
        public void Test_TableRange_GetAction_Specifichand_LoJack_RFIvs3Bet_HiJack_IsFold(RankType leftRank, SuitType leftSuit, RankType rightType, SuitType rightSuit)
        {
            var parameters = new FileReaderFactoryParams() { Situation = SituationType.RFIvs3Bet, HeroPosition = PositionType.HiJack, VillainPosition = PositionType.LoJack };
            var ranges = new FileReaderFactory().CreateInstance(parameters).GetRange(new ActionParser()); ;
            var hand = new Hand(new Card(leftSuit, leftRank), new Card(rightSuit, rightType));

            var actual = ranges.GetAction(hand);

            Assert.AreEqual(ActionType.Fold, actual);
        }
    }
}