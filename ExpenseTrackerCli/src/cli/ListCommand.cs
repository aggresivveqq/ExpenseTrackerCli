using ExpenseTrackerCli.src.services;
using System;
using ExpenseTrackerCli.src.models;
using ExpenseTrackerCli.src.cli;

namespace ExpenseTrackerCli.src.cli
{
    internal class ListCommand : ICommandHandler
    {
        public void Execute(string[] arguments, ExpenseRepository expenseRepository)
        {
            if (arguments.Length == 0 || arguments[0].ToLower() == "list")
            {
                var expenses = expenseRepository.GetAllExpenses();

                if (expenses.Count == 0)
                {
                    Console.WriteLine("No expenses found.");
                }
                else
                {
                    Console.WriteLine("Listing all expenses:");
                    foreach (var expense in expenses)
                    {
                        Console.WriteLine($"ID: {expense.Id}, Description: {expense.Description}, Amount: {expense.Amount}, Date: {expense.DateTime}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Usage example: list");
            }
        }
    }
}