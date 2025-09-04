using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TestProject1.Utils;
using static TestProject1.Utils.Waits;              

namespace TestProject1.Pages
{
    public class TimeAndMaterialPage
    {

        private readonly IWebDriver driver;
        public TimeAndMaterialPage(IWebDriver driver)
        {
            this.driver = driver;
            this.homePage = new HomePage(driver);
        }

       
        private HomePage homePage;

        public void lastPageButton(IWebDriver driver)
        {
            // Wait for HomePage to refresh by waiting for finding last page button
            var lastPageBtnLocator = By.XPath("//span[@class='k-icon k-i-seek-e']");
            WaitHelper.WaitForElementClickable(driver, lastPageBtnLocator, 10);

            //Click Last Page Button
            var lastColumnButton = WaitHelper.WaitForElementClickable(driver, lastPageBtnLocator);
            lastColumnButton.Click();

        }

        public void TimeAndMaterialModule(IWebDriver driver)
        {

            homePage.HomePageScreen(driver);
            // Click on create new
           
            var createNew = WaitHelper.WaitForElementClickable(driver, By.XPath("//a[normalize-space()='Create New']"));
            createNew.Click();

            // Ensure form is visible
            Waits.WaitHelper.WaitForElementVisible(driver, By.Id("TimeMaterialEditForm"));

            // Type Code Dropdown
            var typeCode = WaitHelper.WaitForElementClickable(driver, By.XPath("//*[@id='TimeMaterialEditForm']//span[@class='k-select']"));
            typeCode.Click();

            // Select Time
            var time = WaitHelper.WaitForElementClickable(driver, By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            time.Click();

            
            var codeField = WaitHelper.WaitForElementVisible(driver, By.Id("Code"));
            codeField.Clear();
            codeField.SendKeys("Test Time Code");

            
            var descriptionField = WaitHelper.WaitForElementVisible(driver, By.Id("Description"));
            descriptionField.Clear();
            descriptionField.SendKeys("Test Time Description");

          
            var priceTagOverlap = WaitHelper.WaitForElementClickable(driver, By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTagOverlap.Click();

           
            var pricePerUnit = WaitHelper.WaitForElementVisible(driver, By.Id("Price"));
            pricePerUnit.Clear();
            pricePerUnit.SendKeys("513");

           
            var saveButton = WaitHelper.WaitForElementClickable(driver, By.Id("SaveButton"));
            saveButton.Click();

            
            lastPageButton(driver);

           
        }

        // Edit the newly created time record
        public void EditTimeRecord(IWebDriver driver)
        {
            homePage.HomePageScreen(driver);
            lastPageButton(driver);

            
            var editButton = WaitHelper.WaitForElementClickable(driver, By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            // Edit Description
            var editDescription = WaitHelper.WaitForElementVisible(driver, By.Id("Description"));
            editDescription.Clear();
            editDescription.SendKeys("Test Time Record Description Edited");

            
            var savButton = WaitHelper.WaitForElementClickable(driver, By.Id("SaveButton"));
            savButton.Click();

            // Go to last page of the table
            lastPageButton(driver);
            
        }

        // Delete the newly created time record
        public void DeleteRecord(IWebDriver driver)
        {
            homePage.HomePageScreen(driver);
            lastPageButton(driver);
           
            var deleteRecentRecord = WaitHelper.WaitForElementClickable(driver, By.XPath("//table[@id='tmsGrid']//tr[last()]/td[5]/a[2]"));
            deleteRecentRecord.Click();

            var alert = WaitHelper.WaitForAlert(driver, 5);
            alert.Accept();

            lastPageButton(driver);

        }
    }
}

