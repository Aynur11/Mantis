using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            //manager.Navigator.GoToLoginPage();

            Type((By.XPath("//input[@id='username']")), account.Name);
            SubmitInput();
            Type((By.XPath("//input[@id='password']")), account.Password);
            SubmitInput();
        }

        public void SubmitInput()
        {
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }
    }
}
