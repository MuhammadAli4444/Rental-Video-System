using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RentalVideoSystem.DTO_Modals;
using RentalVideoSystem.Interfaces;
using RentalVideoSystem.Modals;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RentalVideoSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomer _customerRepo;
        private readonly IConfiguration _configuration;

        private readonly IApplicationUser _applicationUserRepo;

        public AuthController(ICustomer customerRepo,IMapper mapper, IApplicationUser applicationUserRepo, IConfiguration configuration)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
            _applicationUserRepo = applicationUserRepo;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<ActionResult<CustomerDTOModal>> RegisterCustomer(CustomerDTOModal request)
        {
            try
            {
                if(request == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);

                }
               

                //newCustomer.ApplicationUser.Name = request.ApplicationUser.Name;
                //newCustomer.ApplicationUser.Email = request.ApplicationUser.Email;
                //newCustomer.ApplicationUser.Password = request.ApplicationUser.Password;
                //newCustomer.ApplicationUser.MobileNumber = request.ApplicationUser.MobileNumber;
                var newCustomer = _mapper.Map<Customer>(request);
                newCustomer.ApplicationUser.Role = "Customer";
                _customerRepo.AddCustomer(newCustomer);
                return Ok("Success");

            }
            catch (Exception ex)
            {
                throw new Exception("dsds");
            }
           
            return Ok(request);
        }
        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> LoginCustomer(LoginDTO login)
        {
            try
            {
                if (login == null)
                    return BadRequest(ModelState);
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var user = _mapper.Map<ApplicationUser>(login);
                ApplicationUser check = await _applicationUserRepo.GetUserByEmail(login.Email);
               if (check == null)
                {
                    return NotFound("Incorrect Email");
                }
                if (check.Role == "Customer")
                {

                    if (check.Password == login.Password)
                    {
                        string token = CreateToken(check);
                        return Ok(token);
                    }
                    else
                    {
                        return NotFound("Incorrect Email");
                    }
                }
                else
                {
                    return NotFound("Role is not of customer");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error occur");
            }

            
        }
        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> LoginManager(LoginDTO login)
        {
            try
            {
                if (login == null)
                    return BadRequest(ModelState);
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var user = _mapper.Map<ApplicationUser>(login);
                ApplicationUser check = await _applicationUserRepo.GetUserByEmail(login.Email);
                if (check == null)
                {
                    return NotFound("Incorrect Email");
                }
                if (check.Role == "Manager")
                {

                    if (check.Password == login.Password)
                    {
                        string token = CreateToken(check);
                        return Ok(token);
                    }
                    else
                    {
                        return NotFound("Incorrect Email");
                    }
                }
                else
                {
                    return NotFound("Role is not of Manager");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error occur");
            }


        }
        private string CreateToken(ApplicationUser user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Role,user.Role),
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
