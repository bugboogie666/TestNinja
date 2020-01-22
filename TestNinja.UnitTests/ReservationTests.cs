using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();
            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });
            //Assert
            Assert.That(result,Is.True);
        }
        [Test]
        public void CanBeCancelledBy_SameUserCancelling_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();
            var testUser = new User { IsAdmin = false };
            reservation.MadeBy = testUser;
            //Act
            var result = reservation.CanBeCancelledBy(testUser);
            //Assert
            Assert.That(result, Is.True);
        }
        [Test]
        public void CanBeCancelledBy_AnotherUserNotAdminCancelling_ReturnsFalse()
        {
            //Arrange
            var userWhoMadeReservation = new User { IsAdmin = false };
            var reservation = new Reservation();            
            reservation.MadeBy = userWhoMadeReservation;
            var userWhoTryToCancelReservation = new User { IsAdmin = false };
            //Act            
            var result = reservation.CanBeCancelledBy(userWhoTryToCancelReservation);
            //Assert
            Assert.That(result, Is.False);
        }
    }
}
