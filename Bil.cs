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
        public int BilID { get; set; }

        public int ForhandlerID { get; set; }

        [Required]
        [StringLength(30)]
        public string BilMaerke { get; set; }

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
    }
}
