using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCli.src.models
{
    internal class Expense
    {
  
        public int Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime DateTime { get; set; }

       
        public Expense(int id, string description, double amount, DateTime dateTime)
        {
            Id = id; 
            Description = description;
            Amount = amount;
            DateTime = dateTime;
        }

        public override string ToString()
        {
            return $"id: {Id}, Date: {DateTime}, Description: {Description}, Amount: {Amount}";
        }

    }
}
