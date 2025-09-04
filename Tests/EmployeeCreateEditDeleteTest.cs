
using TestProject1.Pages;

namespace TestProject1.Tests
{
    [TestFixture]
    public class EmployeeCreateEditDeleteTest : BaseTest
    {
        [Test]
        public void CreateEmployeeTest()
        {
            var homePage = new HomePage(driver);
            homePage.FindEmployeesModule();

            var createemployee = new CreateEmployeePage(driver);

            // Create New Employee
            createemployee.CreateNewEmployee();

            // Go to last Page
            createemployee.CheckEmployeeCreated();

            //Check values
            String actualName = createemployee.GetEmployeeName();
            String UserNameCheck = createemployee.GetEmployeeUsername();

            //Verify if the record is created succesfully by checking Name and Username

            Assert.That(actualName, Is.EqualTo("Test Employee"), "Employee Name did not match");
            Assert.That(UserNameCheck, Is.EqualTo("Test@123"), "Employee Username did not match");

        }

    }
}
