using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Model
{
    public class ActionEvent
    {
        public PositionType Position;
        public ActionType Action;

        public ActionEvent(PositionType position, ActionType action)
        {
            Position = position;
            Action = action;
        }
    }
}
