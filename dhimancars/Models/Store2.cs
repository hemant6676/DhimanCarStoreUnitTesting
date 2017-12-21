namespace dhimancars.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Store2
    {
        [Key]
        public int CarID { get; set; }

        [Required]
        [StringLength(10)]
        public string Colour { get; set; }

        [Required]
        [StringLength(10)]
        public string Wheels { get; set; }

        [Required]
        [StringLength(10)]
        public string Model { get; set; }
    }
}
