using Application.ViewModel.Master;
using Application.ViewModel.Others;
using Common.Library;
using Domain;
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
    [Authorize]
    public class BaseController : ControllerBase
    {
        internal T SetCreateAudit<T>(T entity) where T : Entity
        {
            try
            {
                entity.CreatedAt = DateTime.Now;
                entity.CreatedBy = GetUserId().StringToGuid();
                entity.CreatedFrom = GetIP();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("You should relogin for identity.");
            }

        }
        private string GetIP()
        {
            IHttpContextAccessor _accessor = new HttpContextAccessor();
            var ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            return ip;
        }
        internal T SetUpdateAudit<T>(T entity) where T : Entity
        {
            try
            {
                entity.UpdatedAt = DateTime.Now;
                entity.UpdatedBy = GetUserId().StringToGuid();
                entity.UpdatedFrom = GetIP();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("You should relogin for identity.");
            }
        }
        internal string GetUserId()
        {
            try
            {
                return GetClaimData("UID");
            }
            catch (Exception)
            {
                HttpContext.SignOutAsync();
                throw;
            }
        }
        private string GetClaimData(string name)
        {
            try
            {
                IHttpContextAccessor _accessor = new HttpContextAccessor();
                var currentUser = _accessor.HttpContext.User;
                var val = currentUser.FindFirstValue(name);
                return val;
            }
            catch (Exception)
            {
                HttpContext.SignOutAsync();
                throw;
            }
        }
        internal UserTokenVM GenerateToken(UsersVM usersVM)
        {
            var claims = new List<Claim>
                            {
                                new Claim("UID",usersVM.Id.ToString()),
                                new Claim(ClaimTypes.Name,usersVM.Name.ToString()),
                                new Claim(ClaimTypes.Role,"*"),
                            };
            var key = Encoding.ASCII.GetBytes(SYS_DATA.AuthKey);
            var JWToken = new JwtSecurityToken(
                issuer: SYS_DATA.URL,
                audience: SYS_DATA.URL,
                claims: claims,
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddDays(30)).DateTime,
                //Using HS256 Algorithm to encrypt Token - JRozario
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            );
            var _token = new JwtSecurityTokenHandler().WriteToken(JWToken);
            return new UserTokenVM()
            {
                Token = _token,
                UserName = usersVM.Name
            };
        }
    }
}
