namespace Airline
{
    interface IFlightRepository
    {
        void Insert(Flight flight);
        Flight Select(int number);
        void Update(int numberOfOld, Flight newFlight);
        void Delete(int number);
    } 
}
