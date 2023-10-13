using CMMSBT.Domain;
using Microsoft.EntityFrameworkCore;

namespace CMMSBT.Dao
{
    public interface INhanVienService
    {
        Task<Nhanvien?> Get(int Manv);
        Task<string?> GetMaKhuVuc(int Manv);
        Task<List<Nhanvien>> GetList();
        Task<List<Nhanvien>> GetListByKhuVuc(string MaKV);
        Task<List<Nhanvien>> GetListByMaNV(int MaNV);
        Task<List<Nhanvien>> GetList(String tennv, String khuvuc, String phongban, String congviec);
        Task<List<Nhanvien>> GetListByPB(string maPb);
        Task<List<Nhanvien>> GetListByCV(string maCv);
        Task<int> Count();
        NHANVIENTT ConvertFormNhanVien(Nhanvien objui);
    }
    public class NhanVienService: INhanVienService
    {
        private readonly CmmsbtContext _dbcontext;
        public NhanVienService(CmmsbtContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        public async Task<Nhanvien?> Get(int Manv)
        {
            return await _dbcontext.Nhanviens.Where(a => a.Manv.Equals(Manv)).SingleOrDefaultAsync();
        }

        public async Task<string?> GetMaKhuVuc(int Manv)
        {
            return await _dbcontext.Nhanviens.Where(x => x.Manv == Manv).Select(x => x.Makv).SingleOrDefaultAsync();
        }

        public async Task<List<Nhanvien>> GetList()
        {
            return await _dbcontext.Nhanviens.OrderBy(p => p.Hoten).ToListAsync();
        }
        public async Task<List<Nhanvien>> GetListByKhuVuc(string MaKV)
        {
            return await _dbcontext.Nhanviens.Where(p => p.Makv!.Equals(MaKV)).OrderBy(p => p.Hoten).ToListAsync();
        }
        public async Task<List<Nhanvien>> GetListByMaNV(int MaNV)
        {
            return await _dbcontext.Nhanviens.Where(p => p.Manv.Equals(MaNV)).ToListAsync();
        }
        public async Task<List<Nhanvien>> GetList(string tennv, String khuvuc, String phongban, String congviec)
        {
            var query = _dbcontext.Nhanviens.AsNoTracking();

            if (!String.IsNullOrEmpty(tennv))
                query = query.Where(nv => nv.Hoten!.ToUpper().Contains(tennv.ToUpper()));

            if (!String.IsNullOrEmpty(khuvuc) && khuvuc != "%")
                query = query.Where(nv => nv.Makv!.ToUpper().Equals(khuvuc.ToUpper()));

            if (!String.IsNullOrEmpty(phongban) && phongban != "%")
                query = query.Where(nv => nv.Mapb!.ToUpper().Equals(phongban.ToUpper()));

            if (!String.IsNullOrEmpty(congviec) && congviec != "%")
                query = query.Where(nv => nv.Macv!.ToUpper().Equals(congviec.ToUpper()));

            return await query.OrderBy(p => p.Hoten).ToListAsync();
        }

        public async Task<List<Nhanvien>> GetListByPB(string maPb)
        {
            return await _dbcontext.Nhanviens.Where(p => p.Mapb!.Equals(maPb)).ToListAsync();
        }

        public async Task<List<Nhanvien>> GetListByCV(string maCv)
        {
            return await _dbcontext.Nhanviens.Where(p => p.Macv!.Equals(maCv)).ToListAsync();
        }

        public async Task<int> Count()
        {
            return await _dbcontext.Nhanviens.CountAsync();
        }
        public NHANVIENTT ConvertFormNhanVien(Nhanvien objui)
        {
            NHANVIENTT obj = new NHANVIENTT();
            obj.Manv = objui.Manv;
            obj.Hoten = objui.Hoten!;
            obj.Mapb = objui.Mapb!;
            obj.Macv = objui.Macv!;
            obj.Makv = objui.Makv!;
            obj.Madonvi = objui.Madonvi!;
            obj.Tenkv = objui.MakvNavigation != null ? objui.MakvNavigation.Tenkv! : "";

            return obj;
        }
    }
    public class NHANVIENTT
    {

        public NHANVIENTT()
        {

        }

        public NHANVIENTT(int manv, string tennv, int? matt, string mapb, string makv, string macv, int madv, string tenkv)
        {
            Manv = manv;
            Hoten = tennv;
            Matt = matt;
            Mapb = mapb;
            Makv = makv;
            Macv = macv;
            Madonvi = madv;
            Tenkv = tenkv;
        }
        public int Manv { get; set; }
        public string Hoten { get; set; }
        public int? Matt { get; set; }
        public string Mapb { get; set; }
        public string Makv { get; set; }
        public string Macv { get; set; }
        public int Madonvi { get; set; }
        public string Tenkv { get; set; }
    }
}