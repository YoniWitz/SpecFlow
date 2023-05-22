using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace GameCore.Specs.Steps
{
    [Binding]
    [Scope(Tag = "awaitingReviewBeforeStartingWork")]
    class AwaitingReviewSteps
    {
        [Given(".*")]
        [When(".*")]
        [Then(".*")]
        public void Empty() { }
    }
}
