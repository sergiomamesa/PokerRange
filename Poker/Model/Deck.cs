using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
