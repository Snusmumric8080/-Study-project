namespace WebApplication16.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        { 
            AttendanceStudents = new HashSet<AttendanceStudent>();
            Progresses = new HashSet<Progress>();
        }

        [Key]
        public int IdStudent { get; set; }

        [StringLength(150)]
        public string FullNameStudent { get; set; }

        [StringLength(150)]
        public string Town { get; set; }

        [StringLength(150)]
        public string Street { get; set; }

        [StringLength(150)]
        public string Home { get; set; }

        [StringLength(150)]
        public string TeacherFullName { get; set; }

        [StringLength(150)]
        public string PlaseOfBirt { get; set; }

        [StringLength(50)]
        public string DateOfBirt { get; set; }

        public int? klass { get; set; }

        [StringLength(150)]
        public string FullNameMother { get; set; }

        [StringLength(15)]
        public string NumerMother { get; set; }

        [StringLength(150)]
        public string PlaseWorkMother { get; set; }

        [StringLength(150)]
        public string FullNameFather { get; set; }

        [StringLength(15)]
        public string NumberFather { get; set; }

        [StringLength(150)]
        public string PlaseWorkFather { get; set; }

        [StringLength(50)]
        public string Mail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttendanceStudent> AttendanceStudents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Progress> Progresses { get; set; }
    }
}
