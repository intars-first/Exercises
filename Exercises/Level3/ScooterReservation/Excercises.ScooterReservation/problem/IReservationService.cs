using System;

namespace Excercises.ScooterReservation
{
    public interface IReservationService
    {
        /// <summary>
        /// Crete new rent validating if company is currntly possible to 
        /// rent this scooter at the given time period.
        /// </summary>
        /// <param name="scooter">Scooter to rent</param>
        /// <param name="startDate">Start date of rent</param>
        void RegisterRent(IScooter scooter, DateTime startDate);

        /// <summary>
        /// Ends rent or schedules end of rent calculating costs.
        /// </summary>
        /// <param name="rent">Rent to end</param>
        /// <param name="endDate">Rents end date.</param>
        /// <returns>
        /// Price that customer has to pay for rent period
        /// </returns>
        double EndRent(IRent rent, DateTime endDate);

        /// <summary>
        /// Returns calculated rents costs to this moment
        /// </summary>
        /// <param name="rent">Rent to calculate costs</param>
        /// <returns>Calculated costs to this moment</returns>
        double GetCurrentCosts(IRent rent);

        /// <summary>
        /// Calculat companies income in given time period.
        /// Note: That all active/ended rents count from witch
        /// company is going to recive money in given time period.
        /// Meaning unfinished rents also has to be counted in for period
        /// witch is inside given period
        /// </summary>
        /// <param name="from">
        /// Date and time from to calculate income
        /// </param>
        /// <param name="till">
        /// Date and time till to calculate income
        /// </param>
        /// <returns>Calculated income in given time period</returns>
        double GetIncomeForPeriod(DateTime from, DateTime till);
    }
}
