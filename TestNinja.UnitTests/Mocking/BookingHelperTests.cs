using Moq;
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
    class BookingHelperTests
    {
        //TestCases
        //1] Overlapp exists and booking status is cancelled - returns empty string
        //2) No overlapp and booking is cancelled - returns empty string
        //3] No overlapp and booking is not cancelled - returns empty string
        //4] Overlapp exists and booking is not cancelled - returns string with a reference

        private Booking _booking;

        private Mock<IBookingRepository> _mockRepository;

        private List<Booking> listOfBookings;

        private IQueryable<Booking> bookings; 


        [SetUp]
        public void SetUp()
        {
            _mockRepository = new Mock<IBookingRepository>();

            listOfBookings = new List<Booking>();

            bookings = listOfBookings.AsQueryable();


            _booking = new Booking
            {
                ArrivalDate = AriveOn(2019, 1, 15),
                DepartureDate = Departure(2019, 1, 20),
                Reference = "a",
                Id = 2
            };

            listOfBookings.Add(_booking);
        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsAndFinishesBeforeExistingBooking_ReturnsEmptyString()
        {  
            //Arrange
            var excludedBooking = new Booking
            {
                ArrivalDate = AriveOn(2019, 1, 10),
                DepartureDate = Departure(2019, 1, 14),
                Reference = "e",
                Id = 1
            };           
                        
            _mockRepository.Setup(mr => mr.GetActiveBookings(1)).Returns(bookings);

            //Act
            var result = BookingHelper.OverlappingBookingsExist(excludedBooking, _mockRepository.Object);

            Assert.That(result, Is.EqualTo(string.Empty));

        }

        private DateTime AriveOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 14,0,0);
        }

        private DateTime Departure(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }

    }
}
