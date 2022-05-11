namespace MUSIC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THELOAI")]
    public partial class THELOAI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THELOAI()
        {
            BAIHATs = new HashSet<BAIHAT>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idtheloai { get; set; }

        public int? idchude { get; set; }

        [Required]
        [StringLength(50)]
        public string tentheloai { get; set; }

        [Required]
        [StringLength(50)]
        public string hinhtheloai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAIHAT> BAIHATs { get; set; }

        public virtual CHUDE CHUDE { get; set; }
    }
}
