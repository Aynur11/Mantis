using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Mantis_tests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected ApplicationManager manager;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }

        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }

        public bool IsElementPresent(By by)
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

        public void WaitForElementDisplayed(By by)
        {
            IWebElement element = driver.FindElement(by);
            while (element.Displayed == false)
            {
                System.Threading.Thread.Sleep(100);
            }
        }

        public IWebElement WaitForElement(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(2));
            return wait.Until(d => d.FindElement(by));
        }
    }
}