using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using P224FirstApi.DAL.Entities;
using P224FirstApi.DTOs.UserDtos;
using P224FirstApi.Interfaces;
//using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace P224FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IJWTService _jWTService;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(IConfiguration configuration, IJWTService jWTService, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _configuration = configuration;
            _jWTService = jWTService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //[HttpGet]
        //public async Task<IActionResult> CreateRoleAndUser()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Memmber" });

        //    AppUser superAdmin = new AppUser { UserName = "SuperAdmin", Email = "superadmin@gmail.com", FullName = "Super Admin" };
        //    AppUser Admin = new AppUser { UserName = "Admin", Email = "admin@gmail.com", FullName = "Admin" };
        //    AppUser member = new AppUser { UserName = "member", Email = "member@gmail.com", FullName = "Member" };

        //    await _userManager.CreateAsync(superAdmin, "SuperAdmin123");
        //    await _userManager.CreateAsync(Admin, "Admin123");
        //    await _userManager.CreateAsync(member, "Member123");

        //    await _userManager.AddToRoleAsync(superAdmin, "SuperAdmin");
        //    await _userManager.AddToRoleAsync(Admin, "Admin");
        //    await _userManager.AddToRoleAsync(member, "Memmber");

        //    return Ok();
        //}

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            AppUser appUser = await _userManager.FindByNameAsync(loginDto.UserName);

            if (appUser == null)
            {
                return NotFound();
            }

            if (!await _userManager.CheckPasswordAsync(appUser, loginDto.Password))
                return BadRequest();

            IList<string> roles = await _userManager.GetRolesAsync(appUser);

            string token = _jWTService.CreateToken(appUser,_configuration,roles);

            return Ok(token);
        }
    }
}
