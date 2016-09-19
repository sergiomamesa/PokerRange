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
                //TODO: SeatPosition will depend on SeatsNumber
                //For a 6-max table seats will be: BB, SB, Dealer, Cut-off, Hi-Jack
                Seats.Add(new Seat((PositionType)i));
            }
        }
    }
}
