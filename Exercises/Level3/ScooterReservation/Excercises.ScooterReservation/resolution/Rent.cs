using System;
using System.Collections.Generic;
using System.Text;

namespace Excercises.ScooterReservation
{
    public class Rent : IRent
    {
        public Rent(IScooter scooter, DateTime startDate)
        {
            Scooter = scooter;
            StartDate = startDate;
            Price = scooter.Price ;
            endDate = null;
        }
        public IScooter Scooter { get; }

        public double? Price { get; set; }

        public DateTime StartDate { get; }


        private DateTime? endDate;

        public DateTime? EndDate
        {
            get { return endDate; }
            set
            {
                if (value == null) return;
                if (endDate != null) return;
                endDate = value;
            }
        }

    }
}
