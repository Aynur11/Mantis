using System;
using System.Text;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace Mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        public RegistrationHelper Registration { get; private set; }
        public FtpHelper Ftp { get; private set; }
        public LoginHelper Auth { get; set; }
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public NavigationHelper Navigator { get; private set; }
        public ManagmentMenuHelper MenuManagment { get; private set; }
        public ProjectManagmentHelper ProjectManagment { get; private set; }

        private ApplicationManager()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.UseLegacyImplementation = true;
            options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            Auth = new LoginHelper(this);
            MenuManagment = new ManagmentMenuHelper(this);
            ProjectManagment = new ProjectManagmentHelper(this);
            Navigator = new NavigationHelper(this);
        }
        
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http:/localhost/mantisbt-2.13.1/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }
    }
}
