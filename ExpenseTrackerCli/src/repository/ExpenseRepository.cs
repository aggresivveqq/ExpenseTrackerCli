using ExpenseTrackerCli.src.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
namespace ExpenseTrackerCli.src.services
{
    internal class ExpenseRepository : IExpenseRepository
    {
            List<Expense> expenses = new List<Expense>();
            private readonly string _Filepath = "C:\\Users\\china\\source\\repos\\ExpenseTrackerCli\\ExpenseTrackerCli\\src\\json\\Data.json";
            public void AddExpense(Expense expense)
            {
             var expenses = GetAllExpenses();
            expenses.Add(expense);  
            SaveExpense(expenses);
            }
            
        
            public void UpdateExpense(Expense UpdatedExpense)
            {
              var expenses = GetAllExpenses();
               var expenseToUpdate = expenses.Find(t => t.Id == UpdatedExpense.Id);
            if (expenseToUpdate != null)
            {
               expenseToUpdate.Description = UpdatedExpense.Description;
                expenseToUpdate.Amount = UpdatedExpense.Amount;
                expenseToUpdate.DateTime = UpdatedExpense.DateTime;

                SaveExpense(expenses);
                Console.WriteLine($"Expense with id {UpdatedExpense.Id} updated.");
            }
            else
            {
               Console.WriteLine($"Expense with {UpdatedExpense.Id} is not exist");
            }

            

            }
            public void RemoveExpense(int id)
            {
            var expenses = GetAllExpenses();
            var expenseToDelete = expenses.Find(x => x.Id == id);
            if(expenseToDelete != null)
            {
                expenses.Remove(expenseToDelete);
                SaveExpense(expenses);
                Console.WriteLine($"Expense with id{expenseToDelete.Id} deleted");
            }
            else
            {
                Console.WriteLine($"Expense with {expenseToDelete.Id} is not exist");
            }
              
            }
            public List<Expense> GetAllExpenses()
            {
            if (!File.Exists(_Filepath))
            {
                return new List<Expense>();
            }
            var fileContent = File.ReadAllText(_Filepath);
            return JsonConvert.DeserializeObject <List<Expense>>(fileContent) ?? new List<Expense>();

            }
             public List<Expense> GetAllExpensesByMonth(int month)
            {
            if (month < 1 || month > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 - 12");
            }

            var expenses = GetAllExpenses();
            return expenses.Where(e => e.DateTime.Month == month).ToList();
        }
             public void SaveExpense(List<Expense> expenses)
            {
             try
            {
                var json = JsonConvert.SerializeObject(expenses, Formatting.Indented);
                File.WriteAllText(_Filepath, json);
            }
                  catch (Exception ex)
            {
                Console.WriteLine($"Error saving expenses: {ex.Message}");
            }
        }
             public Expense GetExpenseById(int id)
             {
               var expenseToReturn = GetAllExpenses();
               return expenseToReturn.Find(x => x.Id == id);
    
             }
             public void Summary()
            {
              var expenses = GetAllExpenses();
               if (!expenses.Any())
            {
                Console.WriteLine("No expenses found.");
                return;
            }

              var totalExpenses = expenses.Count;
              var totalAmount = expenses.Sum(e => e.Amount);

            Console.WriteLine($"Total Expenses: {totalExpenses}");
            Console.WriteLine($"Total Amount: {totalAmount} $");
        }

       

    }
}
