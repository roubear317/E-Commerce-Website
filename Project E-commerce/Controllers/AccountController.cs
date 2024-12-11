using E_commerce.EF.DTOS;
using E_Commerce.Core.Model;
using E_Commerce.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_E_commerce.Errors;

namespace Project_E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }


        [HttpPost("Login")]

        public async Task<ActionResult<UserDto>> LoginAsync(LoginDto loginDto)
            {


            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) { return Unauthorized(new ApiResponse(401)); }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password,false);

            if(!result.Succeeded) return Unauthorized(new ApiResponse(401));


            return new UserDto { Email = loginDto.Email, UserName = user.UserName,
                Token = _tokenService.GetTokenAsync(user)};


        }







        [HttpPost("Register")]

        public async Task<ActionResult<UserDto>> RegisterAsync(RegisterDto registerDto)
        {

            var user = new AppUser()
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                FullName= registerDto.UserName
            };


            var result = await _userManager.CreateAsync(user,registerDto.Password);

            if (!result.Succeeded) { return BadRequest(new ApiResponse(400)); }


            return new UserDto { Email = registerDto.Email, UserName = user.UserName,
                Token = _tokenService.GetTokenAsync(user)
            };


        }

        
        

        }








    }

