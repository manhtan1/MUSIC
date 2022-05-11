using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MUSIC.Models
{
    public partial class DBcontent : DbContext
    {
        public DBcontent()
            : base("name=DBcontent")
        {
        }

        public virtual DbSet<ALBUM> ALBUMs { get; set; }
        public virtual DbSet<BAIHAT> BAIHATs { get; set; }
        public virtual DbSet<CHUDE> CHUDEs { get; set; }
        public virtual DbSet<PLAYLIST> PLAYLISTs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<THANHVIEN> THANHVIENs { get; set; }
        public virtual DbSet<THELOAI> THELOAIs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
        }
    }
}
