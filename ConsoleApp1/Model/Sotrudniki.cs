namespace ConsoleApp1.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sotrudniki")]
    public partial class Sotrudniki
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sotrudniki()
        {
            Kontrakti = new HashSet<Kontrakti>();
            Sobesedovanie = new HashSet<Sobesedovanie>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_sotrudnika { get; set; }

        public int ID_dolzhnost { get; set; }

        public int id_user { get; set; }

        [Required]
        [StringLength(15)]
        public string Imia { get; set; }

        [Required]
        [StringLength(15)]
        public string Familia { get; set; }

        [Required]
        [StringLength(20)]
        public string Otchestvo { get; set; }

        [StringLength(50)]
        public string Adres { get; set; }

        public long? Telefon { get; set; }

        public virtual Dolzhnosti Dolzhnosti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kontrakti> Kontrakti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sobesedovanie> Sobesedovanie { get; set; }

        public virtual User User { get; set; }
    }
}
