using MediaLibrary.Data;
using MediaLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;



namespace MediaLibrary.Controllers
{
    public class AuthController : Controller
    {

        private readonly MediaLibraryContext _context;
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config, MediaLibraryContext context)
        {
            _config = config;
            _context = context;

        }

        [AllowAnonymous]
        [HttpPost("api/auth/token")]
        public IActionResult CreateToken([FromBody] CredentialsModel model)
        {
            if (model == null)
            {
                return BadRequest("Request is Null");
            }

            var user = _context.MediaLibraryUsers.FirstOrDefault(m => m.UserName.Equals(model.Username) && m.Password.Equals(model.Password));

            if (user != null)
            {
                var claims = new[]
                {
                    new Claim("SuperUser", user.IsSuperUser.ToString())


                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(45),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });

            }


            return BadRequest("failed to generate token");
        }



    }
}
