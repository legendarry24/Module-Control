using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    class PassengerRepository : IPassengerRepository
    {
        private List<Passenger> _passengers;

        public void Insert(Passenger passenger)
        {
            _passengers.Add(passenger);
        }

        public void Delete(string passport)
        {
            for (int i = 0; i < _passengers.Count; i++)
            {
                if (_passengers[i].Passport == passport)
                {
                    _passengers.Remove(_passengers[i]);
                }
            }
        }

        public Passenger Select(int id)
        {
            if (id < 0 || id >= _passengers.Count)
                return null;
            return _passengers[id];
        }

        public void Update(int id, Passenger newPassenger, Flight anotherFlight = null)
        {
            // passenger can choose another flight 
            if (anotherFlight != null)
                newPassenger.FlightNumber = anotherFlight.Number;
            _passengers[id] = newPassenger;
        }

        public PassengerRepository()
        {
            _passengers = new List<Passenger>();
        }
    }
}
