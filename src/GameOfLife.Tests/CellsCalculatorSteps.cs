using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GameOfLife.Tests
{
    [Binding]
    public class CellsCalculatorSteps
    {
        private int firstNumber;
        private int secondNumber;
        
        [Given(@"the number ""([^""]*)""")]
        public void GivenTheNumber(int first)
        {
            firstNumber = first;
        }

        [When(@"added to the number ""([^""]*)""")]
        public void WhenAddedToTheNumber(int second)
        {
            secondNumber = second;
        }

        [Then(@"the result should be ""([^""]*)""")]
        public void ThenTheResultShouldBe(int expected)
        {
            Assert.That(firstNumber + secondNumber, Is.EqualTo(expected));
        }
    }
}
