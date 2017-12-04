
namespace Airline
{
    interface IPassengerRepository
    {
        void Insert(Passenger passenger);
        Passenger Select(int id);
        void Update(int id, Passenger newPassenger, Flight anotherFlight);
        void Delete(string passport);
    }
}
