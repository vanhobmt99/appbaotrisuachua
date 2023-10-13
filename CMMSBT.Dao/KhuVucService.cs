using Azure.Core;
using CMMSBT.Domain;
using CMMSBT.Util;
using CMMSBT.ApiModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMMSBT.Dao
{
    public interface IKhuVucService
    {
        Task<Khuvuc?> Get(string ma);
        Task<List<Khuvuc>> GetList(string keyword);
        Task<ApiResult<bool>> PostKhuVuc(KhuVucModel model); 
        Task<bool> IsInUse(string ma);
        Task<ApiResult<bool>> Delete(string[] OrderIDs);
        Task<bool> UpdateSort(string Makv, int Orders);
    }
    public class KhuVucService: IKhuVucService
    {
        private readonly CmmsbtContext _db;
        public KhuVucService(CmmsbtContext context,
            HttpClient client)
        {
            this._db = context;
        }
        public async Task<Khuvuc?> Get(string ma)
        {
            return await _db.Khuvucs.SingleOrDefaultAsync(p => p.Makv.Equals(ma));
        }       

        public async Task<List<Khuvuc>> GetList(string keyword)
        {
            var data = _db.Khuvucs.Where(s => s.Dacbiet.Equals(true));
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where(s=>s.Tenkv!.Contains(keyword));                
            }
            return await data.OrderBy(p => p.Orders).ToListAsync();

        }
       
        public async Task<ApiResult<bool>> PostKhuVuc(KhuVucModel model)
        {
            /*var objDb = await Get(Makv);
            if (objDb != null)
            {
                return new ApiErrorResult<bool>("Tài khoản đã tồn tại");
            }*/           

            if (model.Makv != "0")
            {
                var objDb = await Get(model.Makv);
                if (objDb != null)
                {
                    objDb.Tenkv = model.Tenkv;
                    await _db.SaveChangesAsync();
                }
            }
            else
            {
                int IdMakv = 0;
                int? intNoMakv = await _db.Khuvucs.MaxAsync(u => u == null ? 0 : Convert.ToInt32(u.Makv));
                IdMakv = Convert.ToInt32(intNoMakv) + 1;

                int no_order = 0;
                int? intNo = await _db.Khuvucs.MaxAsync(u => u == null ? 0 : (int?)u.Orders);
                no_order = Convert.ToInt32(intNo) + 1;

                var objDb = new Khuvuc
                {
                    Makv = IdMakv.ToString(),
                    Tenkv = model.Tenkv,
                    Orders = no_order,
                    Dacbiet = true,
                };

                _db.Khuvucs.Add(objDb);
                await _db.SaveChangesAsync();
            }
            return new ApiSuccessResult<bool>();            
          
        }      
        

        public async Task<bool> IsInUse(string ma)
        {           
            if (await _db.Nhanviens.Where(p => p.Makv!.Equals(ma)).CountAsync() > 0)
                return true;            

            return false;
        }

        public async Task<ApiResult<bool>> Delete(string[] OrderIDs)
        {
            bool check = false;
            foreach (string ids in OrderIDs)
            {
                var vps = _db.Khuvucs.Where(n => n.Makv == ids).ToList();
                if (vps != null)
                {
                    foreach (var o in vps)
                    {
                        _db.Khuvucs.Remove(o);
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

        public async Task<bool> UpdateSort(string Makv, int Orders)
        {
            bool check = false;
            var objDb = await Get(Makv);
            if (objDb != null)
            {
                objDb.Orders = Orders;
                await _db.SaveChangesAsync();
                check = true;
            }   
            if(check == true)           
                 return true;            
            else           
                return false;
                
        }

        private bool KhuvucExists(string id)
        {
            return (_db.Khuvucs?.Any(e => e.Makv == id)).GetValueOrDefault();
        }

    }
   
}
