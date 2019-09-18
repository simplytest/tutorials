using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace E2ETests
{
    [TestClass]
    public class SeleniumTests
    {
        private IWebDriver _driver = null;

        private string _appURL = "http://localhost:8080/index.html"; 

        [TestInitialize]
        public void InitTest()
        {
            _driver = new ChromeDriver(Environment.CurrentDirectory);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            if (_driver != null)
                _driver.Quit();
        }

        [TestMethod]
        public void TestValidCalculation()
        {
            _driver.Navigate().GoToUrl(_appURL);
            Assert.AreEqual("CalcWebUI", _driver.Title);

            IWebElement element = _driver.FindElement(By.Name("opMult"));
            element.Click();

            element = _driver.FindElement(By.Name("operand_A"));
            element.Clear();
            element.SendKeys("3");

            element = _driver.FindElement(By.Name("operand_B"));
            element.Clear();
            element.SendKeys("4");

            element = _driver.FindElement(By.Name("calculate"));
            element.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            element = wait.Until( SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("result")));
            Assert.AreEqual("12", element.Text);
        }

        [TestMethod]
        public void TestInvalidCalculation()
        {
            _driver.Navigate().GoToUrl(_appURL);
            Assert.AreEqual("CalcWebUI", _driver.Title);

            IWebElement element = _driver.FindElement(By.Name("opMult"));
            element.Click();

            element = _driver.FindElement(By.Name("operand_A"));
            element.Clear();
            element.SendKeys("x");

            element = _driver.FindElement(By.Name("operand_B"));
            element.Clear();
            element.SendKeys("4");

            element = _driver.FindElement(By.Name("calculate"));
            element.Click();

            Thread.Sleep(200);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("toast-container")));
            Console.WriteLine(element.Text);
            Assert.IsTrue(element.Text.Contains("Calculation failed"));
        }
    }
}
