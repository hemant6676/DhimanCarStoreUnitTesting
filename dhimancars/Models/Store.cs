namespace dhimancars.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Store")]
    public partial class Store
    {
        [Key]
        public int CarID { get; set; }

        [Required]
        [StringLength(10)]
        public string CarModel { get; set; }

        [Required]
        [StringLength(10)]
        public string CarYear { get; set; }

        [Required]
        [StringLength(10)]
        public string Price { get; set; }
    }
}
