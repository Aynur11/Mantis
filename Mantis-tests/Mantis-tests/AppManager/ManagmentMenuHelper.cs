using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Mantis_tests
{
    public class ManagmentMenuHelper : HelperBase
    {
        public ManagmentMenuHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void GoToManagmentPage()
        {
            driver.Url = "http://localhost/mantisbt-2.13.1/my_view_page.php";
            WaitForElementDisplayed(By.XPath("//div[@id='assigned']"));
            if (driver.FindElement(By.XPath("//span[@class='menu-text']")).Displayed == false)
            {
                ToggleOnMenu();
            }
            WaitForElementDisplayed(By.XPath("//span[@class='menu-text']"));
            driver.FindElement(By.XPath("//a[@href='/mantisbt-2.13.1/manage_overview_page.php']")).Click();
            System.Threading.Thread.Sleep(1000);
        }

        public void ToggleOnMenu()
        {
            driver.FindElement(By.XPath("//button[@id='menu-toggler']")).Click();
        }

    }
}
