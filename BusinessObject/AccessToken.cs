namespace BusinessObject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccessToken")]
    public partial class AccessToken
    {
        [Key]
        [StringLength(50)]
        public string Token { get; set; }

        public int UserID { get; set; }

        [Column(TypeName = "date")]
        public DateTime ExpiryDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public virtual User User { get; set; }
    }
}
