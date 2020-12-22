namespace DealerProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookingOld2")]
    public partial class BookingOld2
    {
        public int BookingID { get; set; }

        [Required]
        [StringLength(50)]
        public string KundeEmail { get; set; }

        public DateTime? BookTime { get; set; }

        [StringLength(50)]
        public string KundeNavn { get; set; }

        [StringLength(50)]
        public string ForhandlerNavn { get; set; }

        [StringLength(50)]
        public string BilModel { get; set; }

        public int? ForhandlerID { get; set; }

        public int? BilID { get; set; }

        public int? MedarbejderID { get; set; }
    }
}
