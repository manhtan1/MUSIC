namespace MUSIC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PLAYLIST")]
    public partial class PLAYLIST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PLAYLIST()
        {
            BAIHATs = new HashSet<BAIHAT>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="Mã Ca sĩ")]
        public int idplaylist { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên ca sĩ")]

        public string ten { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Hình Minh họa")]

        public string hinhnen { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Hình ảnh ca sĩ")]
        public string hinhicon { get; set; }
        [NotMapped]

        public System.Web.HttpPostedFileBase ImgPlaylist { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAIHAT> BAIHATs { get; set; }
    }
}
