namespace MUSIC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YEUCAU")]
    public partial class YEUCAU
    {
        [Key]
        public int STTYC { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDN { get; set; }

        public int? MaTL { get; set; }

        [StringLength(50)]
        public string Loai { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        public virtual THANHVIEN THANHVIEN { get; set; }
    }
}
