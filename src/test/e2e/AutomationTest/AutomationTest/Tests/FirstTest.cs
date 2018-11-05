using AutomationTest.Pages;
using AutomationTest.Utils;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;
using System.IO;

namespace AutomationTest.Tests
{
    public class FirstTest
    {
        FirstPage firstPage;

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--ignore-certificate-errors");
            Properties.driver = new ChromeDriver(options);

            firstPage = new FirstPage();
            firstPage.NavigateToUrl();
        }

        [Test]
        public void SubmitChallenge()
        {
            firstPage.ClickOnRenderChallengeButton();
            var indexList = firstPage.GetIndexList(9);
            firstPage.SubmitAnswers(indexList);
        }

        [TearDown]
        public void TearDown()
        {
            Properties.driver.Quit();
        }
    }
}
