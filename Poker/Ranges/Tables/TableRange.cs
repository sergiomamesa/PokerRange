using Poker.Model;
using Poker.Model.Enums;
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

        internal TableRange()
        {
            Cells = new List<TableCell>();
        }

        public ActionType GetAction(Hand hand)
        {
            var currentCell = Cells.FirstOrDefault(c => c.Find(hand));
            return currentCell.Action;
        }

        public override string ToString()
        {
            int iterator = 0;
            var builder = new StringBuilder();
            foreach (RankType columnRank in Enum.GetValues(typeof(RankType)))
            {
                builder.Append(columnRank.ToString());
                builder.Append("|");
                foreach (RankType rowRank in Enum.GetValues(typeof(RankType)))
                {
                    builder.Append(Cells[iterator].ToString());
                    builder.Append("|");
                    iterator++;
                }
                builder.Append(Environment.NewLine);
                builder.Append("------------------------------------------------");
                builder.Append(Environment.NewLine);
            }
            return builder.ToString();
        }
    }
}
