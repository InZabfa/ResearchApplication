namespace BusinessObject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExperimentInfo")]
    public partial class ExperimentInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExperimentInfo()
        {
            Experiments = new HashSet<Experiment>();
        }

        public int ID { get; set; }

        public DateTime DateHeld { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        public int ResearcherID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Experiment> Experiments { get; set; }

        public virtual Researcher Researcher { get; set; }
    }
}
