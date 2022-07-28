using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalVideoSystem.DTO_Modals;
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


        public bool AddCustomer(CustomerDTOModal Users)
        {
            Customer UserForDb = new Customer();
            UserForDb.ApplicationUser = Users.ApplicationUser;
            _context.Customer.Add(UserForDb);
            _context.SaveChanges();
            return true;
        }

        public ActionResult<IEnumerable<CustomerDTOModal>> GetAllCustomers()
        {
         //  var AllCustomers= _context.Customer.Include(c => c.ApplicationUser).ToList();
            List<CustomerDTOModal> Customers = new List<CustomerDTOModal>();
            foreach(Customer cust in _context.Customer.Include(c => c.ApplicationUser).ToList())
            {
                CustomerDTOModal CustomerDTO= new CustomerDTOModal();
                CustomerDTO.ApplicationUser = cust.ApplicationUser;
                Customers.Add(CustomerDTO);
            }
            return Customers;
        }
    }
}
