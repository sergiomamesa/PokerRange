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
            var builder = new StringBuilder();
            Cells.ForEach(c => builder.AppendLine(c.ToString()));

            return builder.ToString();
        }
    }
}
