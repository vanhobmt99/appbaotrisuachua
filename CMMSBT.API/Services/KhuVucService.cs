using CMMSBT.Domain;
using CMMSBT.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMMSBT.API.Services
{
    public interface IKhuVucService
    {
        Task<Khuvuc?> Get(string ma);
        Task<List<Khuvuc>> GetList(string keyword);
        Task<bool> Insert(Khuvuc objUi);
        Task<bool> Update(Khuvuc objUi);
        Task<bool> IsInUse(string ma);
        Task<bool> Delete(Khuvuc objUi);
        Task<bool> DeleteList(List<Khuvuc> objList);
        Task<bool> UpdateSort(string Makv, int Orders);
    }
    public class KhuVucService: IKhuVucService
    {
        private readonly CmmsbtContext _db; 
        public KhuVucService(CmmsbtContext context)
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

        public async Task<bool> Insert(Khuvuc objUi)
        {
            bool check = false;
            if (objUi != null)
            {
                _db.Khuvucs.Add(objUi);
                await _db.SaveChangesAsync();
                check = true;
            }           
            if (check == true)
               return true;           
            else           
                return false;           
        }

        public async Task<bool> Update(Khuvuc objUi)
        {
            bool check = false;
            var objDb = await Get(objUi.Makv);
            if (objDb != null)
            {
                objDb.Tenkv = objUi.Tenkv;
                objDb.Dacbiet = objUi.Dacbiet;
                objDb.Orders = objUi.Orders;
                await _db.SaveChangesAsync();

                check = true;
            }
            if (check == true)            
                return true;           
            else           
                return false;            
        }

        public async Task<bool> IsInUse(string ma)
        {           
            if (await _db.Nhanviens.Where(p => p.Makv!.Equals(ma)).CountAsync() > 0)
                return true;            

            return false;
        }

        public async Task<bool> Delete(Khuvuc objUi)
        {
            bool check = false;
            var objDb = await Get(objUi.Makv);
            if (objDb != null)
            {               
                _db.Khuvucs.Remove(objDb);
                await _db.SaveChangesAsync();
                check = true;
            }
            if (check == true)                            
                return true;            
            else           
                return false;                                 
                
        }

        public async Task<bool> DeleteList(List<Khuvuc> objList)
        {
            bool check = false;
            var dem = 0;
            foreach (var obj in objList)
            {
                var temp = await Delete(obj);
                if (temp)                
                dem++;
            }

            if (dem > 0)
            {
                check = true;
            }

            if (check == true)
                return true;
            else
                return false;         
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
    }
}
