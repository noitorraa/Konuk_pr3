namespace ConsoleApp2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Companii")]
    public partial class Companii
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Companii()
        {
            Vakansii = new HashSet<Vakansii>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Companii { get; set; }

        [Required]
        [StringLength(20)]
        public string Naimenovanie { get; set; }

        [Required]
        [StringLength(20)]
        public string Familia_directora { get; set; }

        [Required]
        [StringLength(20)]
        public string Imea_directora { get; set; }

        [StringLength(20)]
        public string Otchestvo_directora { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vakansii> Vakansii { get; set; }
    }
}
