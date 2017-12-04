namespace Airline
{
    class FlightDeparture: BaseFlight
    {
        public override string ToString()
        {
            return $"Information about the departure:\n\t{base.ToString()}";
        }
    }
}
