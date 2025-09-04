using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.Utils;   // WaitHelper
using static TestProject1.Utils.Waits;

namespace TestProject1.Pages
{
    public class LoginPage
    {
        // ChromeOptions options = new ChromeOptions();
        // ChromeOptions.AddUserProfilePreference("profile.password_manager_leak_detection", false);
        // IWebDriver driver = new ChromeDriver(options);

        // ❌ Don't new the driver here—your tests create and manage it.
        // IWebDriver driver = new ChromeDriver();

        // ✅ Let the test pass the driver in
        public void LoginActions(IWebDriver driver)
        {
            // Give the Url
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login");

            // Maximize the browser window to your screen size
           // driver.Manage().Window.Maximize();

            // Find the username input field and enter the username
            // IWebElement userName = driver.FindElement(By.Id("UserName"));
            var userName = WaitHelper.WaitForElementVisible(driver, By.Id("UserName"));
            userName.Clear();
            userName.SendKeys("hari");

            // Find the password input field and enter the password
            // IWebElement fillPassword = driver.FindElement(By.Id("Password"));
            var fillPassword = WaitHelper.WaitForElementVisible(driver, By.Id("Password"));
            fillPassword.Clear();
            fillPassword.SendKeys("123123");

            // Find the login button and click it
            // IWebElement findLoginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            var findLoginButton = WaitHelper.WaitForElementClickable(driver, By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            findLoginButton.Click();

            // Wait for the page to load and check if the login was successful
            // IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
            WaitHelper.WaitForElementVisible(driver, By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
        }
    }
}
