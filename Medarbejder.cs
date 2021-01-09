namespace DealerProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Medarbejder")]
    public partial class Medarbejder
    {
        public int MedarbejderID { get; set; }

        public int ForhandlerID { get; set; }

        [Required]
        [StringLength(30)]
        public string MedarbejderNavn { get; set; }

        public int MedarbejderTelefon { get; set; }

        public bool SuperBruger { get; set; }

        public virtual Forhandler Forhandler { get; set; }
    }
}
