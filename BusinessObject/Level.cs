namespace BusinessObject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Level")]
    public partial class Level
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Level()
        {
            SessionLevels = new HashSet<SessionLevel>();
            WrongAnswers = new HashSet<WrongAnswer>();
        }

        public int ID { get; set; }

        public int WordID { get; set; }

        public int ResourceID { get; set; }

        public virtual InteractiveResource InteractiveResource { get; set; }

        public virtual Word Word { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SessionLevel> SessionLevels { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WrongAnswer> WrongAnswers { get; set; }
    }
}
