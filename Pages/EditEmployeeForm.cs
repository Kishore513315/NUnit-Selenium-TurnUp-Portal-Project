using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestProject1.Utils.Waits;

namespace TestProject1.Pages
{
    public class EditEmployeeForm
    {

        private readonly IWebDriver driver;

        public EditEmployeeForm(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }
        public void EmployeeForm()
        {
           

            var firstName = WaitHelper.WaitForElementVisible(driver, By.Id("FirstName"));
            firstName.Clear();
            firstName.SendKeys("Test Contact");

            var lastName = WaitHelper.WaitForElementVisible(driver, By.Id("LastName"));
            lastName.Clear();
            lastName.SendKeys("Contact");

            var preferredName = WaitHelper.WaitForElementVisible(driver, By.Id("PreferedName"));
            preferredName.Clear();
            preferredName.SendKeys("Test1");

            var phoneNumber = WaitHelper.WaitForElementVisible(driver, By.Id("Phone"));
            phoneNumber.Clear();
            phoneNumber.SendKeys(" ");

            var mobileNumber = WaitHelper.WaitForElementVisible(driver, By.Id("Mobile"));
            mobileNumber.Clear();
            mobileNumber.SendKeys("9876543210");

            var email = WaitHelper.WaitForElementVisible(driver, By.Id("email"));
            email.Clear();
            email.SendKeys("test123@testing.com");

            var fax = WaitHelper.WaitForElementVisible(driver, By.Id("Fax"));
            fax.Clear();
            fax.SendKeys(" ");

            var address = WaitHelper.WaitForElementVisible(driver, By.Id("autocomplete"));
            address.Clear();
            address.SendKeys("123 Test");

            var street = WaitHelper.WaitForElementVisible(driver, By.Id("Street"));
            street.Clear();
            street.SendKeys("Test Street");

            var city = WaitHelper.WaitForElementVisible(driver, By.Id("City"));
            city.Clear();
            city.SendKeys("Test City");

            var postCode = WaitHelper.WaitForElementVisible(driver, By.Id("Postcode"));
            postCode.Clear();
            postCode.SendKeys("12345");

            var country = WaitHelper.WaitForElementVisible(driver, By.Id("Country"));
            country.Clear();
            country.SendKeys("New Zealand");

            var saveContactButton = WaitHelper.WaitForElementClickable(driver, By.Id("submitButton"));
            saveContactButton.Click();



        }

    }
}
