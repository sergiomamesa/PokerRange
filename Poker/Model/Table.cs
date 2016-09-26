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
        public List<Seat> Seats;

        public Table(int seatsNumber)
        {
            Seats = new List<Seat>();
            for (int i = 0; i < seatsNumber; i++)
            {
                Seats.Add(new Seat((PositionType)i));
            }
        }
    }
}
