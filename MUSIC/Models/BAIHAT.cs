namespace MUSIC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BAIHAT")]
    public partial class BAIHAT
    {
        public int Id { get; set; }

        [Column(TypeName = "text")]
        public string URLBaiHat { get; set; }

        [Column(TypeName = "ntext")]
        public string TenBH { get; set; }

        [StringLength(50)]
        public string CaSi { get; set; }

        public int? MaTL { get; set; }

        [StringLength(100)]
        public string TacGia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayCapNhat { get; set; }

        [Column(TypeName = "ntext")]
        public string LoiBaiHat { get; set; }

        public int? LuotXemBaiHat { get; set; }

        public virtual THELOAI THELOAI { get; set; }
    }
}
