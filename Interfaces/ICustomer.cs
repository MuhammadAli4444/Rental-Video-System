using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RentalVideoSystem.Modals;
using restapipractise.Data;
namespace RentalVideoSystem.Interfaces
{
    public interface ICustomer
    {
        public IEnumerable<VideoCasste> GetAllVideos();
        public void RentVideo([FromBody] RentalVideoCasset RentalVideoCassetObj);
        public void ReturnVideo(int id);
        public void Deletee(int id);

    }
}
