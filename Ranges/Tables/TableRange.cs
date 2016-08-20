using Ranges.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranges
{
    public class TableRange
    {
        public List<TableCell> Cells;

        public TableRange()
        {
            Cells = new List<TableCell>();
        }

        public static TableRange Empty()
        {
            var tableRange = new TableRange();

            var rowIterator = 1;
            foreach (RankType rowRank in Enum.GetValues(typeof(RankType)))
            {
                var columnIterator = 0;
                foreach (RankType columnRank in Enum.GetValues(typeof(RankType)))
                {
                    var isSuited = columnIterator >= rowIterator;
                    tableRange.Cells.Add(new TableCell(columnRank, rowRank, isSuited));
                    columnIterator++;
                }
                rowIterator++;
            }

            return tableRange;
        }
    }
}
