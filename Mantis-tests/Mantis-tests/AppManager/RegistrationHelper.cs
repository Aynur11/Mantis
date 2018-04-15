using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager)
        {

        }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
        }

        private void OpenRegistrationForm()
        {
            //driver.FindElements(By.CssSelector("span.bracket-link"))[0].Click();
            driver.FindElement(By.XPath("//a[@href='signup_page.php']")).Click();
        }

        private void SubmitRegistration()
        {
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);


        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http:/localhost/mantisbt-2.13.1/login_page.php";

        }
    }
}
