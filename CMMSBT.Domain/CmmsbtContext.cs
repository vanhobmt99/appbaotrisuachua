using Microsoft.EntityFrameworkCore;

namespace CMMSBT.Domain;

public partial class CmmsbtContext : DbContext
{
    public CmmsbtContext()
    {
    }

    public CmmsbtContext(DbContextOptions<CmmsbtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bophan> Bophans { get; set; }

    public virtual DbSet<Chitietcv> Chitietcvs { get; set; }

    public virtual DbSet<Chitietkehoach> Chitietkehoaches { get; set; }

    public virtual DbSet<Chitietpbt> Chitietpbts { get; set; }

    public virtual DbSet<Chitietthaythe> Chitietthaythes { get; set; }

    public virtual DbSet<Congviec> Congviecs { get; set; }

    public virtual DbSet<CrmFunction> CrmFunctions { get; set; }

    public virtual DbSet<Donvi> Donvis { get; set; }

    public virtual DbSet<Donvitinh> Donvitinhs { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupPermission> GroupPermissions { get; set; }

    public virtual DbSet<Hangsanxuat> Hangsanxuats { get; set; }

    public virtual DbSet<Kehoachbaotri> Kehoachbaotris { get; set; }

    public virtual DbSet<Kehoachnam> Kehoachnams { get; set; }

    public virtual DbSet<Kho> Khos { get; set; }

    public virtual DbSet<Khonhap> Khonhaps { get; set; }

    public virtual DbSet<Khoxuat> Khoxuats { get; set; }

    public virtual DbSet<Khuvuc> Khuvucs { get; set; }

    public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    public virtual DbSet<Nhomthietbi> Nhomthietbis { get; set; }

    public virtual DbSet<Nuocsanxuat> Nuocsanxuats { get; set; }

    public virtual DbSet<Phieubaotri> Phieubaotris { get; set; }

    public virtual DbSet<Phongban> Phongbans { get; set; }

    public virtual DbSet<Phutung> Phutungs { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Tailieu> Tailieus { get; set; }

    public virtual DbSet<Thietbi> Thietbis { get; set; }

    public virtual DbSet<Thongsobp> Thongsobps { get; set; }

    public virtual DbSet<Thongsopt> Thongsopts { get; set; }

    public virtual DbSet<Thongsotb> Thongsotbs { get; set; }

    public virtual DbSet<UserAdmin> UserAdmins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=HOVAN;Database=CMMSBT;User ID=sa;Password=123456;Trusted_Connection=True;TrustServerCertificate=True; Encrypt=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bophan>(entity =>
        {
            entity.HasKey(e => e.Mabp);

            entity.ToTable("BOPHAN");

            entity.Property(e => e.Mabp).HasColumnName("MABP");
            entity.Property(e => e.Congdung)
                .HasColumnType("ntext")
                .HasColumnName("CONGDUNG");
            entity.Property(e => e.Ghichu)
                .HasColumnType("ntext")
                .HasColumnName("GHICHU");
            entity.Property(e => e.Hinhanh)
                .HasColumnType("ntext")
                .HasColumnName("HINHANH");
            entity.Property(e => e.Matb).HasColumnName("MATB");
            entity.Property(e => e.Ngaycn)
                .HasColumnType("datetime")
                .HasColumnName("NGAYCN");
            entity.Property(e => e.Soluong).HasColumnName("SOLUONG");
            entity.Property(e => e.Tenbp)
                .HasColumnType("ntext")
                .HasColumnName("TENBP");
            entity.Property(e => e.Xuatxu)
                .HasColumnType("ntext")
                .HasColumnName("XUATXU");

            entity.HasOne(d => d.MatbNavigation).WithMany(p => p.Bophans)
                .HasForeignKey(d => d.Matb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BOPHAN_THIETBI");
        });

        modelBuilder.Entity<Chitietcv>(entity =>
        {
            entity.HasKey(e => e.Mactcv);

            entity.ToTable("CHITIETCV");

            entity.Property(e => e.Mactcv).HasColumnName("MACTCV");
            entity.Property(e => e.Congviec1)
                .HasColumnType("ntext")
                .HasColumnName("CONGVIEC1");
            entity.Property(e => e.Congviec2).HasColumnName("CONGVIEC2");
            entity.Property(e => e.Mact).HasColumnName("MACT");

            entity.HasOne(d => d.MactNavigation).WithMany(p => p.Chitietcvs)
                .HasForeignKey(d => d.Mact)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CHITIETCV_CHITIETPBT");
        });

        modelBuilder.Entity<Chitietkehoach>(entity =>
        {
            entity.HasKey(e => new { e.Makh, e.Matb });

            entity.ToTable("CHITIETKEHOACH");

            entity.Property(e => e.Makh).HasColumnName("MAKH");
            entity.Property(e => e.Matb).HasColumnName("MATB");
            entity.Property(e => e.Loaibaotri).HasColumnName("LOAIBAOTRI");
            entity.Property(e => e.Ngayyeucau)
                .HasColumnType("date")
                .HasColumnName("NGAYYEUCAU");
            entity.Property(e => e.Thang).HasColumnName("THANG");
            entity.Property(e => e.Trangthai).HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.MakhNavigation).WithMany(p => p.Chitietkehoaches)
                .HasForeignKey(d => d.Makh)
                .HasConstraintName("FK_CHITIETKEHOACH_KEHOACHBAOTRI");

            entity.HasOne(d => d.MatbNavigation).WithMany(p => p.Chitietkehoaches)
                .HasForeignKey(d => d.Matb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CHITIETKEHOACH_THIETBI");
        });

        modelBuilder.Entity<Chitietpbt>(entity =>
        {
            entity.HasKey(e => e.Mact);

            entity.ToTable("CHITIETPBT");

            entity.Property(e => e.Mact).HasColumnName("MACT");
            entity.Property(e => e.Congviec).HasColumnName("CONGVIEC");
            entity.Property(e => e.Mapbt).HasColumnName("MAPBT");

            entity.HasOne(d => d.MapbtNavigation).WithMany(p => p.Chitietpbts)
                .HasForeignKey(d => d.Mapbt)
                .HasConstraintName("FK_CHITIETPBT_PHIEUBAOTRI");
        });

        modelBuilder.Entity<Chitietthaythe>(entity =>
        {
            entity.HasKey(e => e.Madon).HasName("PK_DONHANG");

            entity.ToTable("CHITIETTHAYTHE");

            entity.Property(e => e.Madon).HasColumnName("MADON");
            entity.Property(e => e.Mabp).HasColumnName("MABP");
            entity.Property(e => e.Makh).HasColumnName("MAKH");
            entity.Property(e => e.Mapt).HasColumnName("MAPT");
            entity.Property(e => e.Matb).HasColumnName("MATB");
            entity.Property(e => e.Ngaycn)
                .HasColumnType("datetime")
                .HasColumnName("NGAYCN");
            entity.Property(e => e.Noidung)
                .HasColumnType("ntext")
                .HasColumnName("NOIDUNG");
            entity.Property(e => e.Slbp).HasColumnName("SLBP");
            entity.Property(e => e.Slpt).HasColumnName("SLPT");

            entity.HasOne(d => d.MabpNavigation).WithMany(p => p.Chitietthaythes)
                .HasForeignKey(d => d.Mabp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DONHANG_BOPHAN");

            entity.HasOne(d => d.MakhNavigation).WithMany(p => p.Chitietthaythes)
                .HasForeignKey(d => d.Makh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DONHANG_KEHOACH");

            entity.HasOne(d => d.MaptNavigation).WithMany(p => p.Chitietthaythes)
                .HasForeignKey(d => d.Mapt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DONHANG_PHUTUNG");

            entity.HasOne(d => d.MatbNavigation).WithMany(p => p.Chitietthaythes)
                .HasForeignKey(d => d.Matb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DONHANG_THIETBI");
        });

        modelBuilder.Entity<Congviec>(entity =>
        {
            entity.HasKey(e => e.Macv);

            entity.ToTable("CONGVIEC");

            entity.Property(e => e.Macv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MACV");
            entity.Property(e => e.Tencv)
                .HasMaxLength(2000)
                .HasColumnName("TENCV");
        });

        modelBuilder.Entity<CrmFunction>(entity =>
        {
            entity.ToTable("CrmFunction");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Url).HasMaxLength(255);
        });

        modelBuilder.Entity<Donvi>(entity =>
        {
            entity.HasKey(e => e.Madv);

            entity.ToTable("DONVI");

            entity.Property(e => e.Madv).HasColumnName("MADV");
            entity.Property(e => e.Diachi)
                .HasMaxLength(2000)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Dienthoai)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DIENTHOAI");
            entity.Property(e => e.Email)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Fax)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FAX");
            entity.Property(e => e.Masothue)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MASOTHUE");
            entity.Property(e => e.Nganhang)
                .HasMaxLength(2000)
                .HasColumnName("NGANHANG");
            entity.Property(e => e.Phogiamdoc)
                .HasMaxLength(2000)
                .HasColumnName("PHOGIAMDOC");
            entity.Property(e => e.Phonghoadon)
                .HasMaxLength(2000)
                .HasColumnName("PHONGHOADON");
            entity.Property(e => e.Phongketoan)
                .HasMaxLength(2000)
                .HasColumnName("PHONGKETOAN");
            entity.Property(e => e.Phongkinhdoanh)
                .HasMaxLength(2000)
                .HasColumnName("PHONGKINHDOANH");
            entity.Property(e => e.Phongqlmang)
                .HasMaxLength(2000)
                .HasColumnName("PHONGQLMANG");
            entity.Property(e => e.So)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SO");
            entity.Property(e => e.Sotaikhoan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SOTAIKHOAN");
            entity.Property(e => e.Tenbaocao)
                .HasMaxLength(2000)
                .HasColumnName("TENBAOCAO");
            entity.Property(e => e.Tendonvi).HasColumnName("TENDONVI");
            entity.Property(e => e.Tengiamdoc)
                .HasMaxLength(2000)
                .HasColumnName("TENGIAMDOC");
            entity.Property(e => e.Tengiayto)
                .HasMaxLength(2000)
                .HasColumnName("TENGIAYTO");
            entity.Property(e => e.Vitribaocao)
                .HasMaxLength(2000)
                .HasColumnName("VITRIBAOCAO");
            entity.Property(e => e.Website)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("WEBSITE");
        });

        modelBuilder.Entity<Donvitinh>(entity =>
        {
            entity.HasKey(e => e.Madvt);

            entity.ToTable("DONVITINH");

            entity.Property(e => e.Madvt).HasColumnName("MADVT");
            entity.Property(e => e.Tendvt)
                .HasMaxLength(2000)
                .HasColumnName("TENDVT");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.ToTable("Group");

            entity.Property(e => e.CreateBy).HasMaxLength(50);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdateBy).HasMaxLength(50);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<GroupPermission>(entity =>
        {
            entity.HasKey(e => new { e.FunctionId, e.GroupId, e.Mash });

            entity.ToTable("GroupPermission");

            entity.Property(e => e.CreateBy).HasMaxLength(50);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.UpdateBy).HasMaxLength(50);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Function).WithMany(p => p.GroupPermissions)
                .HasForeignKey(d => d.FunctionId)
                .HasConstraintName("FK_GroupPermission_CrmFunction");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupPermissions)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupPermission_Group");
        });

        modelBuilder.Entity<Hangsanxuat>(entity =>
        {
            entity.HasKey(e => e.Mahsx);

            entity.ToTable("HANGSANXUAT");

            entity.Property(e => e.Mahsx).HasColumnName("MAHSX");
            entity.Property(e => e.TenHangsx)
                .HasMaxLength(2000)
                .HasColumnName("TEN_HANGSX");
        });

        modelBuilder.Entity<Kehoachbaotri>(entity =>
        {
            entity.HasKey(e => e.Makh).HasName("PK_KEHOACH");

            entity.ToTable("KEHOACHBAOTRI");

            entity.Property(e => e.Makh).HasColumnName("MAKH");
            entity.Property(e => e.Denngay)
                .HasColumnType("date")
                .HasColumnName("DENNGAY");
            entity.Property(e => e.Manvduyet).HasColumnName("MANVDUYET");
            entity.Property(e => e.Manvlap).HasColumnName("MANVLAP");
            entity.Property(e => e.Ngayduyet)
                .HasColumnType("datetime")
                .HasColumnName("NGAYDUYET");
            entity.Property(e => e.Ngaylap)
                .HasColumnType("datetime")
                .HasColumnName("NGAYLAP");
            entity.Property(e => e.Tungay)
                .HasColumnType("date")
                .HasColumnName("TUNGAY");

            entity.HasOne(d => d.ManvduyetNavigation).WithMany(p => p.KehoachbaotriManvduyetNavigations)
                .HasForeignKey(d => d.Manvduyet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KEHOACH_NHANVIEN1");

            entity.HasOne(d => d.ManvlapNavigation).WithMany(p => p.KehoachbaotriManvlapNavigations)
                .HasForeignKey(d => d.Manvlap)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KEHOACH_NHANVIEN2");
        });

        modelBuilder.Entity<Kehoachnam>(entity =>
        {
            entity.HasKey(e => new { e.Matb, e.Years });

            entity.ToTable("KEHOACHNAM");

            entity.Property(e => e.Matb).HasColumnName("MATB");
            entity.Property(e => e.Years).HasColumnName("YEARS");
            entity.Property(e => e.Dates)
                .HasColumnType("date")
                .HasColumnName("DATES");
            entity.Property(e => e.Month1).HasColumnName("MONTH1");
            entity.Property(e => e.Month10).HasColumnName("MONTH10");
            entity.Property(e => e.Month11).HasColumnName("MONTH11");
            entity.Property(e => e.Month12).HasColumnName("MONTH12");
            entity.Property(e => e.Month2).HasColumnName("MONTH2");
            entity.Property(e => e.Month3).HasColumnName("MONTH3");
            entity.Property(e => e.Month4).HasColumnName("MONTH4");
            entity.Property(e => e.Month5).HasColumnName("MONTH5");
            entity.Property(e => e.Month6).HasColumnName("MONTH6");
            entity.Property(e => e.Month7).HasColumnName("MONTH7");
            entity.Property(e => e.Month8).HasColumnName("MONTH8");
            entity.Property(e => e.Month9).HasColumnName("MONTH9");
        });

        modelBuilder.Entity<Kho>(entity =>
        {
            entity.HasKey(e => e.Makho);

            entity.ToTable("KHO");

            entity.Property(e => e.Makho).HasColumnName("MAKHO");
            entity.Property(e => e.Ghichu)
                .HasColumnType("ntext")
                .HasColumnName("GHICHU");
            entity.Property(e => e.Ngaycn)
                .HasColumnType("datetime")
                .HasColumnName("NGAYCN");
            entity.Property(e => e.Slton).HasColumnName("SLTON");
            entity.Property(e => e.Tenkho)
                .HasColumnType("ntext")
                .HasColumnName("TENKHO");
        });

        modelBuilder.Entity<Khonhap>(entity =>
        {
            entity.HasKey(e => e.Manhap).HasName("PK_NHAPKHO");

            entity.ToTable("KHONHAP");

            entity.Property(e => e.Manhap).HasColumnName("MANHAP");
            entity.Property(e => e.Ghichu)
                .HasColumnType("ntext")
                .HasColumnName("GHICHU");
            entity.Property(e => e.Manv).HasColumnName("MANV");
            entity.Property(e => e.Matb).HasColumnName("MATB");
            entity.Property(e => e.Ngaycn)
                .HasColumnType("datetime")
                .HasColumnName("NGAYCN");
            entity.Property(e => e.Ngaynhap)
                .HasColumnType("datetime")
                .HasColumnName("NGAYNHAP");
            entity.Property(e => e.Slnhap).HasColumnName("SLNHAP");
            entity.Property(e => e.Slton).HasColumnName("SLTON");

            entity.HasOne(d => d.ManvNavigation).WithMany(p => p.Khonhaps)
                .HasForeignKey(d => d.Manv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NHAPKHO_NHANVIEN");

            entity.HasOne(d => d.MatbNavigation).WithMany(p => p.Khonhaps)
                .HasForeignKey(d => d.Matb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NHAPKHO_THIETBI");
        });

        modelBuilder.Entity<Khoxuat>(entity =>
        {
            entity.HasKey(e => e.Maxuat).HasName("PK_XUATKHO");

            entity.ToTable("KHOXUAT");

            entity.Property(e => e.Maxuat).HasColumnName("MAXUAT");
            entity.Property(e => e.Ghichu)
                .HasColumnType("ntext")
                .HasColumnName("GHICHU");
            entity.Property(e => e.Manv).HasColumnName("MANV");
            entity.Property(e => e.Matb).HasColumnName("MATB");
            entity.Property(e => e.Ngaycn)
                .HasColumnType("datetime")
                .HasColumnName("NGAYCN");
            entity.Property(e => e.Ngayxuat)
                .HasColumnType("datetime")
                .HasColumnName("NGAYXUAT");
            entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

            entity.HasOne(d => d.ManvNavigation).WithMany(p => p.Khoxuats)
                .HasForeignKey(d => d.Manv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_XUATKHO_NHANVIEN");

            entity.HasOne(d => d.MatbNavigation).WithMany(p => p.Khoxuats)
                .HasForeignKey(d => d.Matb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_XUATKHO_THIETBI");
        });

        modelBuilder.Entity<Khuvuc>(entity =>
        {
            entity.HasKey(e => e.Makv);

            entity.ToTable("KHUVUC");

            entity.Property(e => e.Makv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAKV");
            entity.Property(e => e.Dacbiet).HasColumnName("DACBIET");
            entity.Property(e => e.Orders).HasColumnName("ORDERS");
            entity.Property(e => e.Tenkv)
                .HasMaxLength(2000)
                .HasColumnName("TENKV");
        });

        modelBuilder.Entity<Nhacungcap>(entity =>
        {
            entity.HasKey(e => e.Mancc);

            entity.ToTable("NHACUNGCAP");

            entity.Property(e => e.Mancc).HasColumnName("MANCC");
            entity.Property(e => e.Diachi)
                .HasMaxLength(2000)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Dienthoai)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DIENTHOAI");
            entity.Property(e => e.Ghichu).HasColumnName("GHICHU");
            entity.Property(e => e.Tenncc)
                .HasMaxLength(500)
                .HasColumnName("TENNCC");
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.Manv);

            entity.ToTable("NHANVIEN");

            entity.Property(e => e.Manv).HasColumnName("MANV");
            entity.Property(e => e.Chuky)
                .HasMaxLength(200)
                .HasColumnName("CHUKY");
            entity.Property(e => e.Diachi)
                .HasMaxLength(2000)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Hoten)
                .HasMaxLength(2000)
                .HasColumnName("HOTEN");
            entity.Property(e => e.Macv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MACV");
            entity.Property(e => e.Madonvi).HasColumnName("MADONVI");
            entity.Property(e => e.Makv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAKV");
            entity.Property(e => e.Mapb)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAPB");
            entity.Property(e => e.Ngaysinh)
                .HasColumnType("datetime")
                .HasColumnName("NGAYSINH");
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.Trangthai).HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.MacvNavigation).WithMany(p => p.Nhanviens)
                .HasForeignKey(d => d.Macv)
                .HasConstraintName("FK_NHANVIEN_CONGVIEC");

            entity.HasOne(d => d.MadonviNavigation).WithMany(p => p.Nhanviens)
                .HasForeignKey(d => d.Madonvi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NHANVIEN_DONVI");

            entity.HasOne(d => d.MakvNavigation).WithMany(p => p.Nhanviens)
                .HasForeignKey(d => d.Makv)
                .HasConstraintName("FK_NHANVIEN_KHUVUC");

            entity.HasOne(d => d.MapbNavigation).WithMany(p => p.Nhanviens)
                .HasForeignKey(d => d.Mapb)
                .HasConstraintName("FK_NHANVIEN_PHONGBAN");
        });

        modelBuilder.Entity<Nhomthietbi>(entity =>
        {
            entity.HasKey(e => e.Manhom);

            entity.ToTable("NHOMTHIETBI");

            entity.Property(e => e.Manhom).HasColumnName("MANHOM");
            entity.Property(e => e.Ghichu).HasColumnName("GHICHU");
            entity.Property(e => e.Tennhom)
                .HasMaxLength(2000)
                .HasColumnName("TENNHOM");
        });

        modelBuilder.Entity<Nuocsanxuat>(entity =>
        {
            entity.HasKey(e => e.Mansx);

            entity.ToTable("NUOCSANXUAT");

            entity.Property(e => e.Mansx).HasColumnName("MANSX");
            entity.Property(e => e.Tennuocsx)
                .HasMaxLength(2000)
                .HasColumnName("TENNUOCSX");
        });

        modelBuilder.Entity<Phieubaotri>(entity =>
        {
            entity.HasKey(e => e.Mapbt);

            entity.ToTable("PHIEUBAOTRI");

            entity.Property(e => e.Mapbt).HasColumnName("MAPBT");
            entity.Property(e => e.Ketqua)
                .HasColumnType("ntext")
                .HasColumnName("KETQUA");
            entity.Property(e => e.Loaibaocao).HasColumnName("LOAIBAOCAO");
            entity.Property(e => e.Makh).HasColumnName("MAKH");
            entity.Property(e => e.Manvkt).HasColumnName("MANVKT");
            entity.Property(e => e.Manvth).HasColumnName("MANVTH");
            entity.Property(e => e.Maso)
                .HasMaxLength(50)
                .HasColumnName("MASO");
            entity.Property(e => e.Matb).HasColumnName("MATB");
            entity.Property(e => e.Ngaylap)
                .HasColumnType("date")
                .HasColumnName("NGAYLAP");
            entity.Property(e => e.Noidungkhac)
                .HasColumnType("ntext")
                .HasColumnName("NOIDUNGKHAC");
            entity.Property(e => e.Ykien)
                .HasColumnType("ntext")
                .HasColumnName("YKIEN");

            entity.HasOne(d => d.Ma).WithMany(p => p.Phieubaotris)
                .HasForeignKey(d => new { d.Makh, d.Matb })
                .HasConstraintName("FK_PHIEUBAOTRI_CHITIETKEHOACH");
        });

        modelBuilder.Entity<Phongban>(entity =>
        {
            entity.HasKey(e => e.Mapb);

            entity.ToTable("PHONGBAN");

            entity.Property(e => e.Mapb)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAPB");
            entity.Property(e => e.Diachi)
                .HasMaxLength(2000)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Mota)
                .HasMaxLength(2000)
                .HasColumnName("MOTA");
            entity.Property(e => e.Orders).HasColumnName("ORDERS");
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.Tenpb)
                .HasMaxLength(2000)
                .HasColumnName("TENPB");
            entity.Property(e => e.Tructhuoc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TRUCTHUOC");
        });

        modelBuilder.Entity<Phutung>(entity =>
        {
            entity.HasKey(e => e.Mapt);

            entity.ToTable("PHUTUNG");

            entity.Property(e => e.Mapt).HasColumnName("MAPT");
            entity.Property(e => e.Ghichu)
                .HasColumnType("ntext")
                .HasColumnName("GHICHU");
            entity.Property(e => e.Isselected).HasColumnName("ISSELECTED");
            entity.Property(e => e.Mabp).HasColumnName("MABP");
            entity.Property(e => e.Ngaycn)
                .HasColumnType("datetime")
                .HasColumnName("NGAYCN");
            entity.Property(e => e.Soluong).HasColumnName("SOLUONG");
            entity.Property(e => e.Tenpt)
                .HasColumnType("ntext")
                .HasColumnName("TENPT");
            entity.Property(e => e.Vitri)
                .HasColumnType("ntext")
                .HasColumnName("VITRI");

            entity.HasOne(d => d.MabpNavigation).WithMany(p => p.Phutungs)
                .HasForeignKey(d => d.Mabp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PHUTUNG_BOPHAN");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RefreshToken");

            entity.Property(e => e.ExpiredAt).HasColumnType("datetime");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IssuedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Tailieu>(entity =>
        {
            entity.HasKey(e => e.Matl);

            entity.ToTable("TAILIEU");

            entity.Property(e => e.Matl).HasColumnName("MATL");
            entity.Property(e => e.Filescan)
                .HasColumnType("ntext")
                .HasColumnName("FILESCAN");
            entity.Property(e => e.Ghichu)
                .HasColumnType("ntext")
                .HasColumnName("GHICHU");
            entity.Property(e => e.Matb).HasColumnName("MATB");
            entity.Property(e => e.Ngaycn)
                .HasColumnType("datetime")
                .HasColumnName("NGAYCN");
            entity.Property(e => e.Noiluu)
                .HasColumnType("ntext")
                .HasColumnName("NOILUU");
            entity.Property(e => e.Tentl)
                .HasColumnType("ntext")
                .HasColumnName("TENTL");

            entity.HasOne(d => d.MatbNavigation).WithMany(p => p.Tailieus)
                .HasForeignKey(d => d.Matb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TAILIEU_THIETBI");
        });

        modelBuilder.Entity<Thietbi>(entity =>
        {
            entity.HasKey(e => e.Matb);

            entity.ToTable("THIETBI");

            entity.Property(e => e.Matb).HasColumnName("MATB");
            entity.Property(e => e.Chuky)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CHUKY");
            entity.Property(e => e.Congdung)
                .HasMaxLength(2000)
                .HasColumnName("CONGDUNG");
            entity.Property(e => e.Ghichu).HasColumnName("GHICHU");
            entity.Property(e => e.Hinhanh)
                .HasMaxLength(2000)
                .HasColumnName("HINHANH");
            entity.Property(e => e.Madvt).HasColumnName("MADVT");
            entity.Property(e => e.Mahsx).HasColumnName("MAHSX");
            entity.Property(e => e.Makv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAKV");
            entity.Property(e => e.Mancc).HasColumnName("MANCC");
            entity.Property(e => e.Manhom).HasColumnName("MANHOM");
            entity.Property(e => e.Mansx).HasColumnName("MANSX");
            entity.Property(e => e.Manv).HasColumnName("MANV");
            entity.Property(e => e.Model)
                .HasMaxLength(2000)
                .HasColumnName("MODEL");
            entity.Property(e => e.Ngayhetbh)
                .HasColumnType("datetime")
                .HasColumnName("NGAYHETBH");
            entity.Property(e => e.Ngaylap)
                .HasColumnType("datetime")
                .HasColumnName("NGAYLAP");
            entity.Property(e => e.Ngaysudung)
                .HasColumnType("datetime")
                .HasColumnName("NGAYSUDUNG");
            entity.Property(e => e.Noilap)
                .HasMaxLength(2000)
                .HasColumnName("NOILAP");
            entity.Property(e => e.Serial)
                .HasMaxLength(2000)
                .HasColumnName("SERIAL");
            entity.Property(e => e.Tentb)
                .HasMaxLength(2000)
                .HasColumnName("TENTB");

            entity.HasOne(d => d.MadvtNavigation).WithMany(p => p.Thietbis)
                .HasForeignKey(d => d.Madvt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_THIETBI_DONVITINH");

            entity.HasOne(d => d.MahsxNavigation).WithMany(p => p.Thietbis)
                .HasForeignKey(d => d.Mahsx)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_THIETBI_HANGSANXUAT");

            entity.HasOne(d => d.MakvNavigation).WithMany(p => p.Thietbis)
                .HasForeignKey(d => d.Makv)
                .HasConstraintName("FK_THIETBI_KHUVUC");

            entity.HasOne(d => d.ManccNavigation).WithMany(p => p.Thietbis)
                .HasForeignKey(d => d.Mancc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_THIETBI_NHACUNGCAP");

            entity.HasOne(d => d.ManhomNavigation).WithMany(p => p.Thietbis)
                .HasForeignKey(d => d.Manhom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_THIETBI_NHOMTHIETBI");

            entity.HasOne(d => d.MansxNavigation).WithMany(p => p.Thietbis)
                .HasForeignKey(d => d.Mansx)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_THIETBI_NUOCSANXUAT");

            entity.HasOne(d => d.ManvNavigation).WithMany(p => p.Thietbis)
                .HasForeignKey(d => d.Manv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_THIETBI_NHANVIEN");
        });

        modelBuilder.Entity<Thongsobp>(entity =>
        {
            entity.HasKey(e => e.Mats);

            entity.ToTable("THONGSOBP");

            entity.Property(e => e.Mats).HasColumnName("MATS");
            entity.Property(e => e.Mabp).HasColumnName("MABP");
            entity.Property(e => e.Ngaycn)
                .HasColumnType("datetime")
                .HasColumnName("NGAYCN");
            entity.Property(e => e.Tents)
                .HasColumnType("ntext")
                .HasColumnName("TENTS");

            entity.HasOne(d => d.MabpNavigation).WithMany(p => p.Thongsobps)
                .HasForeignKey(d => d.Mabp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_THONGSOBP_BOPHAN");
        });

        modelBuilder.Entity<Thongsopt>(entity =>
        {
            entity.HasKey(e => e.Mats);

            entity.ToTable("THONGSOPT");

            entity.Property(e => e.Mats).HasColumnName("MATS");
            entity.Property(e => e.Mapt).HasColumnName("MAPT");
            entity.Property(e => e.Ngaycn)
                .HasColumnType("datetime")
                .HasColumnName("NGAYCN");
            entity.Property(e => e.Tents)
                .HasColumnType("ntext")
                .HasColumnName("TENTS");

            entity.HasOne(d => d.MaptNavigation).WithMany(p => p.Thongsopts)
                .HasForeignKey(d => d.Mapt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_THONGSOPT_PHUTUNG");
        });

        modelBuilder.Entity<Thongsotb>(entity =>
        {
            entity.HasKey(e => e.Mats);

            entity.ToTable("THONGSOTB");

            entity.Property(e => e.Mats).HasColumnName("MATS");
            entity.Property(e => e.Matb).HasColumnName("MATB");
            entity.Property(e => e.Ngaycn)
                .HasColumnType("datetime")
                .HasColumnName("NGAYCN");
            entity.Property(e => e.Tents)
                .HasColumnType("ntext")
                .HasColumnName("TENTS");

            entity.HasOne(d => d.MatbNavigation).WithMany(p => p.Thongsotbs)
                .HasForeignKey(d => d.Matb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_THONGSOTB_THIETBI");
        });

        modelBuilder.Entity<UserAdmin>(entity =>
        {
            entity.ToTable("UserAdmin");

            entity.Property(e => e.CreateBy).HasMaxLength(50);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.HoTen).HasMaxLength(200);
            entity.Property(e => e.Manv).HasColumnName("MANV");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UpdateBy).HasMaxLength(50);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Username)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasMany(d => d.Groups).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "GroupUser",
                    r => r.HasOne<Group>().WithMany()
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_GroupUser_Group"),
                    l => l.HasOne<UserAdmin>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_GroupUser_UserAdmin"),
                    j =>
                    {
                        j.HasKey("UserId", "GroupId");
                        j.ToTable("GroupUser");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
