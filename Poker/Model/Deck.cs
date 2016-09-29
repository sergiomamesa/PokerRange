using Poker.Model.Enums;
using System;
using System.Collections.Generic;

namespace Poker.Model
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            Cards = new List<Card>();
            foreach (SuitType suit in Enum.GetValues(typeof(SuitType)))
            {
                foreach (RankType rank in Enum.GetValues(typeof(RankType)))
                {
                    Cards.Add(new Card(suit, rank));
                }
            }
        }
    }
}
