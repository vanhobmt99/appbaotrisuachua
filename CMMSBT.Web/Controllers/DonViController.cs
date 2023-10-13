using CMMSBT.ApiModels;
using CMMSBT.Dao;
using CMMSBT.Domain;
using CMMSBT.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using X.PagedList;

namespace CMMSBT.Web.Controllers
{
    [Authorize]
    public class DonViController : Controller
    {
        private readonly ILogger<DonViController> _logger;
        private readonly CmmsbtContext _context;
        private readonly IDonViService _donviDao;
        private readonly HttpClient _client;
        public DonViController(
            ILogger<DonViController> logger,
            CmmsbtContext context,
            IDonViService donviDao,
            HttpClient client
            )
        {
            this._logger = logger;
            this._context = context;
            this._donviDao = donviDao;
            this._client = client;
        }

        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PagedPartial(int? page, string? txtsearch)
        {
            if (!String.IsNullOrEmpty(txtsearch))
            {
                ViewBag.txtSearch = txtsearch;
            }


            var response = await _client.PostAsJsonAsync(SystemConstants.AppSettings.BaseAddress + "/DonVi/GetAll", txtsearch);
            var data = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<Donvi>>(data)!;

            if (page == null) page = 1;
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var result = list.ToPagedList(pageNumber, pageSize);
            ViewData.Model = result;
            return PartialView("_ViewDataTable");

        }

        [HttpGet]
        public async Task<IActionResult> Add(int MaDv)
        {
            ViewData["id"] = 0;
            if (MaDv > 0)
            {
                var dv = await _donviDao.Get(MaDv);
                if (dv != null)
                {
                    ViewData["id"] = dv.Madv;
                }
                return View(dv);
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public async Task<IActionResult> SaveAction(DonViModel model)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _client.PostAsJsonAsync(SystemConstants.AppSettings.BaseAddress + "/DonVi/AddUpdate", model);
            //var list = _donviDao.PostDonVi(model);
            if (response.IsSuccessStatusCode)
            {
                return Ok(new { ResultCode = true, Message = "Cập nhật thành công!" });
            }
            else
            {
                return Ok(new { ResultCode = false, Message = "Lỗi vui lòng hãy kiểm tra lại" });
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] string[] OrderIDs)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _client.PostAsJsonAsync(SystemConstants.AppSettings.BaseAddress + "/DonVi/Delete", OrderIDs);
            if (response.IsSuccessStatusCode)
            {
                return Ok(new { ResultCode = true, Message = "Xóa thành công!" });
            }
            else
            {
                return Ok(new { ResultCode = false, Message = "Lỗi vui lòng hãy kiểm tra lại" });
            }

        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _client.PostAsJsonAsync(SystemConstants.AppSettings.BaseAddress + "/DonVi/Get", id);
            var data = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<Donvi>(data)!;
            return Ok(list);
        }




    }
}
