using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RentalVideoSystem.DTO_Modals;
using RentalVideoSystem.Modals;
using restapipractise.Data;
namespace RentalVideoSystem.Interfaces
{
    public interface ICustomer
    {
        public bool AddCustomer(CustomerDTOModal Users);
        public ActionResult<IEnumerable<CustomerDTOModal>> GetAllCustomers();
       
      
    }
}
