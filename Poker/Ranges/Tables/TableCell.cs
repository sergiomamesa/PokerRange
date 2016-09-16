using Ranges.Enums;
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

        public TableCell(RankType columnRankType, RankType rowRankType, bool isSuited)
        {
            ColumnRankType = columnRankType;
            RowRankType = rowRankType;
            IsSuited = isSuited;
        }
    }
}
