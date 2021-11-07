namespace Excercises.ScooterReservation
{
    /// <summary>
    /// This is scooters models interface.
    /// Scooters can be mannaged only inside scooters mannagment service.
    /// It is not allowed to manipulate scooters data 
    /// outside scooters mannagment service
    /// </summary>
    public interface IScooter
    {
        /// <summary>
        /// Scooters registration number unque to every scooter
        /// After scooter creation it cannot be changed
        /// </summary>
        string RegistrationNumber { get; set; }

        /// <summary>
        /// Scooters rent price in minutes
        /// </summary>
        double Price { get; set; }

        /// <summary>
        /// Is damaged holding if scooter need tehnical fixes
        /// </summary>
        bool IsDamaged { get; set; }
    }
}
