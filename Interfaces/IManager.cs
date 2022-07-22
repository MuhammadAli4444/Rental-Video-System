using RentalVideoSystem.Modals;

namespace RentalVideoSystem.Interfaces
{
    public interface IManager
    {
        ICollection<Customer> GetCustomers();
    }
}
