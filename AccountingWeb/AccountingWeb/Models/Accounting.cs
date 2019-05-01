using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountingWeb.Models
{
    public class Accounting
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "價錢"), Column(TypeName = "decimal(18, 2)")]
        public double Price { get; set; }

        [Required, Display(Name = "類別")]
        public string Type { get; set; }

        [Required, Display(Name = "評論")]
        public string Comment { get; set; }

        [Required, Display(Name = "日期"), DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
