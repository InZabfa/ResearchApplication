namespace BusinessObject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class InteractiveResource
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InteractiveResource()
        {
            Levels = new HashSet<Level>();
            WrongAnswers = new HashSet<WrongAnswer>();
        }

        public int ID { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] Resource { get; set; }

        public int ResearcherID { get; set; }

        public int WordID { get; set; }

        public virtual Researcher Researcher { get; set; }

        public virtual Word Word { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Level> Levels { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WrongAnswer> WrongAnswers { get; set; }
    }
}
