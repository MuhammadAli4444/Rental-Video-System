using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalVideoSystem.Interfaces;
using RentalVideoSystem.Modals;
using restapipractise.Data;

namespace RentalVideoSystem.Repository
{

    public class CustomerRepo : ICustomer
    {
        private readonly ContextFile _context;
        public CustomerRepo(ContextFile context)
        {
            _context = context;
        }


        public void AddCustomer(Customer Users)
        {
            _context.Customer.Add(Users);
            _context.SaveChanges();
        }

        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
           return _context.Customer.Include(c => c.ApplicationUser).ToList();
      
        }
    }
}
