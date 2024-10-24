using ExpenseTrackerCli.src.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCli.src.cli
{
    internal class SummaryCommand : ICommandHandler
    {
        public void Execute(string[] arguments, ExpenseRepository expenseRepository)
        {
            if (arguments.Length == 0 || arguments[0].ToLower() == "summary")
            {
                expenseRepository.Summary();


            }
            else
            {
                Console.WriteLine("Usage example: summary");
                return;
            }
        }
    }
}
