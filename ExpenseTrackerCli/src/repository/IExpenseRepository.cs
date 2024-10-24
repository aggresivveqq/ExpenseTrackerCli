using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerCli.src.models;

namespace ExpenseTrackerCli.src.services
{
    internal interface IExpenseRepository
    {
       void AddExpense(Expense expense);
       void RemoveExpense(int id);
       void UpdateExpense(Expense expense);
       List<Expense> GetAllExpenses();
        List<Expense> GetAllExpensesByMonth(int Month);
        void SaveExpense(List<Expense> expenses);
        void Summary();
        Expense GetExpenseById(int id);
    }
}
