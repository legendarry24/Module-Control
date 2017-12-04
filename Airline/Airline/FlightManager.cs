using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    class FlightManager
    {
        private static IFlightRepository _flightRepository;
        private static IPassengerRepository _passengerRepository;

        static FlightManager()
        {
            GetFlightManager = new FlightManager();
            _flightRepository = new FlightRepository();
            _passengerRepository = new PassengerRepository();
        }

        private FlightManager()
        { }

        public static FlightManager GetFlightManager { get; }

        public static IFlightRepository GetFlightRepository => _flightRepository;

        public static IPassengerRepository GetPassengerRepository => _passengerRepository;

        public void SelectAllFlights()
        {
            for (int i = 0; _flightRepository.Select(i) != null; i++)
            {
                Console.WriteLine($"\r{_flightRepository.Select(i)}\n{new string('-', 43)}");
            }           
        }

        public void SelectAllPassengers()
        {
            for (int i = 0; _passengerRepository.Select(i) != null; i++)
            {
                Console.WriteLine($"\r{_passengerRepository.Select(i)}\n{new string('-', 43)}");
            }
        }

        public decimal[] SetPrice(decimal price)
        {
            return new [] { price, price * 1.2m, price * 1.5m, price * 1.8m };
        }

        public void Pricelist()
        {
            var names = Enum.GetNames(typeof(ClassesOfService));
            Console.WriteLine($"\r{new string('-', 73)}\nPricelist:\n\t\t {names[0]}  {names[1]}  {names[2]}  {names[3]}");
            for (int i = 0; _flightRepository.Select(i) != null; i++)
            {
                var prices = _flightRepository.Select(i).Price;
                if (prices != null)
                {
                    Console.WriteLine($"Flight number: {_flightRepository.Select(i).Number}\t   {prices[0]}\t\t {prices[1]}\t\t{prices[2]}\t    {prices[3]}");
                }
            }
            Console.WriteLine(new string('-', 73));
        }

        public void SearchByFlightNumber(int number)
        {
            Console.WriteLine(_flightRepository.Select(number - 1));
            int passengersCount = 1;
            for (int i = 0; _passengerRepository.Select(i) != null; i++)
            {
                if (_passengerRepository.Select(i).FlightNumber == number)
                {
                    Console.WriteLine($"Passenger {passengersCount++}:\n{_passengerRepository.Select(i)}");
                }
            }
        }

        public void SearchByPrice(decimal minPrice, decimal maxPrice)
        {
            for (int i = 0; _flightRepository.Select(i) != null; i++)
            {
                if (_flightRepository.Select(i).Price[0] >= minPrice && _flightRepository.Select(i).Price[0] <= maxPrice)
                {
                    Console.WriteLine(_flightRepository.Select(i));
                }
            }
        }

        public void SearchByName(string firstName)
        {
            for (int i = 0; _passengerRepository.Select(i) != null; i++)
            {
                if (_passengerRepository.Select(i).FirstName == firstName)
                {
                    Console.WriteLine($"{_passengerRepository.Select(i)}\n{new string('-', 43)}");
                }
            }
        }

        public void SearchBySecondName(string secondName)
        {
            for (int i = 0; _passengerRepository.Select(i) != null; i++)
            {
                if (_passengerRepository.Select(i).SecondName == secondName)
                {
                    Console.WriteLine($"{_passengerRepository.Select(i)}\n{new string('-', 43)}");
                }
            }
        }

        public void SearchByPassport(string passport)
        {
            for (int i = 0; _passengerRepository.Select(i) != null; i++)
            {
                if (_passengerRepository.Select(i).Passport == passport)
                {
                    Console.WriteLine($"{_passengerRepository.Select(i)}\n{new string('-', 43)}");
                }
            }
        }

        public void SearchByArrivalDestination(string destination)
        {
            for (int i = 0; _flightRepository.Select(i) != null; i++)
            {
                if (_flightRepository.Select(i).Arrival.CityOrPort == destination)
                {
                    Console.WriteLine($"{_flightRepository.Select(i)}\n{new string('-', 43)}");
                }
            }
        }

        public void SearchByDepartureDestination(string destination)
        {
            for (int i = 0; _flightRepository.Select(i) != null; i++)
            {
                if (_flightRepository.Select(i).Departure.CityOrPort == destination)
                {
                    Console.WriteLine($"{_flightRepository.Select(i)}\n{new string('-', 43)}");
                }
            }
        }
    }
}
