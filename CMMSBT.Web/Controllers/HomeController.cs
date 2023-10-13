using CMMSBT.Dao;
using CMMSBT.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace CMMSBT.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly CmmsbtContext _db;
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;       
        public HomeController(CmmsbtContext dbcontext,
            IConfiguration config,
            IUserRepository userRepository)
        {
            this._db = dbcontext;
            this._config = config;
            this._userRepository = userRepository;
        }
        public IActionResult Index()
        {           
            ViewBag.Title = "APP CMMS BẢO TRÌ";
            //ViewBag.Description = "Công Ty Cổ Phần Nước Thủ Dầu Một";
            //ViewBag.Keyword = "Công Ty Cổ Phần Nước Thủ Dầu Một";            
            return View();
        }
            

    }
}
