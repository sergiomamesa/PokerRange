using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Model
{
    public class Dealer
    {
        public Table Table { get; set; }
        public Deck Deck { get; set; }

        public Dealer(Table table, Deck deck)
        {
            Table = table;
            Deck = deck;
        }
    }
}
