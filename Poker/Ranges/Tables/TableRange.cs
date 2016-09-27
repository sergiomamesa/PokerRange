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
<<<<<<< HEAD
            var leftRank = hand.LeftCard.Rank;
            var rightRank = hand.RightCard.Rank;

            //TODO: Refactor this too long line TIP IEqulityComparer 
            var currentCell = Cells.FirstOrDefault(c => c.ColumnRankType == leftRank && c.RowRankType == rightRank && c.IsSuited == hand.IsSuited());
=======
            var currentCell = Cells.FirstOrDefault(c => c.Find(hand));
>>>>>>> 77fa90502a710b8e7f15928672c62a61d6d9cf47
            return currentCell.Action;
        }
    }
}
