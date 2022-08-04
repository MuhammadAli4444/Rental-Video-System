using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RentalVideoSystem.DTO_Modals;
using RentalVideoSystem.Interfaces;
using RentalVideoSystem.Modals;
using restapipractise.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace RentalVideoSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerRepo;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomer customerRepo, ILogger<CustomerController> logger,IConfiguration configuration)
        {
            _configuration = configuration;
            _customerRepo = customerRepo;
            _logger = logger;
        }
        [HttpGet,Authorize(Roles ="Manager")]

        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            try
            {
                _logger.LogInformation("Get All Customer");
                return _customerRepo.GetAllCustomers();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured as because of some internal error", ex);
            }
   
        }
//        [HttpPost]
//        public IActionResult AddCustomer([FromBody]CustomerDTOModal Users)
//        {
//            try
//            {
//                if (_customerRepo.AddCustomer(Users))
//            {
//                return Ok("Customer has been succesffuly added in the system");
//            }
//            else
//            {
//                return BadRequest("Record is not added");
//            }
//        }
//            catch (Exception ex)
//            {
//                throw new Exception("Exception occured as because of some internal error", ex);
//    }
//}
       
       //[HttpPost("register")]
       // public async Task<ActionResult<ApplicationUserDTO>> Register(CustomerDTOModel request)
       // {
           
       //     user.Username = request.Username;
       //    user.Password = request.Password;
       //      return Ok(request);
       // }
        //private void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt )
        //{
        //    using(var hmac=new HMACSHA512())
        //    {
        //        passwordSalt = hmac.Key;
        //        passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //    }
        //}
        //[HttpPost("login")]
        //public async Task<ActionResult<ApplicationUserDTO>> Login(CustomerDTOModel request)
        //{
         
        //    string token = CreateToken(user);
        //    return  Ok(token);
        //}
        //private string CreateToken(ApplicationUserDTO user)
        //{
        //    List<Claim> claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name,user.Username)
        //    };
        //    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
        //        _configuration.GetSection("AppSetting:Token").Value));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        //    var token = new JwtSecurityToken(
        //        claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: creds);
        //    var jwt=new JwtSecurityTokenHandler().WriteToken(token);

        //    return jwt;
        //}
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac=new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash); //computedHash == passwordHash;
            }
        }
    }
}
