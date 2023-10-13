using CMMSBT.Domain;
using CMMSBT.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CMMSBT.Dao
{
    public interface IGroupService
    {
        Task<Group?> Get(int Id);
        Task<List<Group>> GetList(string keyword);
        Task<List<Group>> GetListByMaNV(string manv);
        Task<ApiResult<bool>> PostGroup(int Id, Group objUi);       
        Task<ApiResult<bool>> Delete(int[] OrderIDs);
    }
    public class GroupService: IGroupService
    {
        private readonly CmmsbtContext _db;
        public GroupService(CmmsbtContext context)
        {
            this._db = context;
        }
        public async Task<Group?> Get(int Id)
        {
            return await _db.Groups.SingleOrDefaultAsync(p => p.Id.Equals(Id) && p.Deleted.Equals(false));
        }
        
        public async Task<List<Group>> GetList(string keyword)
        { 
            var data = _db.Groups.Where(s => s.Deleted.Equals(false));
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where(s=>s.Name!.Contains(keyword));                
            }
            return await data.OrderBy(p => p.Id).ToListAsync();
        }
        public async Task<List<Group>> GetListByMaNV(string manv)
        {
            return await _db.Groups.Where(p => p.Active.Equals(true) && p.Deleted.Equals(false) && p.CreateBy.ToUpper().Equals(manv.ToUpper())).ToListAsync();
        }
        public async Task<ApiResult<bool>> PostGroup(int Id, Group objUi)
        {
            if (Id >0)
            {
                var objDb = await Get(Id);
                if (objDb != null)
                {
                    objDb.Name = objUi.Name;
                    objDb.Description = objUi.Description;

                    foreach (var groupPermission in objDb.GroupPermissions)
                    {
                        _db.GroupPermissions.Remove(groupPermission);
                    }
                    await _db.SaveChangesAsync();

                    objDb.GroupPermissions = objUi.GroupPermissions;
                    objDb.Active = objUi.Active;
                    objDb.UpdateDate = DateTime.Now;
                    objDb.UpdateBy = objUi.UpdateBy;
                    await _db.SaveChangesAsync();
                }
            }
            else
            {
                var objDbAdd = new Group
                {
                    Name = objUi.Name,
                    Description = objUi.Description,                    
                    Deleted = false,
                    Active = true,
                    CreateDate = DateTime.Now,
                    CreateBy = objUi.CreateBy,
                    UpdateDate = DateTime.Now,
                    UpdateBy = objUi.UpdateBy
                };

                _db.Groups.Add(objDbAdd);
                await _db.SaveChangesAsync();
            }
            return new ApiSuccessResult<bool>();

        }
        public async Task<ApiResult<bool>> Delete(int[] OrderIDs)
        {
            bool check = false;
            foreach (int ids in OrderIDs)
            {
                var vps = _db.Groups.Where(n => n.Id == ids).ToList();
                if (vps != null)
                {
                    foreach (var o in vps)
                    {
                        _db.Groups.Remove(o);
                    }
                    check = true;
                }
            }
            if (check == true)
            {
                await _db.SaveChangesAsync();
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Xóa không thành công");

        }
    }
}
