using Dealership.Contracts;
using Dealership.Models;

namespace Dealership.Factories
{
    public interface IDealershipFactory
    {
        IUser CreateUser(string username, string firstName, string lastName, string password, string role);

        IComment CreateComment(string content);

        ICar CreateCar(string make, string model, decimal price, int seats);

        IMotorcycle CreateMotorcycle(string make, string model, decimal price, string category);

        ITruck CreateTruck(string make, string model, decimal price, int weightCapacity);
    }
}
