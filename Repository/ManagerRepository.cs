using RentalVideoSystem.Interfaces;
using RentalVideoSystem.Modals;
using restapipractise.Data;
using System.Collections.Generic;
namespace RentalVideoSystem.Repository
{
    public class ManagerRepository :IManager
    {
        ContextFile _context;
        public ManagerRepository(ContextFile context)
        {
            _context = context;
        }

        public  ICollection<Customer> GetCustomers()
        {
            return _context.Customer.OrderBy(p=>p.Id).ToList();
        }
    }
}
