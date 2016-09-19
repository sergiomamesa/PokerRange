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
        private RankType ColumnRankType;
        private RankType RowRankType;
        private bool IsSuited;
        public ActionType Action;

        public TableCell(RankType columnRankType, RankType rowRankType, bool isSuited, ActionType actionType)
        {
            ColumnRankType = columnRankType;
            RowRankType = rowRankType;
            IsSuited = isSuited;
            Action = actionType;
        }
    }
}
