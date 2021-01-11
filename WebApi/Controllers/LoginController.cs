using Application.IService.Master;
using Application.ViewModel.Master;
using Application.ViewModel.Others;
using Common.Library;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        private readonly IUsersService _usersService;
        public LoginController(IUsersService usersService)
        {
            this._usersService = usersService;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<object> SignIn(UserCredVM userCred)
        {
            try
            {
                var userM = await _usersService.Login(userCred.email, userCred.password.toEncrypt());
                if (userM != null)
                {
                    var token = GenerateToken(userM);
                    return Ok(token);
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("Registration")]
        public async Task<object> Registration(UserRegVM regvm)
        {
            try
            {
                UsersVM userM = await _usersService.Registration(regvm);
                if (userM != null)
                {
                    var token = GenerateToken(userM);
                    return Ok(token);
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //public async void Signout()
        //{
        //    try
        //    {
        //        Response.Cookies.Append(SYS_DATA.JwtTokenName, "", new CookieOptions()
        //        {
        //            Expires = DateTime.Now.AddDays(-1)
        //        });
        //        await HttpContext.SignOutAsync();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

    }
}
