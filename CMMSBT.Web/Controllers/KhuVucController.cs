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
    public class KhuVucController : Controller
    {
        private readonly ILogger<KhuVucController> _logger;
        private readonly CmmsbtContext _context;
        private readonly IKhuVucService _khuvucDao;
        private readonly HttpClient _client;
        public KhuVucController(
            ILogger<KhuVucController> logger,
            CmmsbtContext context,
            IKhuVucService khuvucDao,
            HttpClient client
            )
        {
            this._logger = logger;
            this._context = context;
            this._khuvucDao = khuvucDao;
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

            var response = await _client.PostAsJsonAsync(SystemConstants.AppSettings.BaseAddress + "/KhuVuc/GetAll", txtsearch);
            var data = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<Khuvuc>>(data)!;

            if (page == null) page = 1;
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var result = list.ToPagedList(pageNumber, pageSize);
            ViewData.Model = result;
            return PartialView("_ViewDataTable");

        }

        [HttpGet]
        public async Task<IActionResult> Add(string Makv)
        {

            ViewData["id"] = "0";
            if (!string.IsNullOrEmpty(Makv) && Makv != "0")
            {
                var kv = await _khuvucDao.Get(Makv);
                if (kv != null)
                {
                    ViewData["id"] = kv.Makv;
                }
                return View(kv);
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public async Task<IActionResult> SaveAction(KhuVucModel model)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _client.PostAsJsonAsync(SystemConstants.AppSettings.BaseAddress + "/KhuVuc/AddUpdate", model);
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
            var response = await _client.PostAsJsonAsync(SystemConstants.AppSettings.BaseAddress + "/KhuVuc/Delete", OrderIDs);
            if (response.IsSuccessStatusCode)
            {
                return Ok(new { ResultCode = true, Message = "Xóa thành công!" });
            }
            else
            {
                return Ok(new { ResultCode = false, Message = "Lỗi vui lòng hãy kiểm tra lại" });
            }

        }

        [HttpPost]
        public async Task<IActionResult> UpdateSort(string Makv, int Orders)
        {
            if (await _khuvucDao.UpdateSort(Makv, Orders))
            {
                return Ok(new { ResultCode = true, Message = "Cập nhật thành công" });
            }
            else
            {
                return Ok(new { ResultCode = false, Message = "Lỗi vui lòng hãy kiểm tra lại" });
            }
        }

    }
}
