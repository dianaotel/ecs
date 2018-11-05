using AutomationTest.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace AutomationTest.Pages
{
    public class FirstPage
    {
        private const string ChallengerName = "Diana-Andra Otel";
       
        // css selectors
        [FindsBy(How = How.CssSelector, Using = "[data-test-id=\"render-challenge\"]")]
        public IWebElement RenderChallengeButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "tr > td")]
        public IList<IWebElement> TableCells { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id=\"submit-button\"]")]
        public IWebElement SubmitChallengeButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id=\"submit-1\"]")]
        public IWebElement FirstInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id=\"submit-2\"]")]
        public IWebElement SecondInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id=\"submit-3\"]")]
        public IWebElement ThirdInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id=\"submit-4\"]")]
        public IWebElement NameInput { get; set; }

        public FirstPage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        // methods
        public void NavigateToUrl()
        {
            Properties.driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["baseUrl"]);
        }

        public void ClickOnRenderChallengeButton()
        {
            RenderChallengeButton.Click();
        }

        public List<int?> GetIndexList(int numberOfCells)
        {
            List<int?> indexList = new List<int?>();

            int[] rowArray = new int[numberOfCells];
            int count = 0;

            foreach (IWebElement cell in TableCells)
            {
                rowArray[count] = int.Parse(cell.Text);
                count++;
                if (count.Equals(numberOfCells))
                {
                    var currentValue = FindNumber(rowArray, numberOfCells);
                    var currentIndex = Array.IndexOf(rowArray, Convert.ToInt32(currentValue));

                    indexList.Add(currentIndex);
                    rowArray = new int[numberOfCells];
                    count = 0;
                }
            }

            return indexList;
        }

        public void SubmitAnswers(List<int?> indexList)
        {
            FirstInput.SendKeys(indexList[0].ToString()); 
            SecondInput.SendKeys(indexList[1].ToString()); 
            ThirdInput.SendKeys(indexList[2].ToString()); 
            NameInput.SendKeys(ChallengerName);

            SubmitChallengeButton.Click();
        }

        private static int? FindNumber(int[] arr, int n)
        {
            int[] prefixSum = new int[n];
            prefixSum[0] = arr[0];
            for (int i = 1; i < n; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + arr[i];
            }

            int[] suffixSum = new int[n];
            suffixSum[n - 1] = arr[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                suffixSum[i] = suffixSum[i + 1] + arr[i];
            }

            for (int i = 1; i < n - 1; i++)
            {
                if (prefixSum[i] == suffixSum[i])
                {
                    return arr[i];
                }
            }

            return null;
        }
    }
}
