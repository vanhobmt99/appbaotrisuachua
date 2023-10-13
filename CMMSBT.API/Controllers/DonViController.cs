using CMMSBT.ApiModels;
using CMMSBT.Dao;
using CMMSBT.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CMMSBT.API.Controllers
{
    //[Authorize]
    [ApiController]
    public class DonViController : ControllerBase
    {
        private readonly ILogger<DonViController> _logger;
        private readonly CmmsbtContext _context;
        private readonly IDonViService _donviDao;

        public DonViController(
            ILogger<DonViController> logger,
            CmmsbtContext context,
            IDonViService donviDao
            )
        {
            this._logger = logger;
            this._context = context;
            this._donviDao = donviDao;
        }

        [Route("api/CMMSBT/DonVi/GetAll")]
        [HttpPost]
        public async Task<IActionResult> GetAll([FromBody] string? keyword)
        {
            var listDon = await _donviDao.GetList(keyword!);
            if (listDon != null)
            {
                return Ok(listDon);
            }
            else
            {
                return Ok();
            }
        }

        [Route("api/CMMSBT/DonVi/AddUpdate")]
        [HttpPost]
        public async Task<IActionResult> AddUpdate([FromBody] DonViModel objUi)
        {
            try
            {
                var objDb = await _donviDao.PostDonVi(objUi);
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

        [Route("api/CMMSBT/DonVi/Delete")]
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] int[] OrderIDs)
        {
            try
            {
                var objDb = await _donviDao.Delete(OrderIDs);
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

        private bool DonViExists(int id)
        {
            return (_context.Donvis?.Any(e => e.Madv == id)).GetValueOrDefault();
        }
    }
}
