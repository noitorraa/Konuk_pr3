namespace Konuk_pr3.Model
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
        public int ID_sotrudnika { get; set; }

        public int ID_dolzhnosti { get; set; }

        public int id_user { get; set; }

        [Required]
        [RegularExpression(@"[Р-пр-џA-za-z]+$")]
        [StringLength(20, MinimumLength = 3)]
        public string Imea { get; set; }

        [Required]
        [RegularExpression(@"[Р-пр-џA-za-z]+$")]
        [StringLength(20, MinimumLength = 3)]
        public string Familia { get; set; }

        [RegularExpression(@"[Р-пр-џA-za-z]+$")]
        [StringLength(20, MinimumLength = 3)]
        public string Otchestvo { get; set; }

        [StringLength(20, MinimumLength = 1)]
        public string Adres { get; set; }

        [StringLength(20)]
        [RegularExpression(@"8\([0-9][0-9][0-9]\)-[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]")]
        public string Telephon { get; set; }

        public virtual Dolzhnosti Dolzhnosti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kontrakti> Kontrakti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sobesedovanie> Sobesedovanie { get; set; }

        public virtual User User { get; set; }
    }
}
