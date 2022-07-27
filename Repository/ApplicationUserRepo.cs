using RentalVideoSystem.Controllers;
using RentalVideoSystem.Interfaces;
using RentalVideoSystem.Modals;
using restapipractise.Data;

namespace RentalVideoSystem.Repository
{
    public class ApplicationUserRepo : IApplicationUser
    {
        private readonly ContextFile _context;
        public ApplicationUserRepo(ContextFile context)
        {
            _context = context;
        }



        public IEnumerable<ApplicationUser> GetAllApplicationUser()
        {
            return _context.ApplicationUser.ToList();
        }

        public IEnumerable<ApplicationUser> GetApplicationUserById(int id)
        {
            yield return _context.ApplicationUser.Where(p => p.GenericId == id)
                .FirstOrDefault();
        }
      
    }
}
