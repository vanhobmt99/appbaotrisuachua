using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using CMMSBT.Util;
using CMMSBT.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using CMMSBT.Dao;

namespace CMMSBT.API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly CmmsbtContext _dbcontext;
        private readonly IUserRepository _userDao;
        private readonly INhanVienService _nvDao;
        private readonly ILogger<AuthController> _logger;

        public AuthController(CmmsbtContext context,
            IUserRepository userDao,
            INhanVienService nvDao,
            ILogger<AuthController> logger)
        {
            this._dbcontext = context;
            this._userDao = userDao;
            this._nvDao = nvDao;
            this._logger = logger;
        }        

        [AllowAnonymous]
        [Route("api/CMMSBT/Auth/Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                var response = await _userDao.GetUser(model);
                if (response == null)
                    return BadRequest(new { message = "Tên đăng nhập hoặc mật khẩu chưa chính xác" });

                if (response.Manv >0)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Username!)
                    };

                    var obj = await _nvDao.Get(response.Manv);
                    NHANVIENTT ketqua = _nvDao.ConvertFormNhanVien(obj!);

                    return Ok(ketqua);
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }           
        }
             
       
    }
}
