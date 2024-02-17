namespace Konuk_pr3.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NavikiKandidata")]
    public partial class NavikiKandidata
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NavikiKandidata()
        {
            Kandidati = new HashSet<Kandidati>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_navika_kondidata { get; set; }

        public int ID_kandidata { get; set; }

        public int ID_navika { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kandidati> Kandidati { get; set; }

        public virtual Kandidati Kandidati1 { get; set; }

        public virtual Navik Navik { get; set; }
    }
}
