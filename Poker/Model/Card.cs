using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Model
{
    public class Card
    {
        public SuitType Suit { get; set; }
        public RankType Rank { get; set; }

        public Card(SuitType suit, RankType rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }
}
