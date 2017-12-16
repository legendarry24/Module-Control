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
            FlightManager flightManager = FlightManager.GetFlightManager;

            Console.WriteLine($"{new string('<', 73)}\n{new string('-', 30)}The Airline X{new string('-', 30)}");

            while (true)
            {
                Console.WriteLine($"\r{new string('>', 73)}\nWhat do you want?\n" +
                                   "Press 1 to view some airline information\n" +
                                   "Press 2 to edit some airline information\n" +
                                   $"Press Escape to Exit\n{new string('-', 73)}");
                ConsoleKeyInfo answer = Console.ReadKey();

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
                            flightManager.SearchMenu();
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
                            flightManager.EditFlightInfo();
                            break;
                        case ConsoleKey.D2:
                            flightManager.EditPassengerInfo();
                            break;
                    }
                }
            }
        }
    }
}
