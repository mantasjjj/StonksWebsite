namespace StonksWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DBFinancialPlan")]
    public partial class DBFinancialPlan
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }

        [Required]
        public string FinancialPlan { get; set; }

        public virtual DBUser DBUser { get; set; }
    }
}
