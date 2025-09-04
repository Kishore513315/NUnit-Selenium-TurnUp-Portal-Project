using OpenQA.Selenium;

using static TestProject1.Utils.Waits;

namespace TestProject1.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void HomePageScreen(IWebDriver driver)
        {
            // Find Administrator tab in Home page menu
            IWebElement administrator = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrator.Click();

            // Select Time and Materials Under Adminstrator tab
            IWebElement selectTimeAndMaterials = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            selectTimeAndMaterials.Click();

        }

        public void FindEmployeesModule()
        {
            var administratorDropdown = WaitHelper.WaitForElementClickable(driver, By.XPath("//a[normalize-space()='Administration']"));
            administratorDropdown.Click();

            var employeesModule = WaitHelper.WaitForElementClickable(driver, By.XPath("//a[normalize-space()='Employees']"));
            employeesModule.Click();
        }
    }
}
