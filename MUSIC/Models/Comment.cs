namespace MUSIC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string TenDN { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idbaihat { get; set; }

        [Column("comment")]
        public string comment1 { get; set; }

        public DateTime? ngaycmt { get; set; }

        public virtual BAIHAT BAIHAT { get; set; }

        public virtual THANHVIEN THANHVIEN { get; set; }
    }
}
