using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Client.Domain.Models;
using Client.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Client.API.Controllers;

[Route("api/token")]
[ApiController]
public class TokenController: ControllerBase
{
private readonly IConfiguration Configuration;
private readonly HskeletonContext dbcontext;
public TokenController(IConfiguration configuration,HskeletonContext dbcontext)
{
    this.dbcontext = dbcontext;
    this.Configuration = configuration;
    
}

[HttpPost]
[Route("RegisterUser")]
public IActionResult Register(Register register)
{
    this.dbcontext.Registers.AddAsync(register);;
    this.dbcontext.SaveChangesAsync();
    return Ok();
}

 [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (login.MailId != null && login.Password != null)
            {
                var user = await GetUser(login.MailId, login.Password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, Configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserName",user.UserName)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        Configuration["Jwt:Issuer"],
                        Configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

         private async Task<Register> GetUser(string email, string password)
        {
            return await dbcontext.Registers.FirstOrDefaultAsync(u => u.MailId == email && u.Password == password);
        }
   


 }
