namespace ConsoleApp1.Model
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
        public int ID_contrakta { get; set; }

        public int ID_sotrudnika { get; set; }

        [Column("Data nachala kontrakta", TypeName = "date")]
        public DateTime Data_nachala_kontrakta { get; set; }

        [Column("Data okonchania kontrakta", TypeName = "date")]
        public DateTime? Data_okonchania_kontrakta { get; set; }

        [Column(TypeName = "money")]
        public decimal Zarplata { get; set; }

        [Column("Graphik raboti")]
        [Required]
        [StringLength(10)]
        public string Graphik_raboti { get; set; }

        public virtual Sotrudniki Sotrudniki { get; set; }
    }
}
