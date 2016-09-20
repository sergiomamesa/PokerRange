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

            if (this.ColumnRankType != leftRank)
                return false;

            if (this.RowRankType != rightRank)
                return false;

            if (this.IsSuited != hand.IsSuited())
                return false;

            return true;
        }
    }
}
