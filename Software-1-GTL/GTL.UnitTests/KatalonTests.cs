using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace GTL.UnitTests
{
    [TestClass]
    public class KatalonTestCase
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new ChromeDriver();
            baseURL = "https://www.katalon.com/";
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
            try
            {
                //driver.Quit();// quit does not close the window
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        [TestInitialize]
        public void InitializeTest()
        {
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public async Task CreateLoanTestCaseAsync()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://georgiatechlibrary.azurewebsites.net/" /*"http://localhost:53494/"*/);
            await Task.Delay(5000);
            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.Id("Username")).Click();
            driver.FindElement(By.Id("Username")).Clear();
            driver.FindElement(By.Id("Username")).SendKeys("Bookmaster1337");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("Glasses");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Password'])[1]/following::input[2]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)=': Grp5 publishing'])[1]/following::input[2]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='A loan will be created with the following books:'])[1]/following::form[1]")).Click();
            driver.FindElement(By.Id("memberSSN")).Clear();
            driver.FindElement(By.Id("memberSSN")).SendKeys("123456");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Add a members SSN:'])[1]/following::input[2]")).Click();
            driver.FindElement(By.LinkText("Catalogue")).Click();
            driver.FindElement(By.LinkText("Back")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
