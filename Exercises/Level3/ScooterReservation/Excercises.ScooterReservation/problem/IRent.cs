using System;

namespace Excercises.ScooterReservation
{
    /// <summary>
    /// This is object of issued rents of scooters.
    /// Note that no rent can be deleted for full company income history.
    /// Every rent is unque by its scooter and time period
    /// </summary>
    public interface IRent
    {
        /// <summary>
        /// Rented Scooter
        /// </summary>
        IScooter Scooter { get; }

        /// <summary>
        /// Rents price that has been gathered for income
        /// Note: scooters price can change after rent has ended
        /// </summary>
        double? Price { get; set; }

        /// <summary>
        /// Rents start date witch is mandatory
        /// from the rents begining.
        /// </summary>
        DateTime StartDate { get; }

        /// <summary>
        /// Rents end date if known.
        /// If rents end date is in past rent has been ended.
        /// After seting end date it cannot be changed.
        /// </summary>
        DateTime? EndDate { get; set; }
    }
}
