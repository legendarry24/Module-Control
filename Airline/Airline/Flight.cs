namespace Airline
{
    class Flight
    {
        public FlightDeparture Departure { get; set; }

        public FlightArrival Arrival { get; set; }

        public FlightStatus FlightStatus { get; set; }

        public decimal[] Price { get; set; }

        public int Number { get; set; }

        public override string ToString()
        {
            return $"Flight number: {Number}\n{Departure}\n{Arrival}\nFlight status: {FlightStatus}";
        }
    }
}
