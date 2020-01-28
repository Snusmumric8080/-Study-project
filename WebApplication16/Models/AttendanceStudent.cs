namespace WebApplication16.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AttendanceStudent")]
    public partial class AttendanceStudent
    {
        [Key]
        public int IDAttendanceStudent { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public int IdStudent { get; set; }

        [Column(TypeName = "date")]
        public DateTime IdAttendance { get; set; }

        public virtual Attendance1 Attendance1 { get; set; }

        public virtual Student Student { get; set; }
    }
}
