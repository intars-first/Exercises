using System;
using System.Collections.Generic;
using System.Text;

namespace Excercises.ScooterReservation
{
    public class ScooterManagementService : IScooterMannagmentService
    {
        public ScooterManagementService()
        {
            ScooterFleet = new Dictionary<string, IScooter>();
            RentedScooters = new Dictionary<string, IScooter>();
        }

        public Dictionary<string, IScooter> ScooterFleet { get; private set; }
        public Dictionary<string, IScooter> RentedScooters { get; private set; }

        public void AddScooter(IScooter scooter)
        {
            ScooterFleet.Add(scooter.RegistrationNumber, scooter);
        }

        public void RemoveScooter(string registratonNumber)
        {
            if (RentedScooters.ContainsKey(registratonNumber)) return;
            ScooterFleet.Remove(registratonNumber);
        }

        public void MarkDamaged(string registratonNumber)
        {
            if (RentedScooters.ContainsKey(registratonNumber)) return;

            if (ScooterFleet.TryGetValue(registratonNumber, out IScooter scooter))
            {
                scooter.IsDamaged = true;
            }

        }

        public void ChangePrice(string registratonNumber, double newPrice)
        {
            if (RentedScooters.ContainsKey(registratonNumber)) return;

            if (ScooterFleet.TryGetValue(registratonNumber, out IScooter scooter))
            {
                scooter.Price = newPrice;
            }
        }

        public IScooter GetScooter(string registrationNumber)
        {

            if (ScooterFleet.TryGetValue(registrationNumber, out IScooter scooter))
            {
                return scooter;
            }
            return null;
        }


        public IList<IScooter> GetAllAviableScooters()
        {
            IList<IScooter> scooters = new List<IScooter>();

            foreach (KeyValuePair<string, IScooter> record in ScooterFleet)
            {
                if (!record.Value.IsDamaged && !RentedScooters.ContainsKey(record.Key))
                {
                    scooters.Add(record.Value);
                }

            }

            return scooters;
        }







    }
}
