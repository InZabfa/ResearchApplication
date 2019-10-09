namespace BusinessObject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WrongAnswer
    {
        public int ID { get; set; }

        public int LevelID { get; set; }

        public int ResourceID { get; set; }

        public int WordID { get; set; }

        public virtual InteractiveResource InteractiveResource { get; set; }

        public virtual Level Level { get; set; }

        public virtual Word Word { get; set; }
    }
}
