using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AudenTestFramework.SetUpCheck
{
    [Binding]
    public class SetUpCheckFeatureSteps
    {

        int FirstNum, SecondNum, Answer;
        IWebDriver WebDriver;

        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int p0)
        {
            FirstNum = p0;
        }
        
        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int p0)
        {
            SecondNum = p0;
        }
        
        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            Answer = FirstNum + SecondNum;
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int p0)
        {
            Assert.That(Answer, Is.EqualTo(p0));
        }

        [Given(@"I want to see a browser")]
        public void GivenIWantToSeeABrowser()
        {
            WebDriver = new ChromeDriver();
        }

        [When(@"I open chrome")]
        public void WhenIOpenChrome()
        {
            WebDriver.Navigate().GoToUrl("http://www.google.co.uk");

        }

        [Then(@"as new browser window should be displayed")]
        public void ThenAsNewBrowserWindowShouldBeDisplayed()
        {
            String WindowTitle = WebDriver.Title;
            Assert.That("Google", Is.EqualTo(WindowTitle));
            WebDriver.Quit();
        }


    }
}
