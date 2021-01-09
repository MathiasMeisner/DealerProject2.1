namespace DealerProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kunde")]
    public partial class Kunde
    {
        [Key]
        [StringLength(50)]
        public string KundeEmail { get; set; }

        [Required]
        [StringLength(30)]
        public string Navn { get; set; }

        public int Telefon { get; set; }
    }
}
