namespace Konuk_pr3.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Otklik")]
    public partial class Otklik
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_otklik { get; set; }

        public int ID_vakansii { get; set; }

        public int ID_kandidata { get; set; }

        public virtual Kandidati Kandidati { get; set; }

        public virtual Vakansii Vakansii { get; set; }
    }
}
