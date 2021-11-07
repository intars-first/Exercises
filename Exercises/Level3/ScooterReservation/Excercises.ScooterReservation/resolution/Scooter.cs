using System;
using System.Collections.Generic;
using System.Text;

namespace Excercises.ScooterReservation
{
    public class Scooter : IScooter
    {
        public Scooter(string registrationNumber, double price, bool isDamaged)
        {
            registrationNumberVar = registrationNumber;
            Price = price;
            IsDamaged = isDamaged;
        }

        private string registrationNumberVar;
        public string RegistrationNumber
        {
            get { return registrationNumberVar; }
            set { }
        }

        public double Price { get; set; }
        public bool IsDamaged { get; set; }



    }
}
