

using RentalVideoSystem.DTO_Modals;
using RentalVideoSystem.Modals;

namespace RentalVideoSystem.Interfaces
{
    public interface IApplicationUser
    {
        public IEnumerable<ApplicationUser> GetAllApplicationUser();
        public IEnumerable<ApplicationUser> GetApplicationUserById(int id);
        Task<ApplicationUser> GetUserByEmail(string email);

    }
}
