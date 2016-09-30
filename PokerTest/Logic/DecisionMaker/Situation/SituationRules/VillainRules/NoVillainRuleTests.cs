using NUnit.Framework;
using Poker.Logic;
using Poker.Model;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Logic.Tests
{
    [TestFixture]
    public class NoVillainRuleTests
    {
        [Test]
        public void Test_Condition_Any_ReturnsTrue()
        {
            var list = new List<ActionEvent>();
            var rule = new NoVillainRule();

            var actual = rule.Condition(list, PositionType.BigBlind);

            Assert.AreEqual(true, actual);
        }
    }
}