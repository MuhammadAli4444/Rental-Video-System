using System.ComponentModel.DataAnnotations;

namespace RentalVideoSystem.Modals
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }

        public IEnumerable<Customer> customers { get; set; }

        public Manager Manager_Obj { get; set; }
    
        public Collection collection_ { get; set; }
    }
}