using ExpenseTrackerCli.src.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCli.src.cli
{
    internal class ShowSummaryByMonth : ICommandHandler
    {
        public void Execute(string[] arguments, ExpenseRepository expenseRepository)
        {
            if (arguments.Length == 1)
            {
                var showSummaryByMonth = arguments[0];
                if (Int32.TryParse(showSummaryByMonth, out int month))
                {
                    var expenses = expenseRepository.GetAllExpensesByMonth(month);

                    if (expenses.Count == 0)
                    {
                        Console.WriteLine($"No expenses found for month {month}.");
                    }
                    else
                    {
                        Console.WriteLine($"Expenses for month {month}:");
                        foreach (var expense in expenses)
                        {
                            Console.WriteLine($"- {expense.Description}: {expense.Amount} on {expense.DateTime}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid month input. Please enter a valid month (1-12).");
                }
            }
            else
            {
                Console.WriteLine("Usage example: summary <month>");
            }
        }
    }      
}
