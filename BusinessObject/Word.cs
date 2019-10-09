namespace BusinessObject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Word
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Word()
        {
            InteractiveResources = new HashSet<InteractiveResource>();
            Levels = new HashSet<Level>();
            WrongAnswers = new HashSet<WrongAnswer>();
        }

        public int ID { get; set; }

        [Column("Word")]
        [Required]
        [StringLength(50)]
        public string Word1 { get; set; }

        public int ResearcherID { get; set; }

        public int DifficultyID { get; set; }

        public virtual Difficulty Difficulty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InteractiveResource> InteractiveResources { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Level> Levels { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WrongAnswer> WrongAnswers { get; set; }
    }
}
