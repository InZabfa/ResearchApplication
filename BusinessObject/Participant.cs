namespace BusinessObject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Participant")]
    public partial class Participant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Participant()
        {
            Experiments = new HashSet<Experiment>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ChildName { get; set; }

        [Required]
        [StringLength(50)]
        public string ParentName { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        public int UserID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Experiment> Experiments { get; set; }

        public virtual User User { get; set; }
    }
}
