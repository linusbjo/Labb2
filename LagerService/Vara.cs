namespace LagerService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vara")]
    public partial class Vara
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Namn { get; set; }

        public double? Pris { get; set; }

        public int? Antal { get; set; }
    }
}
