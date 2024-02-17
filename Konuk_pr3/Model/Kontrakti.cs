namespace Konuk_pr3.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kontrakti")]
    public partial class Kontrakti
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_kontrakta { get; set; }

        public int ID_sotrudnika { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data_nachala_kontrakta { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Data_okonchania_kontrakta { get; set; }

        [Column(TypeName = "money")]
        public decimal Zarplata { get; set; }

        [Required]
        [StringLength(20)]
        public string Graphic_raboti { get; set; }

        public virtual Sotrudniki Sotrudniki { get; set; }
    }
}
