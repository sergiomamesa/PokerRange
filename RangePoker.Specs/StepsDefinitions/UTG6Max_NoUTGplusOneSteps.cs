using System;
using TechTalk.SpecFlow;

namespace RangePoker.Specs.StepsDefinitions
{
    [Binding]
    public class UTG6Max_NoUTGplusOneSteps
    {
        [Given]
        public void GivenASixMaxPlayerTableNotFull()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given]
        public void GivenUTGPlusOneIsEmpty()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
