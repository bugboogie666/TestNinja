﻿using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class EmployeeControllerTests
    {

        [Test]
        public void DeleteEpmployee_WhenCalled_DeleteTheEmployeeFromDB()
        {
            var storage = new Mock<IEmployeeStorage>();
            var controller = new EmployeeController(storage.Object);

            controller.DeleteEmployee(1);
            storage.Verify(s => s.DeleteRecord(1));           

        }

    }
}