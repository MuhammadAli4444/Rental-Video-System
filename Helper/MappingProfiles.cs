using AutoMapper;
using RentalVideoSystem.DTO_Modals;
using RentalVideoSystem.Modals;

namespace RentalVideoSystem.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            
            CreateMap<ApplicationUser, ApplicationUserDTO>();
            CreateMap<ApplicationUserDTO, ApplicationUser>();
            CreateMap<ApplicationUser, LoginDTO>();
            CreateMap<LoginDTO, ApplicationUser>();
            CreateMap<Customer, CustomerDTOModal>();
            CreateMap<CustomerDTOModal, Customer>();
        }
    }
}
