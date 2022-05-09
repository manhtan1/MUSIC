using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MUSIC.Models
{
    public partial class DbContent : DbContext
    {
        public DbContent()
            : base("name=DbContent")
        {
        }

        public virtual DbSet<BAIHAT> BAIHATs { get; set; }
        public virtual DbSet<QUANGCAO> QUANGCAOs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<THANHVIEN> THANHVIENs { get; set; }
        public virtual DbSet<THELOAI> THELOAIs { get; set; }
        public virtual DbSet<VIDEO> VIDEOs { get; set; }
        public virtual DbSet<YEUCAU> YEUCAUs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BAIHAT>()
                .Property(e => e.URLBaiHat)
                .IsUnicode(false);

            modelBuilder.Entity<QUANGCAO>()
                .Property(e => e.HinhMinhHoa)
                .IsUnicode(false);

            modelBuilder.Entity<QUANGCAO>()
                .Property(e => e.Href)
                .IsUnicode(false);

            modelBuilder.Entity<THANHVIEN>()
                .Property(e => e.TenDN)
                .IsUnicode(false);

            modelBuilder.Entity<THANHVIEN>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<THANHVIEN>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<THANHVIEN>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<THANHVIEN>()
                .HasMany(e => e.YEUCAUs)
                .WithRequired(e => e.THANHVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VIDEO>()
                .Property(e => e.URLVideoL)
                .IsUnicode(false);

            modelBuilder.Entity<VIDEO>()
                .Property(e => e.URLVideoN)
                .IsUnicode(false);

            modelBuilder.Entity<YEUCAU>()
                .Property(e => e.TenDN)
                .IsUnicode(false);
        }
    }
}
