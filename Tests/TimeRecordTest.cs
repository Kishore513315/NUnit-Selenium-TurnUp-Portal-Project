using NUnit.Framework;
using OpenQA.Selenium;
using TestProject1.Pages;
using TestProject1.Utils;
using static TestProject1.Utils.Waits;

namespace TestProject1.Tests
{
    [TestFixture]
    public class TimeRecordTest : BaseTest
    {
        private TimeAndMaterialPage timeAndMaterialPage;

        [SetUp]   
        public void TestSetUp()
        {
            timeAndMaterialPage = new TimeAndMaterialPage(driver);
        }

        [Test, Order(1)]
        public void CreateNewTimeRecord()
        {
            timeAndMaterialPage.TimeAndMaterialModule(driver);
            var newTimeRecord = WaitHelper.WaitForElementVisible(driver, By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(newTimeRecord.Text, Is.EqualTo("Test Time Code"), " New Time Record was not Created");


        }

        [Test, Order(2)]
        public void EditNewTimeRecord()
        {
            timeAndMaterialPage.EditTimeRecord(driver);
            var editDescription = WaitHelper.WaitForElementVisible(driver, By.XPath("//table[@id='tmsGrid']//tr[last()]/td[3]"));
            Assert.That(editDescription.Text, Is.EqualTo("Test Time Record Description Edited"), "Time Record Description was not Edited");
        }

        [Test, Order(3)]
        public void DeleteNewTimeRecord()
        {
            timeAndMaterialPage.DeleteRecord(driver);
            var deleteEditedRecord = WaitHelper.WaitForElementVisible(driver, By.XPath("//table[@id='tmsGrid']//tr[last()]/td[3]"));
            Assert.That(deleteEditedRecord.Text, Is.Not.EqualTo("Test Time Record Description Edited"), "Time Record Description was not Deleted");
        }
    }
}
