namespace ConsoleApp2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vakansii")]
    public partial class Vakansii
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vakansii()
        {
            Otklik = new HashSet<Otklik>();
            Sobesedovanie = new HashSet<Sobesedovanie>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_vakansii { get; set; }

        public int ID_kompanii { get; set; }

        [Required]
        [StringLength(20)]
        public string Trebovania { get; set; }

        [Column(TypeName = "money")]
        public decimal Zarplata { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Data_publikacii { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Telephon { get; set; }

        public virtual Companii Companii { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Otklik> Otklik { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sobesedovanie> Sobesedovanie { get; set; }
    }
}
