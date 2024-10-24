using System;
using ExpenseTrackerCli.src.models;
using ExpenseTrackerCli.src.services;

namespace ExpenseTrackerCli.src.cli
{
    internal class AddCommand : ICommandHandler
    {
        public void Execute(string[] arguments, ExpenseRepository expenseRepository)
        {
            if (arguments.Length < 2)
            {
                Console.WriteLine("Invalid command. Example: add description amount");
                return;
            }

            var expenseName = arguments[0];
            if (Double.TryParse(arguments[1], out double expenseAmount))
            {
                var allExpenses = expenseRepository.GetAllExpenses();
                var expenseDate = DateTime.Now;

                var newId = allExpenses.Count > 0 ? allExpenses[allExpenses.Count - 1].Id + 1 : 1;

                var newExpense = new Expense(newId, expenseName, expenseAmount, expenseDate);

                expenseRepository.AddExpense(newExpense);

                Console.WriteLine($"Expense '{expenseName}' with ID {newId} and amount {expenseAmount} was added.");
            }
            else
            {
                Console.WriteLine("Invalid amount of money. Please enter a valid number.");
            }
        }
    }
}
