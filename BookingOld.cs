namespace DealerProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookingOld")]
    public partial class BookingOld
    {
        public int BookingID { get; set; }

        [Required]
        [StringLength(50)]
        public string KundeEmail { get; set; }

        public DateTime BookTime { get; set; }

        [Required]
        [StringLength(50)]
        public string KundeNavn { get; set; }

        [Required]
        [StringLength(50)]
        public string ForhandlerNavn { get; set; }

        [Required]
        [StringLength(50)]
        public string BilModel { get; set; }

        public virtual Bil Bil { get; set; }

        public virtual Forhandler Forhandler { get; set; }

        public virtual Kunde Kunde { get; set; }

        public virtual Medarbejder Medarbejder { get; set; }
    }
}
