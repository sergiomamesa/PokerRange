using NUnit.Framework;
using Poker.Model;
using Poker.Model.Enums;
using Poker.Ranges.Parser;
using Poker.Ranges.Reader;
using Ranges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranges.Tests
{
    [TestFixture()]
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
    }
}