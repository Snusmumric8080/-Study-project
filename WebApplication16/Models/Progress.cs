namespace WebApplication16.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Progress")]
    public partial class Progress
    {
        [Key]
        public int Id_Progress { get; set; }

        public int IdStudent { get; set; }

        public int IdSubject { get; set; }

        public int Rating { get; set; }

        public DateTime? date { get; set; }

        public virtual Student Student { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
