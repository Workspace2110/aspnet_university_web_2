using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AccountingWeb.Models
{
    public class AccountingWebContext : DbContext
    {
        public AccountingWebContext (DbContextOptions<AccountingWebContext> options)
            : base(options)
        {
        }

        public DbSet<AccountingWeb.Models.Accounting> Accountings { get; set; }
        public DbSet<AccountingWeb.Models.ExpenseType> ExpenseTypes { get; set; }
    }
}
