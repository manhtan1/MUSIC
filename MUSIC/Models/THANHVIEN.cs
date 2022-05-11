namespace MUSIC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THANHVIEN")]
    public partial class THANHVIEN
    {
        [StringLength(50)]
        public string HoTen { get; set; }

        [Key]
        [StringLength(50)]
        public string TenDN { get; set; }

        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }

        [StringLength(20)]
        public string DienThoai { get; set; }

        public int? Tuoi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDangKy { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string GioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        public string CauHoiBaoMat { get; set; }

        [StringLength(50)]
        public string CauTraLoi { get; set; }
    }
}
