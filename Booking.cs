namespace DealerProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        public int BookingID { get; set; }

        public int ForhandlerID { get; set; }

        [Required]
        [StringLength(50)]
        public string KundeEmail { get; set; }

        public int BilID { get; set; }

        public int MedarbejderID { get; set; }

        public DateTime BookTime { get; set; }

        public virtual Bil Bil { get; set; }

        public virtual Forhandler Forhandler { get; set; }

        public virtual Kunde Kunde { get; set; }

        public virtual Medarbejder Medarbejder { get; set; }
    }
}
