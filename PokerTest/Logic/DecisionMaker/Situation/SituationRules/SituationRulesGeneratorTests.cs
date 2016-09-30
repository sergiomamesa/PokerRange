using NUnit.Framework;
using Poker.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Logic.Tests
{
    [TestFixture]
    public class SituationRulesGeneratorTests
    {
        [Test]
        public void Test_HeroRules_ContainsFacingRaiseHeroRule_ReturnsTrue()
        {
            var rules = new SituationRulesGenerator().HeroRules();

            var actual = rules.OfType<FacingRaiseHeroRule>();

            Assert.AreEqual(1, actual.Count());
            Assert.IsInstanceOf<FacingRaiseHeroRule>(actual.First());
        }

        [Test]
        public void Test_HeroRules_ContainsRFIHeroRule_ReturnsTrue()
        {
            var rules = new SituationRulesGenerator().HeroRules();

            var actual = rules.OfType<RFIHeroRule>();

            Assert.AreEqual(1, actual.Count());
            Assert.IsInstanceOf<RFIHeroRule>(actual.First());
        }

        [Test]
        public void Test_HeroRules_ContainsRFIvs3BetHeroRule_ReturnsTrue()
        {
            var rules = new SituationRulesGenerator().HeroRules();

            var actual = rules.OfType<RFIvs3BetHeroRule>();

            Assert.AreEqual(1, actual.Count());
            Assert.IsInstanceOf<RFIvs3BetHeroRule>(actual.First());
        }

        [Test]
        public void Test_VillainRules_ContainsNoVillainRule_ReturnsTrue()
        {
            var rules = new SituationRulesGenerator().VillainRules();

            var actual = rules.OfType<NoVillainRule>();

            Assert.AreEqual(1, actual.Count());
            Assert.IsInstanceOf<NoVillainRule>(actual.First());
        }

        [Test]
        public void Test_VillainRules_ContainsRaiseFirstInVillainRule_ReturnsTrue()
        {
            var rules = new SituationRulesGenerator().VillainRules();

            var actual = rules.OfType<RaiseFirstInVillainRule>();

            Assert.AreEqual(1, actual.Count());
            Assert.IsInstanceOf<RaiseFirstInVillainRule>(actual.First());
        }

        [Test]
        public void Test_VillainRules_ContainsRFIvs3BetVillainRule_ReturnsTrue()
        {
            var rules = new SituationRulesGenerator().VillainRules();

            var actual = rules.OfType<RFIvs3BetVillainRule>();

            Assert.AreEqual(1, actual.Count());
            Assert.IsInstanceOf<RFIvs3BetVillainRule>(actual.First());
        }
    }
}