using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;

namespace Excercises.ScooterReservation.Tests
{
    public class UnitTestUnitTestManagemnetService
    {

        [Fact]
        public void AddScooter_WhenAddNonExisting_ThenAdd()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            //act
            scooterManagementService.AddScooter(new Scooter("EX344", 0.1, false));
            //assert
            Assert.Single(scooterManagementService.ScooterFleet);
        }

        [Fact]
        public void AddScooter_WhenAddExisting_ThenThrowException()
        {
            //arrange
            bool callFailed = false;
            var scooterManagementService = new ScooterManagementService();
            try
            {
                //act
                scooterManagementService.AddScooter(new Scooter("EX344", 0.1, false));
                scooterManagementService.AddScooter(new Scooter("EX344", 0.1, false));
            }
            catch (ArgumentException)
            {
                callFailed = true;
            }
            //assert
            Assert.True(callFailed, "Succeed to failed adding redundant licence");
        }

        [Fact]
        public void RemoveScooter_WhenAvailable_ThenSucceed()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            scooterManagementService.AddScooter(new Scooter("EX344", 0.1, true));
            //act
            scooterManagementService.RemoveScooter("EX344");
            //assert
            Assert.Empty(scooterManagementService.ScooterFleet);
        }

        [Fact]
        public void RemoveScooter_WhenRented_ThenIgnore()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            scooterManagementService.AddScooter(new Scooter("EX344", 0.1, false));

            var reservationService = new ReservationService(scooterManagementService.RentedScooters);
            reservationService.RegisterRent(scooterManagementService.GetScooter("EX344"), new DateTime(2021, 11, 6, 22, 0, 0));
            //act
            scooterManagementService.RemoveScooter("EX344");
            //assert
            Assert.Single(scooterManagementService.ScooterFleet);
        }

        [Fact]
        public void MarkDamaged_WhenAvailable_ThenSucceed()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            scooterManagementService.AddScooter(new Scooter("EX344", 0.1, false));

            //act
            scooterManagementService.MarkDamaged("EX344");
            //assert
            IScooter scooter;
            scooterManagementService.ScooterFleet.TryGetValue("EX344", out scooter);
            Assert.True(scooter.IsDamaged);
        }
        [Fact]
        public void MarkDamaged_WhenRented_ThenIgnore()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            scooterManagementService.AddScooter(new Scooter("EX344", 0.1, false));

            var reservationService = new ReservationService(scooterManagementService.RentedScooters);
            reservationService.RegisterRent(scooterManagementService.GetScooter("EX344"), new DateTime(2021, 11, 6, 22, 0, 0));

            //act
            scooterManagementService.MarkDamaged("EX344");
            //assert
            IScooter scooter;
            scooterManagementService.ScooterFleet.TryGetValue("EX344", out scooter);
            Assert.False(scooter.IsDamaged);
        }

        [Fact]
        public void ChangePrice_WhenAvailable_ThenSucceed()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            scooterManagementService.AddScooter(new Scooter("EX344", 0.1, false));

            //act
            scooterManagementService.ChangePrice("EX344", 0.05);
            //assert
            IScooter scooter;
            scooterManagementService.ScooterFleet.TryGetValue("EX344", out scooter);
            Assert.Equal(0.05, scooter.Price);
        }
        [Fact]
        public void ChangePrice_WhenRented_ThenIgnore()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            scooterManagementService.AddScooter(new Scooter("EX344", 0.1, false));

            var reservationService = new ReservationService(scooterManagementService.RentedScooters);
            reservationService.RegisterRent(scooterManagementService.GetScooter("EX344"), new DateTime(2021, 11, 6, 22, 0, 0));
            //act
            scooterManagementService.ChangePrice("EX344", 0.05);
            //assert

            scooterManagementService.ScooterFleet.TryGetValue("EX344", out IScooter scooter);
            Assert.Equal(0.1, scooter.Price);
        }

        [Fact]
        public void GetScooter_WhenExists_ThenReturnScooter()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            IScooter scooter2add = new Scooter("EX344", 0.1, false);
            scooterManagementService.AddScooter(scooter2add);
            scooterManagementService.AddScooter(new Scooter("EX345", 0.1, false));

            //act
            IScooter scooterReturn = scooterManagementService.GetScooter("EX344");
            //assert

            Assert.True(Object.ReferenceEquals(scooter2add, scooterReturn), "Returned correct value");
        }
        [Fact]
        public void GetScooter_WhenMissing_ThenNull()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            scooterManagementService.AddScooter(new Scooter("EX344", 0.1, false));

            //act
            IScooter scooterReturn = scooterManagementService.GetScooter("NoLicence");
            //assert
            Assert.Null(scooterReturn);
        }

        [Fact]
        public void GetAllAviableScooters_WhenNoAvalable_ThenEmptyList()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            scooterManagementService.AddScooter(new Scooter("EX344", 0.1, true));
            scooterManagementService.AddScooter(new Scooter("EX345", 0.1, false));//damaged

            var reservationService = new ReservationService(scooterManagementService.RentedScooters);//rented
            reservationService.RegisterRent(scooterManagementService.GetScooter("EX345"), new DateTime(2021, 11, 6, 22, 0, 0));

            //act
            var availableScooters = scooterManagementService.GetAllAviableScooters();

            //assert
            Assert.Empty(availableScooters);
        }
        [Fact]
        public void GetAllAviableScooters_WhenAvailableRentedDamaged_ThenReturnAvailableOnly()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();

            scooterManagementService.AddScooter(new Scooter("EX345", 0.1, true));//damaged
            scooterManagementService.AddScooter(new Scooter("EX346", 0.1, false));
            scooterManagementService.AddScooter(new Scooter("EX347", 0.1, false));//ok

            var reservationService = new ReservationService(scooterManagementService.RentedScooters);//rented
            reservationService.RegisterRent(scooterManagementService.GetScooter("EX346"), new DateTime(2021, 11, 6, 22, 0, 0));

            //act
            var availableScooters = scooterManagementService.GetAllAviableScooters();
            //assert
            Assert.True( availableScooters .Count ==1 && "EX347" == availableScooters[0].RegistrationNumber);
        }

    }
}
