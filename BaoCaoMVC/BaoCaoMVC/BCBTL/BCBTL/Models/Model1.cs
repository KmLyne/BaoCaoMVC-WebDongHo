using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BCBTL.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHang { get; set; }
        public virtual DbSet<ChiTietSanPham> ChiTietSanPham { get; set; }
        public virtual DbSet<DanhGia> DanhGia { get; set; }
        public virtual DbSet<DanhMuc> DanhMuc { get; set; }
        public virtual DbSet<DonHang> DonHang { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<QuanTriAdmin> QuanTriAdmin { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TinTuc> TinTuc { get; set; }
        public virtual DbSet<TuKhoaSanPham> TuKhoaSanPham { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonHang)
                .WithOptional(e => e.DonHang)
                .HasForeignKey(e => e.MaDonHang);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonHang1)
                .WithOptional(e => e.DonHang1)
                .HasForeignKey(e => e.MaDonHang);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.DonHang)
                .WithOptional(e => e.KhachHang)
                .HasForeignKey(e => e.MaKhachHang);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.DonHang1)
                .WithOptional(e => e.KhachHang1)
                .HasForeignKey(e => e.MaKhachHang);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietDonHang)
                .WithOptional(e => e.SanPham)
                .HasForeignKey(e => e.MaSanPham);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietDonHang1)
                .WithOptional(e => e.SanPham1)
                .HasForeignKey(e => e.MaSanPham);
        }
    }
}
