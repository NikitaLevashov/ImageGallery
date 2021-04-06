using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PhotoGallery.BLL.intrerfaces;
using PhotoGallery.DAL.EFCore;
using PhotoGallery.DAL.Models;

namespace PhotoGallery.WEB.Controllers
{
    public class AccountController : Controller
    {
        IPhotoService _photoService;
        // тестовые данные вместо использования базы данных
        private List<Person> people = new List<Person>
        {
            new Person {Login="admin@gmail.com", Password="12345", Role = "admin" },
            new Person { Login="qwerty@gmail.com", Password="55555", Role = "user" }
        };

        [HttpGet]
        public IActionResult Token()
        {
            return View();
        }


        [HttpPost("/token")]
        public IActionResult Token([FromForm]string username, [FromForm]string password)
        {
            var photos = MapperProfile.MapToIEnumerablePLPhotos(_photoService.GetPhotos());
            ViewBag.Photos = photos;
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Json(response);
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            Person p = null;
            foreach(var c in people)
            {
                if (c.Login == username && c.Password == password)
                    p = c;
            }
            //Person person = people.FirstOrDefault(x => x.Login == username && x.Password == password);
            if (p != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, p.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, p.Role)
                };

                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }

}
