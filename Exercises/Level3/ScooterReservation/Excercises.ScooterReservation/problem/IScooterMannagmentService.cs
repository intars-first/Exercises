using System.Collections.Generic;

namespace Excercises.ScooterReservation
{
    public interface IScooterMannagmentService
    {
        /// <summary>
        /// Add a new scooter to companies ownership.
        /// Note that it is not possible to have 2 scooters
        /// with the same registration number.
        /// Throw exception in that case
        /// </summary>
        /// <param name="scooter">Scooter to add</param>
        void AddScooter(IScooter scooter);

        /// <summary>
        /// Remove scooter from actively aviable scooters.
        /// Note that scooter cannot be removed while it is being rented.
        /// </summary>
        /// <param name="registratonNumber">
        /// Registration number of scooter to remove
        /// </param>
        void RemoveScooter(string registratonNumber);

        /// <summary>
        /// Mark scooter as damaged, meaning it needs to have repairs and
        /// cannot be used for renting.
        /// Rented scooters cannot be marked as damaged
        /// </summary>
        /// <param name="registratonNumber">
        /// Registration number of scooter to mark damaged
        /// </param>
        void MarkDamaged(string registratonNumber);

        /// <summary>
        /// Change rent price of scooter.
        /// Note that price cannot be changed while scooter is rented
        /// </summary>
        /// <param name="registratonNumber">
        /// Registration number of scooter to change price
        /// </param>
        /// <param name="newPrice">New price per minute of rent</param>
        void ChangePrice(string registratonNumber, double newPrice);

        /// <summary>
        /// Returns scooter by its registration number,
        /// or null in case scooter was not fount.
        /// </summary>
        /// <param name="registrationNumber">Scooters registration number</param>
        /// <returns></returns>
        IScooter GetScooter(string registrationNumber);

        /// <summary>
        /// Return a list of all aviable scooters.
        /// Note that scooters that are damaged or currently rented
        /// are not aviable
        /// </summary>
        /// <returns></returns>
        IList<IScooter> GetAllAviableScooters();
    }
}
