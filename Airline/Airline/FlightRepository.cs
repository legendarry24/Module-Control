using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    class FlightRepository : IFlightRepository
    {
        private List<Flight> _flights;

        public void Insert(Flight flight)
        {
            flight.Number = _flights.Count + 1;
            _flights.Add(flight);
        }

        public void Delete(int number)
        {
            _flights.RemoveAt(number);
        }

        public Flight Select(int number)
        {
            if (number < 0 || number >= _flights.Count)
                return null;
            return _flights[number];
        }

        public void Update(int numberOfOld, Flight newFlight)
        {
            _flights[numberOfOld] = newFlight;      
        }

        public FlightRepository()
        {
            _flights = new List<Flight>();
        }
    }
}
