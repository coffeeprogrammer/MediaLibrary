using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MediaLibrary.Controllers
{
    //public class AccountController : Controller
    //{

    //    public AccountController()
    //    {

    //    }

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("api/authenticate")]
        //public object Authenticate([FromBody] AuthenticateRequestModel loginUser)
        //{

        //    var claims = new List<Claim>();



        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("4rTGTad3Asdd$123ads*asd3iotgfd#12axads9310#"));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //        issuer: "coffeeprog.dev",
        //        audience: "coffeeprog.dev",
        //        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(45)),
        //        claims: claims,
        //        signingCredentials: creds
        //    );

        //    var returnValue = new
        //    {
        //        token = new JwtSecurityTokenHandler().WriteToken(token),
        //        expires = token.ValidTo
        //    };

        //    return returnValue;

        //}


        //    public IActionResult Index()
        //{
        //    return View();
        //}
    //}
}
