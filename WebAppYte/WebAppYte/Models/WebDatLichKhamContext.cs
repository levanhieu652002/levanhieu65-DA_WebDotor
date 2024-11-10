using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace WebAppYte.Models
{
    public partial class WebDatLichKhamContext : DbContext
    {
        public WebDatLichKhamContext()
        {
        }

        public WebDatLichKhamContext(DbContextOptions<WebDatLichKhamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BaiViet> BaiViets { get; set; }
        public virtual DbSet<BenhAn> BenhAns { get; set; }
        public virtual DbSet<BenhNhan> BenhNhans { get; set; }
        public virtual DbSet<CaKham> CaKhams { get; set; }
        public virtual DbSet<ChiNhanh> ChiNhanhs { get; set; }
        public virtual DbSet<DangNhap> DangNhaps { get; set; }
        public virtual DbSet<DanhGia> DanhGia { get; set; }
        public virtual DbSet<DatLich> DatLiches { get; set; }
        public virtual DbSet<DiaChiKham> DiaChiKhams { get; set; }
        public virtual DbSet<HoiDap> HoiDaps { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<Loai> Loais { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json")
                      .Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("SqlConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiViet>(entity =>
            {
                entity.HasKey(e => e.Mabv)
                    .HasName("PK__BaiViet__7A2255EC4B636982");

                entity.ToTable("BaiViet");

                entity.Property(e => e.Mabv).HasColumnName("mabv");

                entity.Property(e => e.Hinhanh)
                    .HasMaxLength(100)
                    .HasColumnName("hinhanh");

                entity.Property(e => e.Maloai).HasColumnName("maloai");

                entity.Property(e => e.Mand).HasColumnName("mand");

                entity.Property(e => e.Mota).HasColumnName("mota");

                entity.Property(e => e.Ngaydang)
                    .HasColumnType("date")
                    .HasColumnName("ngaydang");

                entity.Property(e => e.Noidung).HasColumnName("noidung");

                entity.Property(e => e.Tieude).HasColumnName("tieude");

                entity.HasOne(d => d.MaloaiNavigation)
                    .WithMany(p => p.BaiViets)
                    .HasForeignKey(d => d.Maloai)
                    .HasConstraintName("FK__BaiViet__maloai__48CFD27E");

                entity.HasOne(d => d.MandNavigation)
                    .WithMany(p => p.BaiViets)
                    .HasForeignKey(d => d.Mand)
                    .HasConstraintName("FK__BaiViet__mand__49C3F6B7");
            });

            modelBuilder.Entity<BenhAn>(entity =>
            {
                entity.HasKey(e => e.Maba)
                    .HasName("PK_dbo.BenhAn");

                entity.ToTable("BenhAn");

                entity.HasIndex(e => e.Mabn, "IX_mabn");

                entity.HasIndex(e => e.Mabs, "IX_mabs");

                entity.Property(e => e.Maba).HasColumnName("maba");

                entity.Property(e => e.Bmi).HasColumnName("bmi");

                entity.Property(e => e.Cannang).HasColumnName("cannang");

                entity.Property(e => e.Chieucao).HasColumnName("chieucao");

                entity.Property(e => e.Chuandoan).HasColumnName("chuandoan");

                entity.Property(e => e.Giokham)
                    .HasColumnType("datetime")
                    .HasColumnName("giokham");

                entity.Property(e => e.Ketqua).HasColumnName("ketqua");

                entity.Property(e => e.Mabn).HasColumnName("mabn");

                entity.Property(e => e.Mabs).HasColumnName("mabs");

                entity.Property(e => e.Mach).HasColumnName("mach");

                entity.Property(e => e.Ngaykham)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaykham");

                entity.Property(e => e.NhanapP).HasColumnName("nhanapP");

                entity.Property(e => e.NhanapT).HasColumnName("nhanapT");

                entity.Property(e => e.Nhietdo).HasColumnName("nhietdo");

                entity.Property(e => e.Nhiptho).HasColumnName("nhiptho");

                entity.Property(e => e.Thilucphai).HasColumnName("thilucphai");

                entity.Property(e => e.Thiluctrai).HasColumnName("thiluctrai");

                entity.Property(e => e.Tieude).HasColumnName("tieude");

                entity.Property(e => e.Trangthai).HasColumnName("trangthai");

                entity.HasOne(d => d.MabnNavigation)
                    .WithMany(p => p.BenhAns)
                    .HasForeignKey(d => d.Mabn)
                    .HasConstraintName("FK_dbo.BenhAn_dbo.BenhNhan_mabn");

                entity.HasOne(d => d.MabsNavigation)
                    .WithMany(p => p.BenhAns)
                    .HasForeignKey(d => d.Mabs)
                    .HasConstraintName("FK_dbo.BenhAn_dbo.NguoiDung_mabs");
            });

            modelBuilder.Entity<BenhNhan>(entity =>
            {
                entity.HasKey(e => e.Mabn)
                    .HasName("PK__BenhNhan__7A2255F4EC77B831");

                entity.ToTable("BenhNhan");

                entity.Property(e => e.Mabn).HasColumnName("mabn");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(50)
                    .HasColumnName("diachi");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email")
                    .IsFixedLength(true);

                entity.Property(e => e.Gioitinh)
                    .HasMaxLength(5)
                    .HasColumnName("gioitinh");

                entity.Property(e => e.Mk)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mk")
                    .IsFixedLength(true);

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("date")
                    .HasColumnName("ngaysinh");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sdt")
                    .IsFixedLength(true);

                entity.Property(e => e.Tenbn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tenbn");

                entity.Property(e => e.Tendn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tendn");

                entity.Property(e => e.Trangthai).HasColumnName("trangthai");
            });

            modelBuilder.Entity<CaKham>(entity =>
            {
                entity.HasKey(e => e.Maca)
                    .HasName("PK__CaKham__7A21F87DFBA45D2F");

                entity.ToTable("CaKham");

                entity.Property(e => e.Maca).HasColumnName("maca");

                entity.Property(e => e.Ca)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ca")
                    .IsFixedLength(true);

                entity.Property(e => e.Hinhthuc)
                    .HasMaxLength(30)
                    .HasColumnName("hinhthuc");

                entity.Property(e => e.Mand).HasColumnName("mand");

                entity.Property(e => e.Ngaykham)
                    .HasColumnType("date")
                    .HasColumnName("ngaykham");

                entity.Property(e => e.Trangthai).HasColumnName("trangthai");

                entity.HasOne(d => d.MandNavigation)
                    .WithMany(p => p.CaKhams)
                    .HasForeignKey(d => d.Mand)
                    .HasConstraintName("FK__CaKham__mand__4CA06362");
            });

            modelBuilder.Entity<ChiNhanh>(entity =>
            {
                entity.HasKey(e => e.Machinhanh)
                    .HasName("PK__ChiNhanh__B98FB2FB9F02B780");

                entity.ToTable("ChiNhanh");

                entity.Property(e => e.Machinhanh).HasColumnName("machinhanh");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(50)
                    .HasColumnName("diachi");
            });

            modelBuilder.Entity<DangNhap>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK__DangNhap__3213C8B737C80646");

                entity.ToTable("DangNhap");

                entity.HasIndex(e => e.Tendn, "UQ__DangNhap__FB739DEF25E948C1")
                    .IsUnique();

                entity.Property(e => e.Ma).HasColumnName("ma");

                entity.Property(e => e.Mand).HasColumnName("mand");

                entity.Property(e => e.Mk)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mk")
                    .IsFixedLength(true);

                entity.Property(e => e.Quyen).HasColumnName("quyen");

                entity.Property(e => e.Tendn)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tendn")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<DanhGia>(entity =>
            {
                entity.HasKey(e => e.Madanhgia)
                    .HasName("PK__DanhGia__7E089258038F1B8C");

                entity.Property(e => e.Madanhgia).HasColumnName("madanhgia");

                entity.Property(e => e.Mabn).HasColumnName("mabn");

                entity.Property(e => e.Mand).HasColumnName("mand");

                entity.Property(e => e.Ngay)
                    .HasColumnType("date")
                    .HasColumnName("ngay");

                entity.Property(e => e.Noidung).HasColumnName("noidung");

                entity.HasOne(d => d.MabnNavigation)
                    .WithMany(p => p.DanhGia)
                    .HasForeignKey(d => d.Mabn)
                    .HasConstraintName("FK__DanhGia__mabn__534D60F1");

                entity.HasOne(d => d.MandNavigation)
                    .WithMany(p => p.DanhGia)
                    .HasForeignKey(d => d.Mand)
                    .HasConstraintName("FK__DanhGia__mand__52593CB8");
            });

            modelBuilder.Entity<DatLich>(entity =>
            {
                entity.HasKey(e => e.Madat)
                    .HasName("PK__DatLich__0BE68C779C8183A2");

                entity.ToTable("DatLich");

                entity.Property(e => e.Madat).HasColumnName("madat");

                entity.Property(e => e.Donthuoc)
                    .HasMaxLength(511)
                    .HasColumnName("donthuoc");

                entity.Property(e => e.Hoten)
                    .HasMaxLength(30)
                    .HasColumnName("hoten");

                entity.Property(e => e.Mabn).HasColumnName("mabn");

                entity.Property(e => e.Maca).HasColumnName("maca");

                entity.Property(e => e.Mota).HasColumnName("mota");

                entity.Property(e => e.Ngaydat)
                    .HasColumnType("date")
                    .HasColumnName("ngaydat");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("date")
                    .HasColumnName("ngaysinh");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sdt")
                    .IsFixedLength(true);

                entity.Property(e => e.Trangthai).HasColumnName("trangthai");

                entity.HasOne(d => d.MacaNavigation)
                    .WithMany(p => p.DatLiches)
                    .HasForeignKey(d => d.Maca)
                    .HasConstraintName("FK__DatLich__maca__4F7CD00D");
            });

            modelBuilder.Entity<DiaChiKham>(entity =>
            {
                entity.ToTable("DiaChiKham");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.BsId).HasColumnName("bs_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.HasOne(d => d.Bs)
                    .WithMany(p => p.DiaChiKhams)
                    .HasForeignKey(d => d.BsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DiaChiKha__bs_id__6FE99F9F");
            });

            modelBuilder.Entity<HoiDap>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK__HoiDap__3213C8B7CA4B4968");

                entity.ToTable("HoiDap");

                entity.Property(e => e.Ma).HasColumnName("ma");

                entity.Property(e => e.Dap).HasColumnName("dap");

                entity.Property(e => e.Hoi).HasColumnName("hoi");

                entity.Property(e => e.Mabn).HasColumnName("mabn");

                entity.Property(e => e.Mand).HasColumnName("mand");

                entity.Property(e => e.Ngayhoi)
                    .HasColumnType("datetime")
                    .HasColumnName("ngayhoi");

                entity.Property(e => e.Ngaytl)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaytl");

                entity.Property(e => e.Trangthai).HasColumnName("trangthai");

                entity.HasOne(d => d.MabnNavigation)
                    .WithMany(p => p.HoiDaps)
                    .HasForeignKey(d => d.Mabn)
                    .HasConstraintName("FK__HoiDap__mabn__571DF1D5");

                entity.HasOne(d => d.MandNavigation)
                    .WithMany(p => p.HoiDaps)
                    .HasForeignKey(d => d.Mand)
                    .HasConstraintName("FK__HoiDap__mand__5629CD9C");
            });

            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.HasKey(e => e.Makhoa)
                    .HasName("PK__Khoa__30B01682250477C0");

                entity.ToTable("Khoa");

                entity.Property(e => e.Makhoa).HasColumnName("makhoa");

                entity.Property(e => e.Mota).HasColumnName("mota");

                entity.Property(e => e.Tenkhoa)
                    .HasMaxLength(50)
                    .HasColumnName("tenkhoa");
            });

            modelBuilder.Entity<Loai>(entity =>
            {
                entity.HasKey(e => e.Maloai)
                    .HasName("PK__Loai__734B3AEA67D4DA62");

                entity.ToTable("Loai");

                entity.Property(e => e.Maloai).HasColumnName("maloai");

                entity.Property(e => e.Tenloai).HasColumnName("tenloai");
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.Mand)
                    .HasName("PK__NguoiDun__7A21B393C7BAA166");

                entity.ToTable("NguoiDung");

                entity.Property(e => e.Mand).HasColumnName("mand");

                entity.Property(e => e.Anh).HasColumnName("anh");

                entity.Property(e => e.Chucvu).HasColumnName("chucvu");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(50)
                    .HasColumnName("diachi");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email")
                    .IsFixedLength(true);

                entity.Property(e => e.Gioithieu).HasColumnName("gioithieu");

                entity.Property(e => e.Gioitinh)
                    .HasMaxLength(5)
                    .HasColumnName("gioitinh");

                entity.Property(e => e.Hocham).HasColumnName("hocham");

                entity.Property(e => e.Hocvi).HasColumnName("hocvi");

                entity.Property(e => e.Hoten)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("hoten");

                entity.Property(e => e.Machinhanh).HasColumnName("machinhanh");

                entity.Property(e => e.Makhoa).HasColumnName("makhoa");

                entity.Property(e => e.Mk)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mk")
                    .IsFixedLength(true);

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("date")
                    .HasColumnName("ngaysinh");

                entity.Property(e => e.Quyen).HasColumnName("quyen");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sdt")
                    .IsFixedLength(true);

                entity.Property(e => e.Tendn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tendn");

                entity.Property(e => e.Trangthai).HasColumnName("trangthai");

                entity.HasOne(d => d.MachinhanhNavigation)
                    .WithMany(p => p.NguoiDungs)
                    .HasForeignKey(d => d.Machinhanh)
                    .HasConstraintName("FK__NguoiDung__machi__403A8C7D");

                entity.HasOne(d => d.MakhoaNavigation)
                    .WithMany(p => p.NguoiDungs)
                    .HasForeignKey(d => d.Makhoa)
                    .HasConstraintName("FK__NguoiDung__makho__3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
