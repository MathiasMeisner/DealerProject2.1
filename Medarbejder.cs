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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medarbejder()
        {
            Bookings = new HashSet<Booking>();
        }

        public int MedarbejderID { get; set; }

        public int ForhandlerID { get; set; }

        [Required]
        [StringLength(30)]
        public string MedarbejderNavn { get; set; }

        public int MedarbejderTelefon { get; set; }

        public bool SuperBruger { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual Forhandler Forhandler { get; set; }
    }
}
