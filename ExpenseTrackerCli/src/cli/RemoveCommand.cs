using ExpenseTrackerCli.src.models;
using ExpenseTrackerCli.src.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCli.src.cli
{
    internal class RemoveCommand : ICommandHandler
    {
        public void Execute(string[] arguments,ExpenseRepository expenseRepository)
        {
            {
                if (arguments.Length == 1)
                {
                    var expenseDeletion = arguments[0];

                    if (int.TryParse(expenseDeletion, out int expenseId))
                    {
                       expenseRepository.RemoveExpense(expenseId);

                            Console.WriteLine($"Expense with ID {expenseId} has been removed.");

                    }
                    else
                    {
                        Console.WriteLine("Invalid ID format. Please enter a valid number.");
                    }
                }
                else
                {
                    Console.WriteLine("Usage example: remove <ID>");
                }
            }
        }
    }
}
