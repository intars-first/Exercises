using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;

namespace Excercises.ScooterReservation.Tests
{
    public class UnitTestRent
    {

        [Fact]
        public void Rent_WhenConstructor_ThenReturnsRent()
        {
            //arrange

            //act
            var scooter = new Scooter("EX344", 1.5, false);
            var rent = new Rent(scooter, new DateTime(2021, 11, 6, 22, 0, 0));
            //assert
            Assert.False(Object.Equals(rent, default(Rent)));
        }

        [Fact]
        public void Rent_WhenEndDateSet_ThenSucced()
        {
            //arrange
            var scooter = new Scooter("EX344", 1.5, false);
            var rent = new Rent(scooter, new DateTime(2021, 11, 6, 22, 0, 0));
            //act
            rent.EndDate = new DateTime(2021, 11, 7, 18, 0, 0);
            //assert
            Assert.Equal (new DateTime(2021, 11, 7, 18, 0, 0), rent.EndDate);
        }

        [Fact]
        public void Rent_WhenEndDateChanged_ThenIgnore()
        {
            //arrange
            var scooter = new Scooter("EX344", 1.5, false);
            var rent = new Rent(scooter, new DateTime(2021, 11, 6, 22, 0, 0));
            //act
            rent.EndDate = new DateTime(2021, 11, 7, 18, 0, 0);
            rent.EndDate = new DateTime(2021, 11, 7, 19, 0, 0);
            //assert
            Assert.Equal(new DateTime(2021, 11, 7, 18, 0, 0), rent.EndDate);
        }
    }
}
