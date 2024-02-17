namespace ConsoleApp1.Model
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
        public int id_otklik { get; set; }

        public int id_vakansii { get; set; }

        public int id_kondidata { get; set; }

        public virtual Kandidati Kandidati { get; set; }

        public virtual Vakansii Vakansii { get; set; }
    }
}
