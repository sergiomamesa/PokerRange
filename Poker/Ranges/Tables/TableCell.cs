using Poker.Model;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranges
{
    public class TableCell
    {
        public RankType ColumnRankType;
        public RankType RowRankType;
        public bool IsSuited;
        public ActionType Action;

        public TableCell(RankType columnRankType, RankType rowRankType, bool isSuited, ActionType actionType)
        {
            ColumnRankType = columnRankType;
            RowRankType = rowRankType;
            IsSuited = isSuited;
            Action = actionType;
        }

        public bool Find(Hand hand)
        {
            var leftRank = hand.LeftCard.Rank;
            var rightRank = hand.RightCard.Rank;
            
            var found = MatchColumnRow(rightRank, leftRank);
            if (!found)
                found = MatchColumnRow(leftRank, rightRank);

            if (!found)
                found = false;

            if (IsSuited != hand.IsSuited())
                found = false;

            return found;
        }

        public bool MatchColumnRow(RankType columnRank, RankType rowRank)
        {
            var result = true;

            if (ColumnRankType != columnRank)
                result = false;

            if (RowRankType != rowRank)
                result = false;

            return result;
        }

        public override string ToString()
        {
            return Action.ToString();
            //return String.Format("{0} {1} {2} {3}", ColumnRankType, RowRankType, IsSuited, Action);
        }
    }
}
