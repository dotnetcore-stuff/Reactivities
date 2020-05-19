using System;
using TechTalk.SpecFlow;

namespace API.ATs.StepDefinitions
{
    [Binding]
    public class OrdersStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public OrdersStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"A configured environment")]
        public void GivenAConfiguredEnvironment()
        {
        }

        [Given(@"You have a need to buy some goods")]
        public void GivenYouHaveANeedToBuySomeGoods()
        {
        }

        [When(@"You place an order")]
        public void WhenYouPlaceAnOrder()
        {
        }

        [Then(@"The order message should get published successfully")]
        public void ThenTheOrderMessageShouldGetPublishedSuccessfully()
        {
        }
    }
}
