using Ranges.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranges.Reader
{
    public class FileTableCell
    {
        private RankType ColumnRankType;
        private RankType RowRankType;
        private string Value;

        public FileTableCell(RankType columnRankType, RankType rowRankType, string value)
        {
            ColumnRankType = columnRankType;
            RowRankType = rowRankType;
            Value = value;
        }
    }
}
