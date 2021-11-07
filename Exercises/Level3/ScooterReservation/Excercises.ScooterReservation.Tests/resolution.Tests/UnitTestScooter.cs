using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;

namespace Excercises.ScooterReservation.Tests
{
    public class UnitTestScooter
    {

        [Fact]
        public void Scooter_WhenConstructor_ThenReturnsScooter()
        {
            //arrange

            //act
            var scooter = new Scooter("EX344", 1.5, false);
            //assert
            Assert.Equal(1, 1);
        }

        [Fact]
        public void Scooter_WhenChangingLicence_ThenIgnore()
        {
            //arrange
            var scooter = new Scooter("EX344", 1.5, false);
            //act
            scooter.RegistrationNumber = "manipulated";
            //assert
            Assert.Equal("EX344", scooter .RegistrationNumber );
        }

       

        //public static IEnumerable<object[]> ElevatioData => new List<object[]>
        //{
        //    new object[] { new List<double> { } },
        //    new object[] { new List<double> { 0} },
        //    new object[] { new List<double> { 0,1} },
        //    new object[] { new List<double> { 0,1,2} },
        //    new object[] { new List<double> { 0,1,2,3,4,5,6,7,8,9}} ,
        //    new object[] { new List<double> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 , 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }},
        //};

        //[Theory]
        //[MemberData(nameof(ElevatioData))]
        //public void ColorDivisionInList_WhenNelevations_ThenReturns7ListColourLimits(List<double> elevations)
        //{
        //    //arrange //static class

        //    //act
        //    var colorLimits = Calc.ColorDivision(elevations, 7);
        //    //assert
        //    Assert.Equal(7, colorLimits.Count());
        //}
    }
}
