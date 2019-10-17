using Moq;
using Ninja.Mocking;
using Ninja.Mocking.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Ninja.NUnitTest.Mocking
{
    public class BookingHelperTests
    {
        private Booking _existingBooking;
        private Mock<IBookingRepository> _bookRepository;

        [SetUp]
        public void SetUp()
        {
            _existingBooking = new Booking()
            {
                Id = 2,
                Status = "",
                ArrivalDate = ArriveOn(2019, 10, 15),
                DepartureDate = DepartOn(2019, 10, 20),
                Reference = "a"
            };

            _bookRepository = new Mock<IBookingRepository>();

            //Arrange
            _bookRepository.Setup(m => m.GetActiveBookings(1)).Returns(new List<Booking>() {
                 _existingBooking
            }.AsQueryable());


        }

        [Test]
        public void OverlappingBookingExist_BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
            //Act
            var result = BookingHelper.OverlappingBookingExist(new Booking()
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate,days:2),
                DepartureDate = Before(_existingBooking.ArrivalDate)

            }, _bookRepository.Object);



            //Assert
            Assert.That(result, Is.Empty);
        }


        [Test]
        public void OverlappingBookingExist_BookingStartsBeforeAndFinishesInTheMiddleOfAnExistingBooking_ReturnExistingBookingRefrence()
        {
            //Act
            var result = BookingHelper.OverlappingBookingExist(new Booking()
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate),
                DepartureDate = After(_existingBooking.ArrivalDate)

            }, _bookRepository.Object);



            //Assert
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }

        [Test]
        public void OverlappingBookingExist_BookingStartsBeforeAndFinishesAfterAnExistingBooking_ReturnExistingBookingRefrence()
        {
            //Act
            var result = BookingHelper.OverlappingBookingExist(new Booking()
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate),
                DepartureDate = After(_existingBooking.DepartureDate)

            }, _bookRepository.Object);

            //Assert
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }

        [Test]
        public void OverlappingBookingExist_BookingStartsAndFinishesInTheMiddleOfAnExistingBooking_ReturnExistingBookingRefrence()
        {
            //Act
            var result = BookingHelper.OverlappingBookingExist(new Booking()
            {
                Id = 1,
                ArrivalDate = After(_existingBooking.ArrivalDate),
                DepartureDate = Before(_existingBooking.DepartureDate)

            }, _bookRepository.Object);



            //Assert
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }

        [Test]
        public void OverlappingBookingExist_BookingStartsInTheMiddleButFinishesAfter_ReturnExistingBookingRefrence()
        {
            //Act
            var result = BookingHelper.OverlappingBookingExist(new Booking()
            {
                Id = 1,
                ArrivalDate = After(_existingBooking.ArrivalDate),
                DepartureDate = After(_existingBooking.DepartureDate)

            }, _bookRepository.Object);



            //Assert
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }

        [Test]
        public void OverlappingBookingExist_BookingStartsAndFinishesAfterAnExistingBooking_ReturnEmptyString()
        {
            //Act
            var result = BookingHelper.OverlappingBookingExist(new Booking()
            {
                Id = 1,
                ArrivalDate = After(_existingBooking.DepartureDate),
                DepartureDate = After(_existingBooking.ArrivalDate,2)

            }, _bookRepository.Object);



            //Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void OverlappingBookingExist_NewBookingIsCancelled_ReturnEmptyString()
        {
            //Act
            var result = BookingHelper.OverlappingBookingExist(new Booking()
            {
                Id = 1,
                ArrivalDate = After(_existingBooking.DepartureDate),
                DepartureDate = After(_existingBooking.ArrivalDate),
                Status="Cancelled"

            }, _bookRepository.Object);



            //Assert
            Assert.That(result, Is.Empty);
        }

        private DateTime ArriveOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }

        private DateTime DepartOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }

        private DateTime Before(DateTime dateTime,int days = 1)
        {
            return dateTime.AddDays(-days);
        }

        private DateTime After(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(days);
        }



    }
}
