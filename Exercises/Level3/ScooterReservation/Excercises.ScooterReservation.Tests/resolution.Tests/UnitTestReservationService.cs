using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;

namespace Excercises.ScooterReservation.Tests
{
    public class UnitTestReservationService
    {

        [Fact]
        public void RegistrerRent_WhenPossible_ThenAdd()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            scooterManagementService.AddScooter(new Scooter("EX344", 0.1, false));
            var reservationService = new ReservationService(scooterManagementService.RentedScooters);

            //act
            reservationService.RegisterRent(scooterManagementService.GetScooter("EX344"), new DateTime(2021, 11, 6, 22, 0, 0));

            //assert
            Assert.Single(scooterManagementService.RentedScooters);
        }

        [Fact]
        public void RegistrerRent_WhenImPossible_ThenIgnore()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            var reservationService = new ReservationService(scooterManagementService.RentedScooters);

            scooterManagementService.AddScooter(new Scooter("EX344", 0.1, false));
            scooterManagementService.AddScooter(new Scooter("EX345", 0.1, true));

            //act
            reservationService.RegisterRent(scooterManagementService.GetScooter("EX344"), new DateTime(2021, 11, 6, 22, 0, 0));
            reservationService.RegisterRent(scooterManagementService.GetScooter("EX345"), new DateTime(2021, 11, 6, 22, 0, 0));
            reservationService.RegisterRent(scooterManagementService.GetScooter("EX344"), new DateTime(2021, 11, 6, 22, 0, 0));

            //assert
            Assert.Single(scooterManagementService.RentedScooters);
        }

        [Fact]
        public void RegistrerRent_WhenOnlyScheduledEnd_ThenIgnore()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            var reservationService = new ReservationService(scooterManagementService.RentedScooters);

            scooterManagementService.AddScooter(new Scooter("EX344", 0.1, false));

            //act
            reservationService.RegisterRent(scooterManagementService.GetScooter("EX344"), new DateTime(2021, 11, 6, 22, 0, 0));
            var rent = reservationService.GetRentByLicence("EX344");
            double costs = reservationService.EndRent(rent, new DateTime(2021, 11, 8, 22, 0, 0));

            reservationService.RegisterRent(scooterManagementService.GetScooter("EX344"), new DateTime(2021, 11, 7, 22, 0, 0));

            //assert

            Assert.NotEqual(new DateTime(2021, 11, 7, 22, 0, 0), reservationService.GetRentByLicence("EX344").StartDate);
        }


        [Fact]
        public void EndRent_WhenRentExists_ThenCalculateCosts()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            scooterManagementService.AddScooter(new Scooter("EX344", 0.1, false));

            var reservationService = new ReservationService(scooterManagementService.RentedScooters);
            reservationService.RegisterRent(scooterManagementService.GetScooter("EX344"), new DateTime(2021, 11, 6, 22, 0, 0));
            var rent = reservationService.GetRentByLicence("EX344");
            //act
            double costs = reservationService.EndRent(rent, new DateTime(2021, 11, 7, 22, 0, 0));
            //assert
            Assert.Equal(144, costs);
        }

        [Fact]
        public void EndRent_WhenRentNull_ThenReturnZero()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            scooterManagementService.AddScooter(new Scooter("EX344", 0.1, false));

            var reservationService = new ReservationService(scooterManagementService.RentedScooters);
            reservationService.RegisterRent(scooterManagementService.GetScooter("EX344"), new DateTime(2021, 11, 6, 22, 0, 0));


            //act
            var rent = reservationService.GetRentByLicence("KATO");
            double costs = reservationService.EndRent(rent, new DateTime(2021, 11, 7, 22, 0, 0));
            //assert
            Assert.Equal(0, costs);
        }

        [Fact]
        public void GetCurrentCosts_WhenRentHaveEnded_ThenRentPrice()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            scooterManagementService.AddScooter(new Scooter("EX344", 0.1, false));

            var reservationService = new ReservationService(scooterManagementService.RentedScooters);
            reservationService.RegisterRent(scooterManagementService.GetScooter("EX344"), new DateTime(2021, 11, 6, 22, 0, 0));

            //act
            var rent = reservationService.GetRentByLicence("EX344");
            reservationService.EndRent(rent, new DateTime(2021, 11, 7, 22, 0, 0));
            double price = reservationService.GetCurrentCosts(rent);
            //assert
            Assert.Equal(144, price);
        }
        [Fact]
        public void GetCurrentCosts_WhenRentNotEnded_ThenDatetimeNow()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            scooterManagementService.AddScooter(new Scooter("EX344", 0.1, false));

            var reservationService = new ReservationService(scooterManagementService.RentedScooters);
            reservationService.RegisterRent(scooterManagementService.GetScooter("EX344"), new DateTime(2021, 11, 6, 22, 0, 0));

            //act
            var rent = reservationService.GetRentByLicence("EX344");
            double price = reservationService.GetCurrentCosts(rent);

            //assert
            Assert.True(0.1 > price - (DateTime.Now - rent.StartDate).TotalMinutes * rent.Scooter.Price);
        }
        [Fact]
        public void GetCurrentCosts_WhenRentNotRented_ThenZero()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            scooterManagementService.AddScooter(new Scooter("EX344", 0.1, false));
            scooterManagementService.AddScooter(new Scooter("EX345", 0.1, false));

            var reservationService = new ReservationService(scooterManagementService.RentedScooters);
            reservationService.RegisterRent(scooterManagementService.GetScooter("EX344"), new DateTime(2021, 11, 6, 22, 0, 0));

            //act
            var rent = reservationService.GetRentByLicence("EX345");
            double price = reservationService.GetCurrentCosts(rent);

            //assert
            Assert.Equal(0, price);
        }

        [Fact]
        public void GetIncomeForPeriod_WhenWayBefore_ThenZero()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            scooterManagementService.AddScooter(new Scooter("EX344", 0.1, false));

            var reservationService = new ReservationService(scooterManagementService.RentedScooters);
            reservationService.RegisterRent(scooterManagementService.GetScooter("EX344"), new DateTime(2021, 11, 5, 22, 0, 0));

            var rent = reservationService.GetRentByLicence("EX344");
            reservationService.EndRent(rent, new DateTime(2021, 11, 6, 22, 0, 0));

            //act
            var income = reservationService.GetIncomeForPeriod(new DateTime(2021, 11, 7, 0, 0, 0), new DateTime(2021, 11, 8, 0, 0, 0));

            //assert
            Assert.Equal(0, income);
        }

        [Fact]
        public void GetIncomeForPeriod_WhenStartsBeforePeriod_ThenCalc()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            scooterManagementService.AddScooter(new Scooter("EX344", 0.1, false));

            var reservationService = new ReservationService(scooterManagementService.RentedScooters);
            reservationService.RegisterRent(scooterManagementService.GetScooter("EX344"), new DateTime(2021, 11, 5, 22, 0, 0));

            var rent = reservationService.GetRentByLicence("EX344");
            reservationService.EndRent(rent, new DateTime(2021, 11, 7, 10, 0, 0));

            //act
            var income = reservationService.GetIncomeForPeriod(new DateTime(2021, 11, 7, 0, 0, 0), new DateTime(2021, 11, 8, 0, 0, 0));

            //assert
            Assert.Equal(60, income);
        }

        [Fact]
        public void GetIncomeForPeriod_WhenInsidePeriod_ThenCalc()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            scooterManagementService.AddScooter(new Scooter("EX344", 0.1, false));

            var reservationService = new ReservationService(scooterManagementService.RentedScooters);
            reservationService.RegisterRent(scooterManagementService.GetScooter("EX344"), new DateTime(2021, 11, 7, 10, 0, 0));

            var rent = reservationService.GetRentByLicence("EX344");
            reservationService.EndRent(rent, new DateTime(2021, 11, 7, 20, 0, 0));

            //act
            var income = reservationService.GetIncomeForPeriod(new DateTime(2021, 11, 7, 0, 0, 0), new DateTime(2021, 11, 8, 0, 0, 0));

            //assert
            Assert.Equal(60, income);
        }

        [Fact]
        public void GetIncomeForPeriod_WhenEndsAfterPeriod_ThenCalc()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            scooterManagementService.AddScooter(new Scooter("EX344", 0.1, false));

            var reservationService = new ReservationService(scooterManagementService.RentedScooters);
            reservationService.RegisterRent(scooterManagementService.GetScooter("EX344"), new DateTime(2021, 11, 7, 14, 0, 0));

            var rent = reservationService.GetRentByLicence("EX344");
            reservationService.EndRent(rent, new DateTime(2021, 11, 8, 10, 0, 0));

            //act
            var income = reservationService.GetIncomeForPeriod(new DateTime(2021, 11, 7, 0, 0, 0), new DateTime(2021, 11, 8, 0, 0, 0));

            //assert
            Assert.Equal(60, income);
        }

        [Fact]
        public void GetIncomeForPeriod_WhenEndIndefined_ThenCalc()
        {
            //arrange
            var scooterManagementService = new ScooterManagementService();
            scooterManagementService.AddScooter(new Scooter("EX344", 0.1, false));

            var reservationService = new ReservationService(scooterManagementService.RentedScooters);
            reservationService.RegisterRent(scooterManagementService.GetScooter("EX344"), new DateTime(2021, 11, 7, 14, 0, 0));


            //act
            var income = reservationService.GetIncomeForPeriod(new DateTime(2021, 11, 7, 0, 0, 0), new DateTime(2021, 11, 8, 0, 0, 0));

            //assert
            Assert.Equal(60, income);
        }

    }
}
