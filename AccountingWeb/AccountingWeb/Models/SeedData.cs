using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//using Microsoft.EntityFrameworkCore;
//using MySql.Data.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;


namespace AccountingWeb.Models
{
    public static class SeedData
    {
        public static void Initalize(AccountingWebContext context)
        {
            context.Database.EnsureCreated();
           
            if (context.Accountings.Count() == 0)
            {

                var data = new Accounting[] {
                    new Accounting
                    {
                        Id = 1,
                        Price = 40.0,
                        Type = "餐飲",
                        Comment = "早餐:UCC咖啡,黑糖饅頭",
                        Date = DateTime.Parse("2019/4/3").Date
                    },
                    new Accounting
                    {
                        Id = 2,
                        Price = 55.0,
                        Type = "餐飲",
                        Comment = "午餐:宵夜-大乾麵",
                        Date = DateTime.Parse("2019/4/3").Date
                    },
                    new Accounting
                    {
                        Id = 3,
                        Price = 65.0,
                        Type = "餐飲",
                        Comment = "晚餐:鐵板便當-蔥爆豬肉便當",
                        Date = DateTime.Parse("2019/4/3").Date
                    }
                };

                foreach (Accounting a in data)
                {
                    context.Accountings.Add(a);
                }
                context.SaveChanges();
            }

            if (context.ExpenseTypes.Count() <= 0)
            {
                var data = new ExpenseType[]
                {
                    new ExpenseType
                    {
                        Id = 1,
                        Expense_Type = "餐飲"
                    },
                    new ExpenseType
                    {
                        Id = 2,
                        Expense_Type = "交通"
                    },
                    new ExpenseType
                    {
                        Id = 3,
                        Expense_Type = "投資"
                    },
                    new ExpenseType
                    {
                        Id = 4,
                        Expense_Type = "雜費"
                    }
                };

                foreach (ExpenseType e in data)
                {
                    context.ExpenseTypes.Add(e);
                }
                context.SaveChanges();
            }
        }
    }
}
