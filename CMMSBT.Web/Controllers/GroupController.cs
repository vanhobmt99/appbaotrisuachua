using CMMSBT.Dao;
using CMMSBT.Domain;
using CMMSBT.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;
using Microsoft.AspNetCore.Http;
using System.Security;

namespace CMMSBT.Web.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        private readonly ILogger<GroupController> _logger;
        private readonly CmmsbtContext _context;
        private readonly IGroupService _groupDao;
        private readonly ICrmFunctionService _functionDao;

        public GroupController(
            ILogger<GroupController> logger,
            CmmsbtContext context,
            IGroupService groupDao,
            ICrmFunctionService functionDao
            )
        {
            this._logger = logger;
            this._context = context;
            this._groupDao = groupDao;
            this._functionDao = functionDao;
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

            var list = await _groupDao.GetList(txtsearch!);
            if (page == null) page = 1;
            int pageSize = 20;
            int pageNumber = (page ?? 1);

            var result = list.ToPagedList(pageNumber, pageSize);
            ViewData.Model = result;
            return PartialView("_ViewDataTable");

        }

        [HttpGet]
        public async Task<IActionResult> Add(int Id)
        {
            ViewData["id"] = 0;
            ViewData["listFunction"] = null;
            var listfunction = PermConstants.ListPerms;
            if (listfunction != null)
            {
                ViewData["listFunction"] = listfunction;
            }

            if (Id>0)
            {
                var kv = await _groupDao.Get(Id);
                if (kv != null)
                {
                    ViewData["id"] = kv.Id;
                }
                return View(kv);
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public async Task<IActionResult> SaveAction(Group objUi, IEnumerable<GroupPermission> listpermistion)
        {

            string TenDN = HttpContext.Session.GetString("TenDN") ?? "";
            if (objUi.Id > 0)
            {
                var objDb = await _groupDao.Get(objUi.Id);
                if (objDb != null)
                {
                    objDb.Name = objUi.Name;
                    objDb.Description = objUi.Description;
                    foreach (var groupPermission in objDb.GroupPermissions)
                    {
                        _context.GroupPermissions.Remove(groupPermission);
                    }
                    await _context.SaveChangesAsync();

                    foreach (var item in listpermistion)
                    {
                        var permission = new GroupPermission
                        {
                            FunctionId = item.FunctionId,
                            GroupId = objUi.Id,
                            Mash = item.Mash,
                            Active = true,
                            Deleted = false,
                            CreateBy = TenDN,
                            CreateDate = DateTime.Now,
                            UpdateBy = TenDN,
                            UpdateDate = DateTime.Now
                        };
                        _context.GroupPermissions.Add(permission);
                        await _context.SaveChangesAsync();
                    }
                    objDb.Active = true;
                    objDb.UpdateDate = DateTime.Now;
                    objDb.UpdateBy = TenDN;
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                var objDb = new Group
                {
                    Name = objUi.Name,
                    Description = objUi.Description,
                    Deleted = false,
                    Active = true,
                    CreateDate = DateTime.Now,
                    CreateBy = TenDN,
                    UpdateDate = DateTime.Now,
                    UpdateBy = TenDN

                };

                _context.Groups.Add(objDb);
                await _context.SaveChangesAsync();

                /*foreach (var item in order)
                {
                    var permission = new GroupPermission
                    {
                        FunctionId = item.FunctionId,
                        GroupId = objDb.Id,
                        Mash = item.Mash,
                        Active = true,
                        Deleted = false,
                        CreateBy = TenDN,
                        CreateDate = DateTime.Now,
                        UpdateBy = TenDN,
                        UpdateDate = DateTime.Now
                    };
                    _context.GroupPermissions.Add(permission);
                    await _context.SaveChangesAsync();
                }*/
            }
            return Ok(new { ResultCode = true, Message = "Cập nhật thành công!" });

        }
        /*public UserAdmin LoginInfo { get; set; }

        private List<GroupPermission> groupPermissions;

        public List<GroupPermission> GroupPermissions
        {
            get
            {
                groupPermissions = new List<GroupPermission>();

                for (var i = 0; i < grdPermission.Rows.Count; i++)
                {
                    var row = grdPermission.Rows[i];
                    var chkFunctionId = (HtmlInputCheckBox)row.FindControl("chkFunctionId");

                    if (!chkFunctionId.Checked)
                        continue;

                    var chkRead = (HtmlInputCheckBox)grdPermission.Rows[i].FindControl("chkRead");
                    if (chkRead.Checked)
                    {
                        var gp = GetGroupPermission(int.Parse(chkFunctionId.Value), int.Parse(chkRead.Value));
                        groupPermissions.Add(gp);
                    }

                    var chkInsert = (HtmlInputCheckBox)grdPermission.Rows[i].FindControl("chkInsert");
                    if (chkInsert.Checked)
                    {
                        var gp = GetGroupPermission(int.Parse(chkFunctionId.Value), int.Parse(chkInsert.Value));
                        groupPermissions.Add(gp);
                    }

                    var chkUpdate = (HtmlInputCheckBox)grdPermission.Rows[i].FindControl("chkUpdate");
                    if (chkUpdate.Checked)
                    {
                        var gp = GetGroupPermission(int.Parse(chkFunctionId.Value), int.Parse(chkUpdate.Value));
                        groupPermissions.Add(gp);
                    }

                    var chkDelete = (HtmlInputCheckBox)grdPermission.Rows[i].FindControl("chkDelete");
                    if (!chkDelete.Checked)
                        continue;

                    var gpDel = GetGroupPermission(int.Parse(chkFunctionId.Value), int.Parse(chkDelete.Value));
                    groupPermissions.Add(gpDel);
                }
                return groupPermissions;
            }
            set
            {
                groupPermissions = value;
            }
        }

        private GroupPermission GetGroupPermission(int functionId, int mash)
        {
            return new GroupPermission
            {
                FunctionId = functionId,
                Mash = mash,
                Active = true,
                Deleted = false,
                CreateBy = LoginInfo.Username,
                CreateDate = DateTime.Now,
                UpdateBy = LoginInfo.Username,
                UpdateDate = DateTime.Now
            };
        }*/
    }
}
