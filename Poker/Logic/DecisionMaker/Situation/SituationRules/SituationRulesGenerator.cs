using Poker.Extensions;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Logic
{
    public class SituationRulesGenerator
    {
        public List<ISituationRule> Rules { get; set; }

        public SituationRulesGenerator()
        {
            Rules = new List<ISituationRule>();
        }

        public List<ISituationRule> HeroRules()
        {
            Rules = new List<ISituationRule>();

            Rules.Add(new FacingRaiseHeroRule());
            Rules.Add(new RFIHeroRule());
            Rules.Add(new RFIvs3BetHeroRule());

            return Rules;
        }

        public List<ISituationRule> VillainRules()
        {
            Rules = new List<ISituationRule>();

            Rules.Add(new RaiseFirstInVillainRule());
            Rules.Add(new FacingRaiseVillainRule());
            Rules.Add(new NoVillainRule());

            return Rules;
        }
    }
}
