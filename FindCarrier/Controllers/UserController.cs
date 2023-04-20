using FindCarrier.Domain;
using FindCarrier.Domain.Entities;
using FindCarrier.Models.ViewModels;
using FindCarrier.Repositories.Repositories;
using FindCarrier.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindCarrier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly AppUserService userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        public UserController(IRepository<ApplicationUser> _repository,
            CarrierDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IPasswordHasher<ApplicationUser> passwordHasher)
        {
            userService = new AppUserService(_repository, context);
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("CreateUserApplication")]
        public async Task<IActionResult> CreateUserApplication([FromBody] ApplicationUserViewModel appUser)
        {

            var user = new ApplicationUser()
            {
                UserName = appUser.Email,
                Email = appUser.Email,
                NormalizedEmail = appUser.Email,
                IsDeleted = false,
                IsActive = true
            };

            var result = await _userManager.CreateAsync(user, appUser.Password);

            if (result.Succeeded)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);


            var loginSuccessful = await _userManager.CheckPasswordAsync(user, loginModel.Password);

            if (loginSuccessful)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }
        }

        [HttpGet]
        [Route("UsersList")]
        public async Task<IActionResult> UsersList()
        {
            var model = new ApplicationUserViewModel();
            var result = (await userService.GetAll()).Select(x => new ApplicationUserViewModel
            {
                Email = x.Email,


            }).ToList();

            model.Users = result;
            return Ok(model);
        }


        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await userService.GetAll();
            return Ok(result);

        }

        //[HttpPost]
        //[Route("DeleteUser/{id}")]
        //public async Task<IActionResult> DeleteUser(int id)
        //{

        //    var result = await userService.DeleteUser(id);
        //    return Ok(result);
        //}
    }
}

