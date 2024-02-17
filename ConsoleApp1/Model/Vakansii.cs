namespace ConsoleApp1.Model
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

        public int id_companii { get; set; }

        [Required]
        [StringLength(50)]
        public string Trebovania { get; set; }

        [Column(TypeName = "money")]
        public decimal Zarplata { get; set; }

        [Column("Data publikacii", TypeName = "date")]
        public DateTime? Data_publikacii { get; set; }

        public int? Telefon { get; set; }

        public virtual Companii Companii { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Otklik> Otklik { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sobesedovanie> Sobesedovanie { get; set; }
    }
}
