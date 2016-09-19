using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Model
{
    public class Hand
    {
        public Card LeftCard { get; set; }
        public Card RightCard { get; set; }

        public Hand(Card leftCard, Card rightCard)
        {
            LeftCard = leftCard;
            RightCard = rightCard;
        }

        public bool IsSuited()
        {
            if (LeftCard.Suit == RightCard.Suit)
                return true;

            return false;
        }
    }
}
