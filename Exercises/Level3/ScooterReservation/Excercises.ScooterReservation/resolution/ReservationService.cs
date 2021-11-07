using System;
using System.Collections.Generic;
using System.Text;

namespace Excercises.ScooterReservation
{
    public class ReservationService : IReservationService
    {
        private Dictionary<string, IScooter> RentedScooters { get; set; }
        private List<Rent> RentOrders { get; set; }

        public ReservationService(Dictionary<string, IScooter> rentedScooters)
        {
            RentedScooters = rentedScooters;
            RentOrders = new List<Rent>();
        }

        public IRent GetRentByLicence(string registrationNumber)
        {
            foreach (Rent rent in RentOrders)
            {
                if (rent.Scooter.RegistrationNumber == registrationNumber) return rent;
            }
            return null;
        }


        public void RegisterRent(IScooter scooter, DateTime startDate)
        {
            if (scooter == null) return;

            foreach (Rent rent in RentOrders)
            {
                if (rent.Scooter.RegistrationNumber == scooter.RegistrationNumber)
                {
                    if (rent.EndDate == null || rent.EndDate > startDate) return;
                }
            }

            if (scooter.IsDamaged) return;

            RentedScooters.Add(scooter.RegistrationNumber, scooter);
            RentOrders.Add(new Rent(scooter, startDate));

        }

        public double EndRent(IRent rent, DateTime endDate)
        {

            if (rent != null)
            {
                rent.EndDate = endDate;
                rent.Price = rent.Scooter.Price;
                return (endDate - rent.StartDate).TotalMinutes * rent.Scooter.Price;
            }

            return 0;
        }

        public double GetCurrentCosts(IRent rent)
        {
            if (rent == null) return 0;

            if (rent.EndDate != null) return ((DateTime)rent.EndDate - rent.StartDate).TotalMinutes * (double)rent.Price;

            return (DateTime.Now - rent.StartDate).TotalMinutes * (double)rent.Price;

        }

        public double GetIncomeForPeriod(DateTime from, DateTime till)
        {
            double income = 0;
            foreach (Rent rent in RentOrders)
            {

                var incomeFrom = new DateTime(Math.Max(rent.StartDate.Ticks, from.Ticks));

                var incomeTill = till;
                if (rent.EndDate != null) incomeTill = (DateTime)rent.EndDate;
                incomeTill = new DateTime(Math.Min(incomeTill.Ticks, till.Ticks));

                if (incomeFrom < incomeTill)
                    income += (incomeTill - incomeFrom).TotalMinutes * (double)rent.Price;

            }

            return income;

        }


    }
}
