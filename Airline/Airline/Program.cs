using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    class Program
    {
        static void Main(string[] args)
        {
            IFlightRepository flightRepository = FlightManager.GetFlightRepository;
            IPassengerRepository passengerRepository = FlightManager.GetPassengerRepository;
            FlightManager flightManager = FlightManager.GetFlightManager;

            #region Source information

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
                Price = flightManager.SetPrice(10)
            };
            flightRepository.Insert(flight);

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
                Price = flightManager.SetPrice(35)
            };
            flightRepository.Insert(flight2);

            var passenger = new Passenger(flightRepository.Select(1))
            {
                FirstName = "Alex",
                SecondName = "Morgan",
                Nationality = "American",
                DateOfBirthday = DateTime.Parse("1987.07.24"),
                Passport = "QT11342",
                IsMale = true,
                ClassesOfService = ClassesOfService.FirstClass
            };
            passengerRepository.Insert(passenger);

            var passenger2 = new Passenger(flightRepository.Select(0))
            {
                FirstName = "Natasha",
                SecondName = "Romanova",
                Nationality = "Russian",
                DateOfBirthday = DateTime.Parse("1990.03.11"),
                Passport = "NT337842",
                IsMale = false,
                ClassesOfService = ClassesOfService.EconomyClass
            };
            passengerRepository.Insert(passenger2);

            var passenger3 = new Passenger(flightRepository.Select(0))
            {
                FirstName = "Ivan",
                SecondName = "Antonov",
                Nationality = "Ukrainian",
                DateOfBirthday = DateTime.Parse("1991.11.13"),
                Passport = "MT478425",
                IsMale = true,
                ClassesOfService = ClassesOfService.BusinessClass
            };
            passengerRepository.Insert(passenger3);

            #endregion

            #region Test

            //passengerRepository.Delete("NT337842");
            //Console.WriteLine(passengerRepository.Select(1));
            //passengerRepository.Update(1, passenger);
            //flightRepository.Update(1, flight);
            //flightRepository.Delete(1); // remove second flight
            //now first passenger will fly the first flight
            //passengerRepository.Update(0, passenger, flightRepository.Select(0)); 

            //flightManager.SelectAllFlights();
            //flightManager.Pricelist();
            //flightManager.SelectAllPassengers();
            //flightManager.SearchByFlightNumber(1);
            //flightManager.SearchByPrice(30m, 70m);
            //flightManager.SearchByName("Ivan");
            //flightManager.SearchBySecondName("Morgan");
            //flightManager.SearchByPassport("NT337842");
            //flightManager.SearchByDepartureDestination("LA");
            //flightManager.SearchByArrivalDestination("Kharkov");

            //Console.Write("City or Port: ");
            //string cityOrPort = Console.ReadLine();
            //Console.Write("Date and time: ");
            //DateTime dateTime = DateTime.Parse(Console.ReadLine());
            //Console.Write("Gate: ");
            //var gate = (Gate)Enum.Parse(typeof(Gate), Console.ReadLine());
            //Console.Write("Terminal: ");
            //var terminal = (Terminal)Enum.Parse(typeof(Terminal), Console.ReadLine());
            //Console.Write("Flight status: ");
            //var flightStatus = (FlightStatus)Enum.Parse(typeof(FlightStatus), Console.ReadLine());

            #endregion

            Console.WriteLine($"{new string('<', 73)}\n{new string('-', 30)}The Airline X{new string('-', 30)}");
            while (true)
            {
                Console.WriteLine($"\r{new string('>', 73)}\nWhat do you want?\n" +
                                   "Press 1 to view some airline information\n" +
                                   "Press 2 to edit some airline information\n" +
                                   $"Press Escape to Exit\n{new string('-', 73)}");
                ConsoleKeyInfo answer = Console.ReadKey();
                string input;
                if (answer.Key == ConsoleKey.Escape)
                    break;
                if (answer.Key == ConsoleKey.D1)
                {
                    Console.WriteLine("\rPress 1 to view all the available flights\n" +
                                        "Press 2 to view all the flights pricelist\n" +
                                        "Press 3 to view all the passengers\n" +
                                        "Press 4 to get to the search menu\n" +
                                        "Press another key to return to the start menu\n" +
                                        new string('-', 73));
                    answer = Console.ReadKey();
                    switch (answer.Key)
                    {
                        case ConsoleKey.D1:
                            flightManager.SelectAllFlights();
                            break;
                        case ConsoleKey.D2:
                            flightManager.Pricelist();
                            break;
                        case ConsoleKey.D3:
                            flightManager.SelectAllPassengers();
                            break;
                        case ConsoleKey.D4:
                            Console.WriteLine("\rPress 1 to search by the flight number\n" +
                                                "Press 2 to search by the price of flight\n" +
                                                "Press 3 to search by the passenger's first name\n" +
                                                "Press 4 to search by the passenger's second name\n" +
                                                "Press 5 to search by the passenger's passport\n" +
                                                "Press 6 to search by the departure destination\n" +
                                                "Press 7 to search by the arrival destination\n" +
                                                "Press another key to return to the start menu\n" +
                                                new string('-', 73));
                            answer = Console.ReadKey();
                            switch (answer.Key)
                            {
                                case ConsoleKey.D1:
                                    Console.Write("\rFlight number: ");
                                    int number = int.Parse(Console.ReadLine());
                                    //Move the cursor to the line above 
                                    Console.SetCursorPosition(0, Console.CursorTop - 1);                                    
                                    flightManager.SearchByFlightNumber(number);
                                    break;
                                case ConsoleKey.D2:
                                    Console.Write("\rMinimum price: ");
                                    decimal min = decimal.Parse(Console.ReadLine());
                                    Console.Write("Maximum price: ");
                                    decimal max = decimal.Parse(Console.ReadLine());
                                    flightManager.SearchByPrice(min, max);
                                    break;
                                case ConsoleKey.D3:
                                    Console.Write("\rFirst name: ");
                                    input = Console.ReadLine();
                                    flightManager.SearchByName(input);
                                    break;
                                case ConsoleKey.D4:
                                    Console.Write("\rSecond name: ");
                                    input = Console.ReadLine();
                                    flightManager.SearchBySecondName(input);
                                    break;
                                case ConsoleKey.D5:
                                    Console.Write("\rPassport: ");
                                    input = Console.ReadLine();
                                    flightManager.SearchByPassport(input);
                                    break;
                                case ConsoleKey.D6:
                                    Console.Write("\rDeparture destination: ");
                                    input = Console.ReadLine();
                                    flightManager.SearchByDepartureDestination(input);
                                    break;
                                case ConsoleKey.D7:
                                    Console.Write("\rArrival destination: ");
                                    input = Console.ReadLine();
                                    flightManager.SearchByArrivalDestination(input);
                                    break;
                            }
                            break;
                    }
                }
                else if (answer.Key == ConsoleKey.D2)
                {
                    Console.WriteLine("\rPress 1 to edit information about the flights\n" +
                                        "Press 2 to edit information about the passengers\n" +
                                        new string('-', 73));
                    answer = Console.ReadKey();
                    switch (answer.Key)
                    {
                        case ConsoleKey.D1:
                            Console.WriteLine("\rPress 1 to add new flights\n" +
                                                "Press 2 to change information about the flight\n" +
                                                "Press 3 to delete the flight\n" +
                                                new string('-', 73));
                            answer = Console.ReadKey();
                            switch (answer.Key)
                            {
                                case ConsoleKey.D1:
                                   //HERE
                                    break;
                                case ConsoleKey.D2:
                                    
                                    break;
                                case ConsoleKey.D3:
                                    
                                    break;
                            }
                            break;
                        case ConsoleKey.D2:
                            Console.WriteLine("\rPress 1 to add new passengers\n" +
                                                "Press 2 to change information about the passenger\n" +
                                                "Press 3 to delete the passenger\n" +
                                                new string('-', 73));
                            answer = Console.ReadKey();
                            switch (answer.Key)
                            {
                                case ConsoleKey.D1:
                                    
                                    break;
                                case ConsoleKey.D2:

                                    break;
                                case ConsoleKey.D3:

                                    break;
                            }
                            break;
                    }
                }
            }
        }
    }
}
