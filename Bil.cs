namespace DealerProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bil")]
    public partial class Bil
    {
        // test
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bil()
        {
            Bookings = new HashSet<Booking>();
        }

        public int BilID { get; set; }

        public int ForhandlerID { get; set; }

        [Required]
        [StringLength(30)]
        public string BilMærke { get; set; }

        [Required]
        [StringLength(30)]
        public string BilModel { get; set; }

        [Required]
        [StringLength(30)]
        public string BilUdstyr { get; set; }

        [Required]
        [StringLength(30)]
        public string BilMotor { get; set; }

        public virtual Forhandler Forhandler { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
