using System;

namespace Airline
{
    class Passenger
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Nationality { get; set; }

        public string Passport { get; set; }

        public DateTime DateOfBirthday { get; set; }

        //true = male, false = female
        public bool IsMale { get; set; }

        public ClassesOfService ClassesOfService { get; set; }

        public int? FlightNumber { get; set; }

        public Passenger(Flight flight)
        {
            //if particular flight not exists => FlightNumber = null
            FlightNumber = flight?.Number;
        }

        public override string ToString()
        {
            string sex = IsMale ? "Male" : "Female";
            return $"\tFirst name: {FirstName}\n\tSecond name: {SecondName}\n\t{nameof(Nationality)}: {Nationality}\n\t{nameof(Passport)}: {Passport}\n\tDate of birthday: {DateOfBirthday:d}\n\tSex: {sex}\n\tFlight number: {FlightNumber}\n\tClass: {ClassesOfService}";
        }
    }
}
