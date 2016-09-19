using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Model
{
    public class Table
    {
        internal int SeatsNumber;
        internal List<Seat> Seats;
        internal Board Board;

        public Table(int seatsNumber)
        {
            SeatsNumber = seatsNumber;

            Seats = new List<Seat>();
            for (int i = 0; i < SeatsNumber; i++)
            {
                Seats.Add(new Seat((PositionType)i));
            }
        }
    }
}
