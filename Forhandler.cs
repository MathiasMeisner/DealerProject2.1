namespace DealerProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Forhandler")]
    public partial class Forhandler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Forhandler()
        {
            Bil = new HashSet<Bil>();
            Medarbejder = new HashSet<Medarbejder>();
        }

        public int ForhandlerID { get; set; }

        [Required]
        [StringLength(30)]
        public string ForhandlerNavn { get; set; }

        [Required]
        [StringLength(50)]
        public string ForhandlerAdresse { get; set; }

        [Required]
        [StringLength(30)]
        public string ForhandlerBy { get; set; }

        public int ForhandlerTelefon { get; set; }

        [Required]
        [StringLength(30)]
        public string ForhandlerEmail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bil> Bil { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medarbejder> Medarbejder { get; set; }
    }
}
