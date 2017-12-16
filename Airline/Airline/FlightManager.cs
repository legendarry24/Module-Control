using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    class FlightManager
    {
        private static FlightManager _flightManager;
        private static IFlightRepository _flightRepository;
        private static IPassengerRepository _passengerRepository;

        static FlightManager()
        {
            _flightManager = new FlightManager();
            _flightRepository = new FlightRepository();
            _passengerRepository = new PassengerRepository();
        }

        private FlightManager()
        { }

        public static FlightManager GetFlightManager 
        {
            get
            {
                //set sourse information
                _flightManager.AddFlights();
                _flightManager.AddPassengers();
                return _flightManager;
            }          
        }

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

        public Flight InputNewFlight()
        {
            try
            {
                Console.Write("\rDeparture destination: ");
                string departure = Console.ReadLine();
                Console.Write("Date and time: ");
                DateTime dateTime = DateTime.Parse(Console.ReadLine());
                Console.Write("Gate: ");
                var gate = (Gate)Enum.Parse(typeof(Gate), Console.ReadLine());
                Console.Write("Terminal: ");
                var terminal = (Terminal)Enum.Parse(typeof(Terminal), Console.ReadLine());

                Console.Write("Arrival  destination: ");
                string arrival = Console.ReadLine();
                Console.Write("Date and time: ");
                DateTime arrivalDateTimedateTime = DateTime.Parse(Console.ReadLine());
                Console.Write("Gate: ");
                var arrivalGate = (Gate)Enum.Parse(typeof(Gate), Console.ReadLine());
                Console.Write("Terminal: ");
                var arrivalTerminal = (Terminal)Enum.Parse(typeof(Terminal), Console.ReadLine());

                Console.Write("Flight status: ");
                var flightStatus = (FlightStatus)Enum.Parse(typeof(FlightStatus), Console.ReadLine());
                Console.Write("Price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                var flight = new Flight
                {
                    Departure = new FlightDeparture
                    {
                        CityOrPort = departure,
                        DateTime = dateTime,
                        Gate = gate,
                        Terminal = terminal
                    },
                    Arrival = new FlightArrival
                    {
                        CityOrPort = arrival,
                        DateTime = arrivalDateTimedateTime,
                        Gate = arrivalGate,
                        Terminal = arrivalTerminal
                    },
                    FlightStatus = flightStatus,
                    Price = SetPrice(price)
                };

                return flight;
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong date and time or price format.\nValid format for date and time: YYYY.MM.DD HH:MM:SS");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Wrong argument. Please check а list of valid arguments");
            }

            return null;
        }

        public void InputNewFlights()
        {
            string answer;
            do
            {              
                _flightRepository.Insert(InputNewFlight());
                Console.WriteLine("Information successfully chenged");
                Console.WriteLine("Stop adding flights? Type \"Yes\" to stop or type anything else to proceed");
                answer = Console.ReadLine();
            } while (answer != "Yes");            
        }       

        public Passenger InputNewPassenger()
        {
            try
            {
                Console.Write("\rFirstName: ");
                string name = Console.ReadLine();
                Console.Write("SecondName: ");
                string secondName = Console.ReadLine();
                Console.Write("Nationality: ");
                string nationality = Console.ReadLine();
                Console.Write("Date of Birthday: ");
                DateTime dateTime = DateTime.Parse(Console.ReadLine());
                Console.Write("Passport: ");
                string passport = Console.ReadLine();
                Console.Write("Sex: ");
                string sex = Console.ReadLine();
                if (sex != "Male" && sex != "Female")
                    throw new ArgumentException();

                Console.Write("Сlass: ");
                var classesOfService = (ClassesOfService)Enum.Parse(typeof(ClassesOfService), Console.ReadLine());
                Console.Write("Number of flight: ");
                //if you enter not existing number, passenger won't have flight
                int number = int.Parse(Console.ReadLine());
                Flight flight = null;
                for (int i = 0; _flightRepository.Select(i) != null; i++)
                {
                    if (_flightRepository.Select(i).Number == number)
                    {
                        flight = _flightRepository.Select(i);
                        break;
                    }
                }
                             
                var passenger = new Passenger(flight)
                {
                    FirstName = name,
                    SecondName = secondName,
                    Nationality = nationality,
                    DateOfBirthday = dateTime,
                    Passport = passport,
                    IsMale = sex == "Male",
                    ClassesOfService = classesOfService
                };
                
                return passenger;
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong date and time or number format.\nValid format for date and time: YYYY.MM.DD HH:MM:SS");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Wrong argument. Please check а list of valid arguments");
            }

            return null;
        }

        public void InputNewPassengers()
        {
            string answer;
            do
            {
                _passengerRepository.Insert(InputNewPassenger());
                Console.WriteLine("Information successfully chenged");
                Console.WriteLine("Stop adding passengers? Type \"Yes\" to stop or type anything else to proceed");
                answer = Console.ReadLine();
            } while (answer != "Yes");
        }

        public void UpdatePassengerInfo() 
        {
            Console.Write("\rFirstName: ");
            string name = Console.ReadLine();
            Console.Write("SecondName: ");
            string secondName = Console.ReadLine();

            for (int i = 0; _passengerRepository.Select(i) != null; i++)
            {
                if (_passengerRepository.Select(i).FirstName == name && 
                    _passengerRepository.Select(i).SecondName == secondName)
                {
                    Console.WriteLine($"Current info:\n{_passengerRepository.Select(i)}\n{new string('-', 43)}");
                    var passenger = InputNewPassenger();
                    _passengerRepository.Update(i, passenger);
                    Console.WriteLine("Information successfully chenged");
                    return;
                }
            }
            Console.WriteLine("Passenger not found");           
        }

        public void UpdateFlightInfo() 
        {
            Console.Write("\rNumber of flight: ");
            int number = int.Parse(Console.ReadLine()) - 1;
            if (_flightRepository.Select(number) == null)
            {
                Console.WriteLine("Flight not found");
            }
            else
            {
                Console.WriteLine($"Current info:\n{_flightRepository.Select(number)}\n{new string('-', 43)}");
                var flight = InputNewFlight();
                _flightRepository.Update(number, flight);
                Console.WriteLine("Information successfully chenged");
            }          
        }

        public void DeleteFlight()
        {
            Console.Write("\rNumber of flight: ");
            int number = int.Parse(Console.ReadLine()) - 1;
            if (_flightRepository.Select(number) == null)
            {
                Console.WriteLine("Flight not found");
            }
            else
            {
                _flightRepository.Delete(number);
                // set null to FlightNumber for each passenger from deleted flight
                for (int i = 0; _passengerRepository.Select(i) != null; i++)
                    if (_passengerRepository.Select(i).FlightNumber == number + 1)
                        _passengerRepository.Select(i).FlightNumber = null;

                Console.WriteLine("Information successfully chenged");
            }
        }

        public void DeletePassenger()
        {
            Console.Write("\rPassport: ");
            string passport = Console.ReadLine();
            _passengerRepository.Delete(passport);
        }

        public void SearchMenu()
        {
            ConsoleKeyInfo answer = Console.ReadKey();
            string input;

            Console.WriteLine("\rPress 1 to search by the flight number\n" +
                              "Press 2 to search by the price of flight\n" +
                              "Press 3 to search by the passenger's first name\n" +
                              "Press 4 to search by the passenger's second name\n" +
                              "Press 5 to search by the passenger's passport\n" +
                              "Press 6 to search by the departure destination\n" +
                              "Press 7 to search by the arrival destination\n" +
                              "Press another key to return to the start menu\n" +
                              new string('-', 73));
            
            switch (answer.Key)
            {
                case ConsoleKey.D1:
                    Console.Write("\rFlight number: ");
                    int number;
                    int.TryParse(Console.ReadLine(), out number);
                    //Move the cursor to the line above 
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    SearchByFlightNumber(number);
                    break;
                case ConsoleKey.D2:
                    Console.Write("\rMinimum price: ");
                    decimal min;
                    decimal.TryParse(Console.ReadLine(), out min);
                    Console.Write("Maximum price: ");
                    decimal max;
                    decimal.TryParse(Console.ReadLine(), out max);
                    SearchByPrice(min, max);
                    break;
                case ConsoleKey.D3:
                    Console.Write("\rFirst name: ");
                    input = Console.ReadLine();
                    SearchByName(input);
                    break;
                case ConsoleKey.D4:
                    Console.Write("\rSecond name: ");
                    input = Console.ReadLine();
                    SearchBySecondName(input);
                    break;
                case ConsoleKey.D5:
                    Console.Write("\rPassport: ");
                    input = Console.ReadLine();
                    SearchByPassport(input);
                    break;
                case ConsoleKey.D6:
                    Console.Write("\rDeparture destination: ");
                    input = Console.ReadLine();
                    SearchByDepartureDestination(input);
                    break;
                case ConsoleKey.D7:
                    Console.Write("\rArrival destination: ");
                    input = Console.ReadLine();
                    SearchByArrivalDestination(input);
                    break;
            }
        }

        public void EditFlightInfo()
        {
            ConsoleKeyInfo answer = Console.ReadKey();

            Console.WriteLine("\rPress 1 to add new flights\n" +
                              "Press 2 to change information about the flight\n" +
                              "Press 3 to delete the flight\n" +
                              new string('-', 73));
            switch (answer.Key)
            {
                case ConsoleKey.D1:
                    InputNewFlights();
                    break;
                case ConsoleKey.D2:
                    UpdateFlightInfo();
                    break;
                case ConsoleKey.D3:
                    DeleteFlight();
                    break;
            }
        }

        public void EditPassengerInfo()
        {
            ConsoleKeyInfo answer = Console.ReadKey();

            Console.WriteLine("\rPress 1 to add new passengers\n" +
                              "Press 2 to change information about the passenger\n" +
                              "Press 3 to delete the passenger\n" +
                              new string('-', 73));
            switch (answer.Key)
            {
                case ConsoleKey.D1:
                    InputNewPassengers();
                    break;
                case ConsoleKey.D2:
                    UpdatePassengerInfo();
                    break;
                case ConsoleKey.D3:
                    DeletePassenger();
                    break;
            }
        }

        private void AddFlights()
        {
            var flight = new Flight
            {
                Departure = new FlightDeparture
                {
                    CityOrPort = "Kiev",
                    DateTime = DateTime.Parse("2017.11.30 14:50:00"),
                    Gate = Gate.JetBridge,
                    Terminal = Terminal.First
                },
                Arrival = new FlightArrival
                {
                    CityOrPort = "Kharkov",
                    DateTime = DateTime.Parse("2017.11.30 19:24:39"),
                    Gate = Gate.Airstair,
                    Terminal = Terminal.Second
                },
                FlightStatus = FlightStatus.Delayed,
                Price = SetPrice(10)
            };
            _flightRepository.Insert(flight);

            var flight2 = new Flight
            {
                Departure = new FlightDeparture
                {
                    CityOrPort = "LA",
                    DateTime = DateTime.Parse("2017.12.30 10:25:47"),
                    Gate = Gate.JetBridge,
                    Terminal = Terminal.Second
                },
                Arrival = new FlightArrival
                {
                    CityOrPort = "NYC",
                    DateTime = DateTime.Parse("2017.12.31 00:45:15"),
                    Gate = Gate.JetBridge,
                    Terminal = Terminal.First
                },
                FlightStatus = FlightStatus.CheckIn,
                Price = SetPrice(35)
            };
            _flightRepository.Insert(flight2);
        }

        private void AddPassengers()
        {
            var passenger = new Passenger(_flightRepository.Select(1))
            {
                FirstName = "Alex",
                SecondName = "Morgan",
                Nationality = "American",
                DateOfBirthday = DateTime.Parse("1987.07.24"),
                Passport = "QT11342",
                IsMale = true,
                ClassesOfService = ClassesOfService.FirstClass
            };
            _passengerRepository.Insert(passenger);

            var passenger2 = new Passenger(_flightRepository.Select(0))
            {
                FirstName = "Natasha",
                SecondName = "Romanova",
                Nationality = "Russian",
                DateOfBirthday = DateTime.Parse("1990.03.11"),
                Passport = "NT337842",
                IsMale = false,
                ClassesOfService = ClassesOfService.EconomyClass
            };
            _passengerRepository.Insert(passenger2);

            var passenger3 = new Passenger(_flightRepository.Select(0))
            {
                FirstName = "Ivan",
                SecondName = "Antonov",
                Nationality = "Ukrainian",
                DateOfBirthday = DateTime.Parse("1991.11.13"),
                Passport = "MT478425",
                IsMale = true,
                ClassesOfService = ClassesOfService.BusinessClass
            };
            _passengerRepository.Insert(passenger3);
        }
    }
}
