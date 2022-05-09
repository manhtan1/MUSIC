namespace MUSIC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUANGCAO")]
    public partial class QUANGCAO
    {
        [Key]
        public int STT { get; set; }

        [Required]
        [StringLength(200)]
        public string TenCongTy { get; set; }

        [StringLength(20)]
        public string HinhMinhHoa { get; set; }

        [Column(TypeName = "text")]
        public string Href { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHetHan { get; set; }
    }
}
