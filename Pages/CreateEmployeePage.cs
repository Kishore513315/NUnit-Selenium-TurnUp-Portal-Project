using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using static TestProject1.Utils.Waits;

namespace TestProject1.Pages
{
      public class CreateEmployeePage
    {
        private readonly IWebDriver driver;
        public CreateEmployeePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void CreateNewEmployee()
        {
            // Find and Click create button
            var createEmployeeButton = WaitHelper.WaitForElementClickable(driver, By.XPath("//a[normalize-space()='Create']"));
            createEmployeeButton.Click();

            var employeeName = WaitHelper.WaitForElementVisible(driver, By.Id("Name"));
            employeeName.Clear();
            employeeName.SendKeys("Test Employee");

            var employeeUserName = WaitHelper.WaitForElementVisible(driver, By.Id("Username"));
            employeeUserName.Clear();
            employeeUserName.SendKeys("Test@123");

            //// blur Username to trigger any client-side validation
            //employeeUserName.SendKeys(Keys.Tab);

            //// wait for any loading mask/overlay to finish
            //new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            //    .Until(d => d.FindElements(By.CssSelector(".k-loading-mask,.k-overlay")).Count == 0);

            //// wait until the Edit Contact button is visible & enabled
            //var editBtn = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            //    .Until(d =>
            //    {
            //        var e = d.FindElement(By.Id("EditContactButton"));
            //        return (e.Displayed && e.Enabled && e.GetAttribute("disabled") == null) ? e : null;
            //    });

            //// scroll into view and click (with JS fallback if intercepted)
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block:'center'});", editBtn);
            //try { editBtn.Click(); }
            //catch (ElementClickInterceptedException)
            //{
            //    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", editBtn);
            //}

            //// fill the Edit Contact form
            //var editForm = new EditEmployeeForm(driver);
            //editForm.EmployeeForm();

            //// prove it saved: wait until ContactDisplay shows the email
            //new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            //    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
            //        .TextToBePresentInElementValue(By.Id("ContactDisplay"), "test123@testing.com"));

            //// read final value (optional)
            //var contactDisplay = driver.FindElement(By.Id("ContactDisplay"));
            //Console.WriteLine("Contact updated: " + contactDisplay.GetAttribute("value"));



            var password = WaitHelper.WaitForElementVisible(driver, By.Id("Password"));
            password.Clear();
            password.SendKeys("Test@123");

            var reTypePassword = WaitHelper.WaitForElementVisible(driver, By.Id("RetypePassword"));
            reTypePassword.Clear();
            reTypePassword.SendKeys("Test@123");

            var IsAdminCheckBox = WaitHelper.WaitForElementClickable(driver, By.Id("IsAdmin"));
            if (!IsAdminCheckBox.Selected)
            {
                IsAdminCheckBox.Click();
            }

            var vehicle = WaitHelper.WaitForElementVisible(driver, By.Name("VehicleId_input"));
            vehicle.Clear();
            vehicle.SendKeys("Car");
            vehicle.SendKeys(Keys.Enter);

            ////Click on the Groups dropdown using Css Selector
            //var groups = WaitHelper.WaitForElementClickable(driver, By.CssSelector(".k-multiselect-wrap.k-floatwrap"));
            //groups.Click();

            //// Wait for the dropdown options to be visible
            //var groupsListBox = WaitHelper.WaitForElementVisible(driver, By.Id("groupList_listbox"));

            ////select the group from dropdown
            //var selectGroup = driver.FindElements(By.XPath("//ul[@id='groupList_listbox']/li[normalize-space()='Aussie group']"));
            //selectGroup[2].Click();

            var saveButton = WaitHelper.WaitForElementClickable(driver, By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(5000);

        }

        public void CheckEmployeeCreated()
        {
            var turnUpTab = WaitHelper.WaitForElementClickable(driver, By.XPath("//a[normalize-space()='TurnUp']"));
            turnUpTab.Click();
            Thread.Sleep(5000);


            HomePage home = new(driver);

            home.FindEmployeesModule();

            // Go to the last page of employee grid to see the new employee
            var lastPageButton = WaitHelper.WaitForElementClickable(driver, By.XPath("//span[@class='k-icon k-i-seek-e']"));
            lastPageButton.Click();

            // Wait for page to load
            var lastPage = WaitHelper.WaitForElementVisible(driver, By.XPath("//div[@class='k-grid-content']"));

        }

        public String GetEmployeeName()
        {

            // Check the last record in the table which is created recently
            var lastRow = WaitHelper.WaitForElementVisible(driver, By.XPath("//div[@class='k-grid-content']//table/tbody/tr[last()]"));
            return lastRow.FindElement(By.XPath("td[1]")).Text;
        }

        public String GetEmployeeUsername()
        {
            var actualUserName = WaitHelper.WaitForElementVisible(driver, By.XPath("//div[@class='k-grid-content']//table/tbody/tr[last()]"));
            return actualUserName.FindElement(By.XPath("td[2]")).Text;
        }

        }
    }

