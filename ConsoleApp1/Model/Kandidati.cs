namespace ConsoleApp1.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kandidati")]
    public partial class Kandidati
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kandidati()
        {
            Otklik = new HashSet<Otklik>();
            Sobesedovanie = new HashSet<Sobesedovanie>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_kandidata { get; set; }

        public int id_navikakondidata { get; set; }

        [Required]
        [StringLength(15)]
        public string Imia { get; set; }

        [Required]
        [StringLength(50)]
        public string Familia { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data_rozhdenia { get; set; }

        public int Opit_raboti { get; set; }

        [Required]
        [StringLength(15)]
        public string Obrazovanie { get; set; }

        public long? Telefon { get; set; }

        public virtual NavikiKandidata NavikiKandidata { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Otklik> Otklik { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sobesedovanie> Sobesedovanie { get; set; }
    }
}
