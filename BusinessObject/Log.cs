namespace BusinessObject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Log")]
    public partial class Log
    {
        public int ID { get; set; }

        public int SessionID { get; set; }

        public DateTime Timestamp { get; set; }

        [Required]
        public string ResultsRecorded { get; set; }

        public virtual Session Session { get; set; }
    }
}
