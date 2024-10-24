using ExpenseTrackerCli.src.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerCli.src.cli
{
    internal interface ICommandHandler
    {
        void Execute(string[] arguments, ExpenseRepository expenseRepository); 
    }
}
