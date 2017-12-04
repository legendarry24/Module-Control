namespace Airline
{
    class FlightArrival: BaseFlight
    {
        public override string ToString()
        {
            return $"Information about the arrival:\n\t{base.ToString()}";
        }
    }
}
