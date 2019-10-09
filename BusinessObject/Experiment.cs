namespace BusinessObject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Experiment")]
    public partial class Experiment
    {
        public int ID { get; set; }

        public int SessionID { get; set; }

        public int ParticipantID { get; set; }

        public int ExperiemntInfoID { get; set; }

        public virtual ExperimentInfo ExperimentInfo { get; set; }

        public virtual Participant Participant { get; set; }

        public virtual Session Session { get; set; }
    }
}
