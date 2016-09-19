using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Model
{
    public class Seat
    {
        public Player Player { get; set; }
        public PositionType PositionType { get; set; }
        public ActionType Action { get; set; }

        public Seat(PositionType positionType)
        {
            PositionType = positionType;
            Player = new Player();
        }
    }
}
