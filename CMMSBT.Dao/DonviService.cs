using CMMSBT.ApiModels;
using CMMSBT.Domain;
using CMMSBT.Util;
using Microsoft.EntityFrameworkCore;

namespace CMMSBT.Dao
{
    public interface IDonViService
    {
        Task<Donvi?> Get(int ma);
        Task<List<Donvi>> GetList(string? keyword);
        List<Donvi> GetLists(int? id);
        Task<ApiResult<bool>> PostDonVi(DonViModel model);
        Task<bool> IsInUse(int ma);
        Task<ApiResult<bool>> Delete(int[] OrderIDs);
    }

    public class DonViService : IDonViService
    {
        private readonly CmmsbtContext _db;
        public DonViService(CmmsbtContext context,
            HttpClient client)
        {
            this._db = context;
        }
        public async Task<Donvi?> Get(int ma)
        {
            return await _db.Donvis.SingleOrDefaultAsync(p => p.Madv.Equals(ma));
        }
        public async Task<List<Donvi>> GetList(string? keyword)
        {
            var data = _db.Donvis.AsQueryable(); // Create an IQueryable

            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where(s => s.Tendonvi!.Contains(keyword));
            }

            return await data.OrderBy(p => p.Tendonvi).ToListAsync();
        }
        public List<Donvi> GetLists(int? id)
        {
            var data = _db.Donvis.AsNoTracking();
            if (id > 0)
            {
                data = data.Where(s => s.Madv.Equals(id));
            }
            return data.OrderBy(p => p.Madv).ToList();
        }

        public async Task<ApiResult<bool>> PostDonVi(DonViModel model)
        {
            if (model.Madv > 0)
            {
                var objDb = await Get(model.Madv);
                if (objDb != null)
                {
                    // Update the existing Donvi
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
                }
            }
            else
            {
                // Create a new Donvi
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
                _db.Donvis.Add(objDb);
            }

            await _db.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }


        public async Task<bool> IsInUse(int ma)
        {
            if (await _db.Nhanviens.Where(p => p.Makv!.Equals(ma)).CountAsync() > 0)
                return true;

            return false;
        }

        public async Task<ApiResult<bool>> Delete(int[] OrderIDs)
        {
            bool check = false;
            foreach (int ids in OrderIDs)
            {
                var vps = _db.Donvis.Where(n => n.Madv == ids).ToList();
                if (vps != null)
                {
                    foreach (var o in vps)
                    {
                        _db.Donvis.Remove(o);
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





        private bool KhuvucExists(int? id)
        {
            return (_db.Donvis?.Any(e => e.Madv == id)).GetValueOrDefault();
        }

    }

}
