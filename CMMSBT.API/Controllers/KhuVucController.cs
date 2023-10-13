using Microsoft.AspNetCore.Mvc;
using CMMSBT.Domain;
using CMMSBT.Dao;
using CMMSBT.ApiModels;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using CMMSBT.Util;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CMMSBT.API.Controllers
{
    //[Authorize]
    [ApiController]
    public class KhuVucController : ControllerBase
    {
        private readonly ILogger<KhuVucController> _logger;
        private readonly CmmsbtContext _context;
        private readonly IKhuVucService _khuvucDao;

        public KhuVucController(
            ILogger<KhuVucController> logger,
            CmmsbtContext context,
            IKhuVucService khuvucDao
            )
        {
            this._logger = logger;
            this._context = context;
            this._khuvucDao = khuvucDao;
        }
       
        [Route("api/CMMSBT/KhuVuc/GetAll")]
        [HttpPost]
        public async Task<IActionResult> GetAll([FromBody] string? keyword)
        {
            var listDon = await _khuvucDao.GetList(keyword!);
            if (listDon != null)
            {               
                return Ok(listDon);
            }
            else
            {
                return Ok();
            }
        }

        [Route("api/CMMSBT/KhuVuc/AddUpdate")]
        [HttpPost]
        public async Task<IActionResult> AddUpdate([FromBody] KhuVucModel objUi)
        {
            try
            {
                var objDb = await _khuvucDao.PostKhuVuc(objUi);
                if (objDb.IsSuccessed)
                {
                    return Ok(new { ResultCode = true, Data = "Cập nhật thành công" });
                }
                else
                {
                    return Ok(new { ResultCode = false, Data = "Cập nhật không thành công" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { ResultCode = false, Data = ex.Message });
            }
        }

        [Route("api/CMMSBT/KhuVuc/Delete")]
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] string[] OrderIDs)
        {
            try
            {
                var objDb = await _khuvucDao.Delete(OrderIDs);
                if (objDb.IsSuccessed)
                {
                    return Ok(new { ResultCode = true, Data = "Xóa thành công" });
                }
                else
                {
                    return Ok(new { ResultCode = false, Data = "Xóa không thành công" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { ResultCode = false, Data = ex.Message });
            }
        }

        private bool KhuvucExists(string id)
        {
            return (_context.Khuvucs?.Any(e => e.Makv == id)).GetValueOrDefault();
        }
    }
}
