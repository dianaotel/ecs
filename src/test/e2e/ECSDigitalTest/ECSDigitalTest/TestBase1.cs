using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSDigitalTest
{
    class TestBase1
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void OpenBrowserTest()
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["baseUrl"]);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
