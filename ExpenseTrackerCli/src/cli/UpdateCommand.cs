using ExpenseTrackerCli.src.models;
using ExpenseTrackerCli.src.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCli.src.cli
{
    internal class UpdateCommand : ICommandHandler
    {
        public void Execute(string[] arguments, ExpenseRepository expenseRepository)
            {
                if (arguments.Length == 4 && arguments[0].ToLower() == "update")
                {
                    if (int.TryParse(arguments[1], out int expenseId))
                    {
                        var expenseName = arguments[2];
                        var expenseAmount = arguments[3];

                        if (Double.TryParse(expenseAmount, out double parsedAmount))
                        {
                            
                            var existingExpense = expenseRepository.GetExpenseById(expenseId);
                            if (existingExpense != null)
                            {
                                var updatedExpense = new Expense(expenseId, expenseName, parsedAmount, DateTime.Now);
                                expenseRepository.UpdateExpense(updatedExpense);
                                Console.WriteLine($"Expense with ID {expenseId} has been updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine($"No expense found with ID {expenseId}.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount input. Ensure that the amount is in a valid format.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Ensure that the expense ID is an integer.");
                    }
                }
                else
                {
                    Console.WriteLine("Usage: update <ID> <Name> <Amount>");
                }
            }
        }
}
