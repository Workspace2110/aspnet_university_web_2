using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace AccountingWeb.Models
{
    public class ExpenseType
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "種類")]
        public string Expense_Type { get; set; }
    }
}
