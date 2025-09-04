using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Utils
{
    internal class Waits
    {
        public static class WaitHelper
        {
            public static IWebElement WaitForElementVisible(IWebDriver driver, By locator, int timeoutInSeconds = 10)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }

            public static IWebElement WaitForElementClickable(IWebDriver driver, By locator, int timeoutInSeconds = 10)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            }

            public static IWebElement WaitForElementExists(IWebDriver driver, By locator, int timeoutInSeconds = 10)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(ExpectedConditions.ElementExists(locator));
            }

            public static IAlert WaitForAlert(IWebDriver driver, int timeoutInSeconds = 10)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(ExpectedConditions.AlertIsPresent());
            }

            internal static object waitForElementClickable(IWebDriver driver, By by)
            {
                throw new NotImplementedException();
            }
        }
    }
}
