using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MUSIC.Models
{
    public partial class DBcontent : DbContext
    {
        public DBcontent()
            : base("name=DBcontent1")
        {
        }

        public virtual DbSet<ALBUM> ALBUMs { get; set; }
        public virtual DbSet<BAIHAT> BAIHATs { get; set; }
        public virtual DbSet<CHUDE> CHUDEs { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CT_luotthich> CT_luotthich { get; set; }
        public virtual DbSet<PLAYLIST> PLAYLISTs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<THANHVIEN> THANHVIENs { get; set; }
        public virtual DbSet<THELOAI> THELOAIs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BAIHAT>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.BAIHAT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BAIHAT>()
                .HasMany(e => e.CT_luotthich)
                .WithRequired(e => e.BAIHAT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.TenDN)
                .IsUnicode(false);

            modelBuilder.Entity<CT_luotthich>()
                .Property(e => e.TenDN)
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
                .HasMany(e => e.Comments)
                .WithRequired(e => e.THANHVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THANHVIEN>()
                .HasMany(e => e.CT_luotthich)
                .WithRequired(e => e.THANHVIEN)
                .WillCascadeOnDelete(false);
        }
    }
}
