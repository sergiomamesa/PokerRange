using Poker.Model;
using Poker.Model.Enums;
using Poker.Ranges.Parser;
using Poker.Ranges.Reader;
using Ranges.Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Logic
{
    public class DecisionMaker
    {
        private PositionType HeroPosition;
        private List<Seat> BeforeHero;
        private List<Seat> AfterHero;
        private SituationType Situation;

        public DecisionMaker(List<Seat> tableSeats)
        {
            SetPlayers(tableSeats);
            SetHeroPosition();
            Situation = GetSituation();
        }

        private void SetPlayers(List<Seat> allSeats)
        {
            BeforeHero = allSeats.TakeWhile(s => s.Player.IsHero).ToList();
            AfterHero = allSeats.SkipWhile(s => s.Player.IsHero).Skip(1).ToList();
        }

        private void SetHeroPosition()
        {
            HeroPosition = (PositionType)(BeforeHero.Last().PositionType + 1);
        }

        private SituationType GetSituation()
        {
            if (AfterHero.Any(s => s.Action == ActionType.Raise))
                return SituationType.RFIvs3Bet;
            
            if (BeforeHero.Any(s => s.Action == ActionType.Raise))
                return SituationType.FacingRaise;

            return SituationType.RaiseFirstIn;    
        }

        //public ActionType Run()
        //{
        //    var parser = new ActionParser();
        //    var fileReader = new FileReaderFactory().CreateInstance(Situation, HeroPosition);
            
        //}

    }
}
