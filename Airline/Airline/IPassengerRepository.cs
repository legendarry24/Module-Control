
namespace Airline
{
    interface IPassengerRepository
    {
        void Insert(Passenger passenger);
        Passenger Select(int id);
        void Update(int id, Passenger newPassenger);
        void Delete(string passport);
    }
}
