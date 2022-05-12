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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idbaihat { get; set; }

        public int? idtheloai { get; set; }

        public int? idalbum { get; set; }

        public int? idplaylist { get; set; }

        [Required]
        [StringLength(50)]
        public string tenbaihat { get; set; }

        [Required]
        [StringLength(50)]
        public string hinhbaihat { get; set; }

        [Required]
        [StringLength(50)]
        public string casi { get; set; }

        [Required]
        [StringLength(50)]
        public string linkbaihat { get; set; }

        public virtual ALBUM ALBUM { get; set; }

        public virtual PLAYLIST PLAYLIST { get; set; }

        public virtual THELOAI THELOAI { get; set; }
    }
}
