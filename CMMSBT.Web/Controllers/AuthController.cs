using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using CMMSBT.Util;
using CMMSBT.Dao;
using CMMSBT.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text;
using Newtonsoft.Json.Linq;
using Azure.Core;
using System.Net.Http;

namespace CMMSBT.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly CmmsbtContext _dbcontext;
        private readonly IUserRepository _userDao;
        private readonly INhanVienService _nvDao;
        private readonly HttpClient _client;
        public AuthController(CmmsbtContext context,
            IUserRepository userDao,
            INhanVienService nvDao,
            HttpClient client)
        {
            this._dbcontext = context;
            this._userDao = userDao;
            this._nvDao = nvDao;
            this._client = client;
        }
        public IActionResult Login()
        {
            /*ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity!.IsAuthenticated)
                return RedirectToAction("Index", "Home");*/

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _client.PostAsJsonAsync(SystemConstants.AppSettings.BaseAddress + "/Auth/Login", model);
                var body = response.Content.ReadAsStringAsync().Result;
                NHANVIENTT? nvtt = JsonConvert.DeserializeObject<NHANVIENTT>(body);
                if (nvtt != null && nvtt.Manv > 0)
                {
                    HttpContext.Session.SetString("TenDN", model.Username!);
                    HttpContext.Session.SetInt32("Manv", nvtt!.Manv);
                    HttpContext.Session.SetString("HoTen", nvtt!.Hoten);
                    HttpContext.Session.SetString("Mapb", nvtt!.Mapb);
                    HttpContext.Session.SetString("Macv", nvtt!.Macv);
                    HttpContext.Session.SetString("Makv", nvtt!.Makv);
                    HttpContext.Session.SetInt32("Madonvi", nvtt!.Madonvi);

                    List<Claim> claims = new List<Claim>() {
                            new Claim(ClaimTypes.Name, model.Username!)
                         };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        IsPersistent = model.KeepLoggedIn
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity), properties);

                    return RedirectToAction("Index", "Home");
                }

            }             
        
            ViewData["ValidateMessage"] = "Tên đăng nhập hoặc mật khẩu chưa chính xác";
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);           
            return RedirectToAction("Login", "Auth");
        }        
       
    }
}
