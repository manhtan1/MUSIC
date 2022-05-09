namespace MUSIC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIDEO")]
    public partial class VIDEO
    {
        [Key]
        public int MaVD { get; set; }

        [Column(TypeName = "text")]
        public string URLVideoL { get; set; }

        [Column(TypeName = "text")]
        public string URLVideoN { get; set; }

        [Column(TypeName = "ntext")]
        public string TenVD { get; set; }

        public int? MaTL { get; set; }

        [StringLength(100)]
        public string TacGia { get; set; }

        [StringLength(50)]
        public string CaSi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayCapNhat { get; set; }

        public int? LuotXemVideo { get; set; }

        public virtual THELOAI THELOAI { get; set; }
    }
}
