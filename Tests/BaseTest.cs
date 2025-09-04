using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.Pages;

namespace TestProject1.Tests
{
    public abstract class BaseTest
    {

        protected IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [SetUp]
        public void SetUp()
        {
            LoginPage login = new LoginPage();
            login.LoginActions(driver);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            try
            {
                driver?.Quit();
            }
            finally
            {
                driver?.Dispose();
            }
        }
    }
}
