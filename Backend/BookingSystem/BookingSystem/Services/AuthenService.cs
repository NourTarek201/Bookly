using BookingSystem.DTOs;
using BookingSystem.Models.PlaceManagement;
using BookingSystem.Models.Users;
using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookingSystem.Services
{
    public class AuthenService
    {
        private readonly UserManager<BaseUser> userManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;
        private readonly JWTService jwtService;

        public AuthenService(UserManager<BaseUser> userManager, RoleManager<IdentityRole<Guid>> roleManager, JWTService jwtService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.jwtService = jwtService;
        }

        public async Task<string?> Registeration(RegisterationDTO user, string role)
        {
            var newUser = new BaseUser { 
                UserName = user.Username, 
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                dateOfBirth = user.dateOfBirth,
            };
            Address newAddress=new Address();
            if (user.Address != null){
                newAddress = new Address
                {
                    City = user.Address.City,
                    Street = user.Address.Street,
                    Country = user.Address.Country
                };
                newAddress.BaseUser = newUser;
                newUser.Address = newAddress;
            }
            var isUniqueEmail = await userManager.FindByEmailAsync(user.Email);
            var isUniqueUsername = await userManager.FindByEmailAsync(user.Email);
            if (isUniqueEmail!=null || isUniqueUsername!=null)
            {
                return null;
            }



            var result = await userManager.CreateAsync(newUser, user.Password);
            if (!result.Succeeded){
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Registeration failed: {errors}");
                //return null;

            }

            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole<Guid>(role));

            await userManager.AddToRoleAsync(newUser, role);

            
            return await jwtService.getJWT(newUser);
        }

        public async Task<string?> Signin(LoginDTO user)
        {
            var loggeduser = await userManager.FindByEmailAsync(user.Email);
            if (user == null || !await userManager.CheckPasswordAsync(loggeduser, user.Password))
                return null;

            return await jwtService.getJWT(loggeduser);
        }
    }

}
