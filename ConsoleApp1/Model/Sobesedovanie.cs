namespace ConsoleApp1.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sobesedovanie")]
    public partial class Sobesedovanie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_sobesedovania { get; set; }

        public int ID_kandidata { get; set; }

        public int ID_vakansii { get; set; }

        public int id_sotrudnika { get; set; }

        public DateTime Data_i_vremia_sobesedovania { get; set; }

        [Required]
        [StringLength(15)]
        public string Rezultati_sobesedovania { get; set; }

        public virtual Kandidati Kandidati { get; set; }

        public virtual Sotrudniki Sotrudniki { get; set; }

        public virtual Vakansii Vakansii { get; set; }
    }
}
