using Poker.Logic;
using Poker.Model;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create scenario
            var scenario = new ScenarioGenerator(TableType.SixMax);

            //Seat Hero
            scenario.SetHeroPosition(PositionType.LoJack);

            //Set Hero hand
            var hand = new Hand(new Card(SuitType.Clubs, RankType.Ace), new Card(SuitType.Diamonds, RankType.Queen));
            scenario.SetHeroHand(hand);

            scenario.AddAction(PositionType.LoJack, ActionType.Raise);
            scenario.AddAction(PositionType.HiJack, ActionType.Raise);

            scenario.AddAction(PositionType.Button, ActionType.Fold);
            scenario.AddAction(PositionType.SmallBlind, ActionType.Fold);
            scenario.AddAction(PositionType.BigBlind, ActionType.Fold);

            var result = scenario.Run();
            Console.WriteLine(String.Format("Hero action: {0}", result.HeroAction));

            Console.WriteLine(String.Format("Villain Range"));
            Console.Write(result.VillainRange.ToString());

            Console.ReadLine();
        }


    }
}
