namespace MUSIC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("BAIHAT")]
    public partial class BAIHAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BAIHAT()
        {
            Comments = new HashSet<Comment>();
            CT_luotthich = new HashSet<CT_luotthich>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="ID bài hát")]
        public int idbaihat { get; set; }

        public int? idtheloai { get; set; }

        public int? idalbum { get; set; }

        public int? idplaylist { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên bài hát")]

        public string tenbaihat { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Hình bài hát")]

        public string hinhbaihat { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Ca sĩ thực hiện")]

        public string casi { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Audio")]

        public string linkbaihat { get; set; }
        [Required]
        [StringLength(int.MaxValue)]
        [Display(Name ="Lyrics")]
        public string lyrics { get; set; }

        public int? luotthich { get; set; }
        public int? luotxem { get; set; }


        public virtual ALBUM ALBUM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_luotthich> CT_luotthich { get; set; }

        public virtual PLAYLIST PLAYLIST { get; set; }

        public virtual THELOAI THELOAI { get; set; }
        public List<BAIHAT> searchByKey(string key)
        {
            DBcontent db = new DBcontent();
            return db.BAIHATs.SqlQuery("Select * from BAIHAT where lyrics like N'%" + key+ "%' or tenbaihat like N'%" + key + "%'").ToList();
        }
        [NotMapped]

        public System.Web.HttpPostedFileBase ImgBH { get; set; }
        [NotMapped]

        public System.Web.HttpPostedFileBase Audio { get; set; }
    }
}
