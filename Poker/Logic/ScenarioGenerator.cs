using Poker.Model;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Logic
{
    public class ScenarioGenerator
    {
        public Dealer Dealer { get; set; }

        public ScenarioGenerator(TableType type)
        {
            var table = new TableFactory().CreateInstance(type);
            var deck = new Deck();

            Dealer = new Dealer(table, deck);
        }

        public void SetHeroPosition(PositionType position)
        {
            var seat = Dealer.Table.Seats.FirstOrDefault(i => i.PositionType == position);
            seat.Player.IsHero = true;
        }

        public void SetHeroHand(Hand hand)
        {
            var seat = Dealer.Table.Seats.FirstOrDefault(s => s.Player.IsHero);
            seat.Player.Hand = hand;
        }



    }
}
