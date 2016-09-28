using System.Collections.Generic;

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
            Rules.Add(new RFIvs3BetVillainRule());
            Rules.Add(new NoVillainRule());

            return Rules;
        }
    }
}
