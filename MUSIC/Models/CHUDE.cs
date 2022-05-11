namespace MUSIC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHUDE")]
    public partial class CHUDE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHUDE()
        {
            THELOAIs = new HashSet<THELOAI>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idchude { get; set; }

        [Required]
        [StringLength(50)]
        public string tenchude { get; set; }

        [Required]
        [StringLength(50)]
        public string hinhchude { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THELOAI> THELOAIs { get; set; }
    }
}
