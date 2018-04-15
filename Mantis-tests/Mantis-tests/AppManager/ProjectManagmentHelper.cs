﻿using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Interactions;

namespace Mantis_tests
{
    public class ProjectManagmentHelper : HelperBase
    {
        public ProjectManagmentHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void CreateProject(ProjectData project)
        {
            manager.MenuManagment.GoToManagmentPage();
            GoToPrjectManagmentPage();
            //System.Threading.Thread.Sleep(2000);

            CreateNewProject();
            FillForm(project);
            SubmitProjectCreation();
            System.Threading.Thread.Sleep(2000);
        }

        public List<ProjectData> GetProjectsList()
        {
            manager.MenuManagment.GoToManagmentPage();
            GoToPrjectManagmentPage();
            List<ProjectData> projects = new List<ProjectData>();
            System.Threading.Thread.Sleep(2000);

            ICollection<IWebElement> elements = driver.FindElement(By.TagName("tbody")).FindElements(By.TagName("tr"));
            foreach (IWebElement element in elements)
            {
                projects.Add(new ProjectData(
                    element.FindElements(By.TagName("td"))[0].Text)
                {
                    Decriptoin = element.FindElements(By.TagName("td"))[4].Text
                });
            }
            return projects;
        }

        public void RemoveProject(ProjectData toBeRemoved)
        {
            ICollection<IWebElement> elements = driver.FindElement(By.TagName("tbody")).FindElements(By.TagName("tr"));
            foreach (IWebElement element in elements)
            {
                if (element.FindElements(By.TagName("td"))[0].Text == toBeRemoved.Name)
                {
                    element.FindElements(By.TagName("td"))[0].FindElement(By.TagName("a")).Click();
                    SubmitProjectRemove();
                    return;
                }
            }
        }

        private void SubmitProjectRemove()
        {
            Actions actions = new Actions(driver);
            WaitForElement(By.XPath("//input[@value='Удалить проект']"));
            actions.MoveToElement(driver.FindElement(By.XPath("//input[@value='Изменить проект']")));
            actions.Perform();
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }
        private void SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        private void FillForm(ProjectData project)
        {
            Type(By.XPath("//input[@id='project-name']"), project.Name);
            Type(By.XPath("//textarea[@id='project-description']"), project.Decriptoin);
        }

        public void GoToPrjectManagmentPage()
        {
            driver.FindElement(By.XPath("//a[@href='/mantisbt-2.13.1/manage_proj_page.php']")).Click();
        }

        private void CreateNewProject()
        {
            WaitForElement(By.XPath("//button[@class='btn btn-primary btn-white btn-round']"));
            driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-white btn-round']")).Click();
        }
    }
}