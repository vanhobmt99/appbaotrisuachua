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
            ViewBag.Name = "Add";
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
        public async Task<IActionResult> Add(int Id)
        {
            ViewData["id"] = 0;
            if (Id > 0)
            {
                var kv = await _donviDao.Get(Id);
                if (kv != null)
                {
                    ViewData["id"] = kv.Madv;
                }
                return View(kv);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Create(Donvi dv)
        {
            AddUpdateInsert(dv, "Insert");
            return RedirectToAction("List");
        }
        public IActionResult Update(Donvi dv)
        {
            ViewBag.Name = "Add";
            AddUpdateInsert(dv, "Update");
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Add()
        {
            ViewBag.Name = "Add";
            Donvi dv = new Donvi();
            return PartialView("_InsertUpdatePartial", dv);
        }

        [HttpPost]
        public IActionResult Edit([FromBody] Donvi model)
        {
            int id = Convert.ToInt32(model.Madv);
            ViewBag.Name = "Update";
            Donvi dv = new Donvi();
            dv.Madv = id;
            dv.Tendonvi = _donviDao.GetLists(id).FirstOrDefault()!.Tendonvi;
            dv.Tengiayto = _donviDao.GetLists(id).FirstOrDefault()!.Tengiayto;
            dv.Diachi = _donviDao.GetLists(id).FirstOrDefault()!.Diachi;
            dv.Dienthoai = _donviDao.GetLists(id).FirstOrDefault()!.Dienthoai;
            dv.Fax = _donviDao.GetLists(id).FirstOrDefault()!.Fax;
            dv.Website = _donviDao.GetLists(id).FirstOrDefault()!.Website;
            dv.Masothue = _donviDao.GetLists(id).FirstOrDefault()!.Masothue;
            dv.Nganhang = _donviDao.GetLists(id).FirstOrDefault()!.Nganhang;
            dv.Tengiamdoc = _donviDao.GetLists(id).FirstOrDefault()!.Tengiamdoc;
            dv.Phogiamdoc = _donviDao.GetLists(id).FirstOrDefault()!.Phogiamdoc;
            dv.Phongkinhdoanh = _donviDao.GetLists(id).FirstOrDefault()!.Phongkinhdoanh;
            dv.Phonghoadon = _donviDao.GetLists(id).FirstOrDefault()!.Phonghoadon;
            dv.Email = _donviDao.GetLists(id).FirstOrDefault()!.Email;
            dv.So = _donviDao.GetLists(id).FirstOrDefault()!.So;
            dv.Phongqlmang = _donviDao.GetLists(id).FirstOrDefault()!.Phongqlmang;
            dv.Sotaikhoan = _donviDao.GetLists(id).FirstOrDefault()!.Sotaikhoan;
            dv.Phongketoan = _donviDao.GetLists(id).FirstOrDefault()!.Phongketoan;
            dv.Tenbaocao = _donviDao.GetLists(id).FirstOrDefault()!.Tenbaocao;
            dv.Vitribaocao = _donviDao.GetLists(id).FirstOrDefault()!.Vitribaocao;
            return PartialView("_InsertUpdatePartial", dv);
        }

        public void AddUpdateInsert(Donvi model, string action)
        {
            if (action == "Insert")
            {
                var objDb = new Donvi
                {
                    Tendonvi = model.Tendonvi,
                    Tengiayto = model.Tengiayto,
                    Diachi = model.Diachi,
                    Dienthoai = model.Dienthoai,
                    Fax = model.Fax,
                    Website = model.Website,
                    Masothue = model.Masothue,
                    Nganhang = model.Nganhang,
                    Tengiamdoc = model.Tengiamdoc,
                    Phogiamdoc = model.Phogiamdoc,
                    Phongkinhdoanh = model.Phongkinhdoanh,
                    Phonghoadon = model.Phonghoadon,
                    Email = model.Email,
                    So = model.So,
                    Phongqlmang = model.Phongqlmang,
                    Sotaikhoan = model.Sotaikhoan,
                    Phongketoan = model.Phongketoan,
                    Tenbaocao = model.Tenbaocao,
                    Vitribaocao = model.Vitribaocao
                };
                _context.Donvis.Add(objDb);
                _context.SaveChangesAsync();
            }
            else if (action == "Update")
            {
                var objDb = _donviDao.GetLists(model.Madv).SingleOrDefault();
                if (objDb != null)
                {
                    objDb.Tendonvi = model.Tendonvi;
                    objDb.Tengiayto = model.Tengiayto;
                    objDb.Diachi = model.Diachi;
                    objDb.Dienthoai = model.Dienthoai;
                    objDb.Fax = model.Fax;
                    objDb.Website = model.Website;
                    objDb.Masothue = model.Masothue;
                    objDb.Nganhang = model.Nganhang;
                    objDb.Tengiamdoc = model.Tengiamdoc;
                    objDb.Phogiamdoc = model.Phogiamdoc;
                    objDb.Phongkinhdoanh = model.Phongkinhdoanh;
                    objDb.Phonghoadon = model.Phonghoadon;
                    objDb.Email = model.Email;
                    objDb.So = model.So;
                    objDb.Phongqlmang = model.Phongqlmang;
                    objDb.Sotaikhoan = model.Sotaikhoan;
                    objDb.Phongketoan = model.Phongketoan;
                    objDb.Tenbaocao = model.Tenbaocao;
                    objDb.Vitribaocao = model.Vitribaocao;

                    _context.Donvis.Update(objDb);
                    _context.SaveChangesAsync();
                }
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
