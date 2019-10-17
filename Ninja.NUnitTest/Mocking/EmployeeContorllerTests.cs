using Moq;
using Ninja.Mocking;
using Ninja.Mocking.Business;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ninja.NUnitTest.Mocking
{
    public class EmployeeContorllerTests
    {
        private Mock<IEmployeeRepository> _employeeRepository;
        private EmployeeContorller _employeeController;

        [SetUp]
        public void Setup()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            _employeeController=new EmployeeContorller(_employeeRepository.Object);
        }

        [Test]
        public void DeleteEmployee_WhenCalled_DeleteEmployeeFromDb()
        {
            //Arrange
            //in Setup Method

            //Act
            _employeeController.DeleteEmployee(1);

            //Assert
            _employeeRepository.Verify(e => e.Remove(1));
        }


    }
}
