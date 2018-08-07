using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseAPI.Models;
using System.Linq;

namespace DatabaseAPI.Test
{
    [TestClass]
    public class DatabaseAPIUnitTest
    {
        private Employee employee;

        [TestInitialize]
        public void BeforeEach()
        {
            employee = new Employee()
            {
                EmployeeID = 2,
                Age = 20,
                Company = "ABC- 123",
                FirstName = "John",
                LastName = "Doe",
                Occupation = "DBA"
            };
        }

        [TestMethod]
        public void TestShouldCreateEmployeeTable()
        {

            //Arrange

            var employeeDataContext = new DatabaseContext<Employee>();

            var databaseWrapper = new DBWrapper<Employee>(employeeDataContext);

            //Act

            var noOfrows = databaseWrapper.CreatEntity(employee); 

            //Assert 

            Assert.AreEqual(1, noOfrows); // The assumption that a single row will be added in the table. 
        }

        [TestMethod]
        public void TestShouldUpdateEmployeeTable()
        {

            //Arrange

            var employeeDataContext = new DatabaseContext<Employee>();

            var databaseWrapper = new DBWrapper<Employee>(employeeDataContext);

            //Act
            employee.Age = 35;
            var noOfrows = databaseWrapper.Update(employee);

            //Assert 

            Assert.AreEqual(1, noOfrows);
        }

        [TestMethod]
        public void TestShouldDeleteEmployeeTable()
        {

            //Arrange

            var employeeDataContext = new DatabaseContext<Employee>();

            var databaseWrapper = new DBWrapper<Employee>(employeeDataContext);

            //Act

            var noOfrows = databaseWrapper.Delete(employee);

            //Assert 

            Assert.AreEqual(1, noOfrows);
        }

        [TestMethod]
        public void TestShouldSelectEmployeeTable()
        {

            //Arrange

            var employeeDataContext = new DatabaseContext<Employee>();

            var databaseWrapper = new DBWrapper<Employee>(employeeDataContext);

            //Act

            var employeeObject = databaseWrapper.Select(employee);
            var employeeList = employeeObject.ToList();

            //Assert 

            Assert.AreEqual(35, employeeList.FirstOrDefault().Age);  // Assume the age from table is 35 
        }
    }
}
