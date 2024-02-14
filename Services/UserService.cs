using dotnetapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using dotnetapp.Data;
namespace dotnetapp.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context; // Add this field


        public UserService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _context = context;

        }

        public async Task<bool> RegisterAsync(User user)
        {
            try
            {
                //var customUser = new User
                //{
                //    Username = user.Username,
                //    Password = user.Password,
                //    Role = user.Role,
                //    // Set any additional properties you have in your custom User entity
                //};

                //// Add the customUser to the DbSet and save it
                //_context.Users.Add(customUser);
                //await _context.SaveChangesAsync();


                var identityUser = new IdentityUser
                {
                    UserName = user.Username,
                };

                Console.WriteLine(identityUser.UserName);


                var result = await _userManager.CreateAsync(identityUser, user.Password);
                Console.WriteLine("asd"+result);

                if (result.Succeeded)
                {
                    // Assign roles to the user
                    if (user.Role == "admin")
                    {
                        Console.WriteLine("data " + identityUser);
                        await _userManager.AddToRoleAsync(identityUser, "admin");
                    }
                    else if (user.Role == "applicant")
                    {
                        Console.WriteLine("data1 " + identityUser);

                        await _userManager.AddToRoleAsync(identityUser, "applicant");
                        Console.WriteLine("data2 " + identityUser);

                    }
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                // Handle exceptions appropriately (e.g., logging)
                return false; // Registration failed
            }
        }

        public async Task<string> LoginAsync(string username, string password)
        {
             try
    {
        var user = await _userManager.FindByNameAsync(username);
        Console.WriteLine("User: " + user?.UserName); // Debug output
        Console.WriteLine("Password: " + password); // Debug output

        if (user == null || !(await _signInManager.CheckPasswordSignInAsync(user, password, false)).Succeeded)
        {
            Console.WriteLine("Invalid username or password"); // Debug output
            return null; // Invalid username or password
        }

        // Generate a JWT token
        var token = GenerateJwtToken(user);
        Console.WriteLine("Token: " + token); // Debug output

        return token;
    }
            catch (Exception ex)
            {
                Console.WriteLine("zxcvbnm" + ex.Message);
                // Handle exceptions appropriately (e.g., logging)
                return null; // Login failed
            }
        }

    //     private string GenerateJwtToken(IdentityUser user)
    //     {
    //         Console.WriteLine("asdf"+user.UserName);
    //         var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
    //         var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
    //         var claims = new List<Claim>
    // {
    //     new Claim(ClaimTypes.Name, user.UserName),
    // };

    //         // Retrieve roles for the user
    //         var roles = _userManager.GetRolesAsync(user).Result;

    //         Console.WriteLine("summa"+roles);

    //         // Add role claims to the JWT token
    //         claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

    //         var token = new JwtSecurityToken(
    //             _configuration["Jwt:Issuer"],
    //             _configuration["Jwt:Audience"],
    //             claims,
    //             expires: DateTime.Now.AddHours(2), // Token expiry time
    //             signingCredentials: credentials
    //         );

    //         return new JwtSecurityTokenHandler().WriteToken(token);
    //     }

            private string GenerateJwtToken(IdentityUser user)
{
    Console.WriteLine("User: " + user.UserName);

    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.UserName),
    };

    // Retrieve roles for the user
    var roles = _userManager.GetRolesAsync(user).Result;

    Console.WriteLine("Roles: " + string.Join(", ", roles));

    // Add role claims to the JWT token using ClaimTypes.Role
    // claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

    foreach (var role in roles)
{
    var roleClaim = new Claim(ClaimTypes.Role, role);
    Console.WriteLine($"Adding role claim: {roleClaim.Type} - {roleClaim.Value}");
    claims.Add(roleClaim);
}

    var token = new JwtSecurityToken(
        _configuration["Jwt:Issuer"],
        _configuration["Jwt:Audience"],
        claims,
        expires: DateTime.Now.AddHours(2),
        signingCredentials: credentials
    );
    Console.WriteLine("Token generated successfully: " + token);

    return new JwtSecurityTokenHandler().WriteToken(token);
}

    }
}
