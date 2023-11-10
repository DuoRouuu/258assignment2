namespace assignment2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stoty")]
    public partial class Stoty
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string Title { get; set; }

        [StringLength(500)]
        public string ImgUrl { get; set; }
    }
}
