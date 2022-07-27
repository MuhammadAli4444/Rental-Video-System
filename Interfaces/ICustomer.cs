using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RentalVideoSystem.Modals;
using restapipractise.Data;
namespace RentalVideoSystem.Interfaces
{
    public interface ICustomer
    {
        public void AddCustomer(Customer Users);
        public ActionResult<IEnumerable<Customer>> GetAllCustomers();
       
      
    }
}
